using System.Linq;
using System.Collections.Generic;
using AutoMapper.QueryableExtensions;
using Shuffle.Data;
using Shuffle.Data.Entities;
using Shuffle.Core.Models;
using System;
using System.IO;
using System.Text;
using System.Net;
using Newtonsoft.Json;
using Microsoft.EntityFrameworkCore;

namespace Shuffle.Core.Services
{
    public class MatchService : IMatchService
    {
        private readonly ShuffleDbContext _db;

        enum GameOutcome
        {
            Win = 1,
            Loss = 0
        }

        public MatchService(ShuffleDbContext context)
        {
            _db = context;
        }

        public Match GetMatch(int Id)
        {
            var match = _db.Matches.Where(x => x.Id == Id).ProjectTo<Match>().FirstOrDefault();

            return match;
        }

        public List<Match> GetMatches(int? teamId, string authId, DateTime? dateToCheck)
        {

            var query = _db.Matches.Include(x => x.Challenger).ThenInclude(x => x.TeamRecords).Include(x => x.Opposition).ThenInclude(x => x.TeamRecords).Where(x => x.Active).AsQueryable();
            if (teamId.HasValue)
            {
                query = query.Where(x => x.ChallengerId == teamId || x.OppositionId == teamId)
                    .Where(x => x.Challenger.Active && x.Opposition.Active);
            }
            if(dateToCheck.HasValue)
            {
                query = query.Where(x => DatesAreInTheSameWeek(x.MatchDate, dateToCheck.Value));
            }

            var matches = new List<Match>();

            if(!string.IsNullOrEmpty(authId))
            {
                var user = _db.Users.Include(x => x.UserTeams).Where(x => x.AuthId == authId).FirstOrDefault();
                var teams = user.UserTeams.Select(x => x.TeamId).ToList();
                matches = query.Where(x => teams.Contains(x.ChallengerId.Value) || teams.Contains(x.OppositionId.Value)).Where(x => x.MatchDate >= DateTime.Now).ProjectTo<Match>().ToList();
            }
            else
            {
                matches = query.ProjectTo<Match>().ToList();
            }

            return matches;
        }

        public Match CreateMatch(Match matchToCreate)
        {
            var newMatch = new MatchEntity
            {
                ChallengerId = matchToCreate.ChallengerId,
                OppositionId = matchToCreate.OppositionId,
                ChallengerScore = null,
                OppositionScore = null,
                MatchDate = matchToCreate.MatchDate,
                RulesetId = matchToCreate.RulesetId
            };

            _db.Matches.Add(newMatch);

            var result = _db.SaveChanges();

            var oppositionTeam =  _db.Matches
                .Include(x => x.Opposition)
                .ThenInclude(x => x.UserTeams)
                .ThenInclude(x => x.User)
                .Where(x => x.Id == newMatch.Id)
                .SelectMany(x => x.Opposition.UserTeams)
                .Select(x => x.User).ProjectTo<User>().ToList();

            oppositionTeam.ForEach(x => {
                if (x.FcmToken != null)
                {
                    sendFCM(x, matchToCreate);
                }
            });



            return new Match
            {
                ChallengerId = matchToCreate.ChallengerId,
                OppositionId = matchToCreate.OppositionId,
                MatchDate = matchToCreate.MatchDate,
                RulesetId = matchToCreate.RulesetId,
                Id = result
            };
        }

        public void ToggleMatchStatus(int id, bool active)
        {
            var match = _db.Matches.FirstOrDefault(x => x.Id == id);
            if(match == null)
            {
                return;
            }

            match.Active = active;

            _db.Matches.Update(match);
            _db.SaveChanges();
        }

        public void CompleteMatch(int Id, Score finalScore)
        {
            var match = _db.Matches.FirstOrDefault(x => x.Id == Id);
            if (match == null)
            {
                return;
            }
            var challenger = _db.TeamRecords.FirstOrDefault(x => x.TeamId == match.ChallengerId && x.RulesetId == match.RulesetId);
            var opposition = _db.TeamRecords.FirstOrDefault(x => x.TeamId == match.OppositionId && x.RulesetId == match.RulesetId);

            var outcome = DetermineWinner(finalScore);

            var eloChange = CalculateELO(challenger.Elo, opposition.Elo, outcome);

            challenger.Elo += eloChange;
            opposition.Elo -= eloChange;

            if (outcome == GameOutcome.Win)
            {
                challenger.Wins++;
                opposition.Losses++;
            }
            else
            {
                challenger.Losses++;
                opposition.Wins++;
            }

            match.ChallengerScore = finalScore.ChallengerScore;
            match.OppositionScore = finalScore.OppositionScore;
            match.Active = false;

            _db.SaveChanges();
        }

        static double ExpectationToWin(int playerOneRating, int playerTwoRating)
        {
            return 1 / (1 + System.Math.Pow(10, (playerTwoRating - playerOneRating) / 400.0));
        }

        static int CalculateELO(int playerOneRating, int playerTwoRating, GameOutcome outcome)
        {
            int eloK = 32;

            int delta = (int)(eloK * ((int)outcome - ExpectationToWin(playerOneRating, playerTwoRating)));

            return delta;
        }

        static GameOutcome DetermineWinner(Score score)
        {
            if (score.ChallengerScore > score.OppositionScore) return GameOutcome.Win;

            return GameOutcome.Loss;
        }

        private bool DatesAreInTheSameWeek(DateTime date1, DateTime date2)
        {
            var cal = System.Globalization.DateTimeFormatInfo.CurrentInfo.Calendar;
            var w1 = cal.GetWeekOfYear(date1, System.Globalization.CalendarWeekRule.FirstDay, DayOfWeek.Sunday);
            var w2 = cal.GetWeekOfYear(date2, System.Globalization.CalendarWeekRule.FirstDay, DayOfWeek.Sunday);

            return w1 == w2;
        }

        private void sendFCM(User user, Match match)
        {
            WebRequest tRequest = WebRequest.Create("https://fcm.googleapis.com/fcm/send");
            tRequest.Method = "post";
            //serverKey - Key from Firebase cloud messaging server  
            tRequest.Headers.Add(string.Format("Authorization: key={0}", "AAAAcRcoyww:APA91bHmz3Ug10-pjkjY97DlYq7DZoEqbI4fr8gVV3PNLQvDnqzpxv8YN4jJUJ6Bls2JrX3AGsq2S3cS56gQnjj_hafnEI6fDrw5cAQiNzpRxbx66Csx73_vAXrig3-4srcMaCzVb4zx"));
            //Sender Id - From firebase project setting  
            tRequest.Headers.Add(string.Format("Sender: id={0}", "485719853836"));
            tRequest.ContentType = "application/json";
            var payload = new
            {
                to = user.FcmToken,
                priority = "high",
                content_available = true,
                notification = new
                {
                    body = $"Your team {match.OppositionName} has been challenged by {match.ChallengerName} scheduled for {match.MatchDate.ToShortDateString()} at {match.MatchDate.ToShortTimeString()}",
                    title = "You have been challenged!",
                    badge = 1
                },
            };

            string postbody = JsonConvert.SerializeObject(payload).ToString();
            Byte[] byteArray = Encoding.UTF8.GetBytes(postbody);
            tRequest.ContentLength = byteArray.Length;
            using (Stream dataStream = tRequest.GetRequestStream())
            {
                dataStream.Write(byteArray, 0, byteArray.Length);
                using (WebResponse tResponse = tRequest.GetResponse())
                {
                    using (Stream dataStreamResponse = tResponse.GetResponseStream())
                    {
                        if (dataStreamResponse != null) using (StreamReader tReader = new StreamReader(dataStreamResponse))
                            {
                                String sResponseFromServer = tReader.ReadToEnd();
                                //result.Response = sResponseFromServer;
                            }
                    }
                }
            }
        }
    }
}