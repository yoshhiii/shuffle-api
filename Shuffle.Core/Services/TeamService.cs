using System.Linq;
using System.Collections.Generic;
using AutoMapper.QueryableExtensions;
using Microsoft.EntityFrameworkCore;
using Shuffle.Data;
using Shuffle.Data.Entities;
using Shuffle.Core.Models;

namespace Shuffle.Core.Services
{
    public class TeamService : ITeamService
    {
        private readonly ShuffleDbContext _db;

        public TeamService(ShuffleDbContext context)
        {
            _db = context;
        }

        public Team GetTeam(int Id)
        {
            var teams = _db.Teams.Where(x => x.Id == Id && x.Active).ProjectTo<Team>().FirstOrDefault();

            return teams;
        }

        public List<Team> GetTeams(string authId, bool others)
        {
            var query = _db.Teams.Include(x => x.UserTeams).Where(x => x.Active);

            if (!string.IsNullOrEmpty(authId))
            {
                query = query
                    .Include(x => x.UserTeams);
                if (others)
                {
                    query = query.Where(x => x.UserTeams.All(ut => ut.User.AuthId != authId));
                } else
                {
                    query = query.Where(x => x.UserTeams.Any(ut => ut.User.AuthId == authId));
                }
                var myTeams = query.ProjectTo<Team>().ToList();

                return myTeams;
            }

            var team = query.ProjectTo<Team>().ToList();

            return team;
        }

        public Team CreateTeam(Team teamToCreate, string authId)
        {
            var userIds = teamToCreate.Users.Select(x => x.AuthId);
            var users = _db.Users.Where(x => userIds.Contains(x.AuthId)).ToList();
            var currentUser = _db.Users.Where(x => x.AuthId == authId).FirstOrDefault();
            var teamEntity = new TeamEntity
            {
                Name = teamToCreate.Name,
                Color = teamToCreate.Color
            };

            var userTeams = new List<UserTeamEntity>();
            users.Add(currentUser);
            users.ForEach(x =>
            {
                userTeams.Add(new UserTeamEntity { TeamId = teamEntity.Id, UserId = x.Id });
            });

            var newTeamEntity = new TeamEntity
            {
                Name = teamToCreate.Name,
                Color = teamToCreate.Color,
                UserTeams = userTeams
            };
            _db.Teams.Add(newTeamEntity);

            _db.TeamRecords.Add(new TeamRecordEntity
            {
                TeamId = newTeamEntity.Id,
                RulesetId = 1,
                Elo = 1500,
                Wins = 0,
                Losses = 0
            });

            _db.SaveChanges();

            return teamToCreate;
        }

        public Team ArchiveTeam(int id, bool active)
        {
            var team = _db.Teams.Include(x => x.UserTeams).Where(x => x.Id == id).FirstOrDefault();

            if (team == null)
            {
                throw new System.Exception();
            }
            team.Active = active;
            _db.Update(team);
            _db.SaveChanges();
            return new Team { Id = team.Id, Name = team.Name, Color = team.Color, Users = team.UserTeams.Select(x => new User()).ToList() };


        }
    }
}