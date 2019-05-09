using System.Linq;
using System.Collections.Generic;
using AutoMapper.QueryableExtensions;
using Shuffle.Data;
using Shuffle.Data.Entities;
using Shuffle.Core.Models;

namespace Shuffle.Core.Services
{
    public class MatchService : IMatchService
    {
        private readonly ShuffleDbContext _db;

        public MatchService(ShuffleDbContext context)
        {
            _db = context;
        }

        public Match GetMatch(int Id)
        {
            var match = _db. Matches.Where(x => x.Id == Id).ProjectTo<Match>().FirstOrDefault();

            return match;
        }

        public List<Match> GetMatches()
        {
            var matches = _db.Matches.ProjectTo<Match>().ToList();

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

            var user = _db.Matches.Add(newMatch);

            var result = _db.SaveChanges();

            return new Match
            {
                ChallengerId = matchToCreate.ChallengerId,
                OppositionId = matchToCreate.OppositionId,
                MatchDate = matchToCreate.MatchDate,
                RulesetId = matchToCreate.RulesetId,
                Id = result
            };
        }
    }
}