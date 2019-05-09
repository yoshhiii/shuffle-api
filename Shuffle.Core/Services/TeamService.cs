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
            var teams = _db.Teams.Where(x => x.Id == Id).ProjectTo<Team>().FirstOrDefault();

            return teams;
        }

        public List<Team> GetTeams(int? userId)
        {
            var query = _db.Teams;

            if (userId.HasValue)
            {
                query.Where(x => x.UserTeams.Any(ut => ut.UserId == userId));
            }

            var team = query.ProjectTo<Team>().ToList();

            return team;
        }

        public Team CreateTeam(Team teamToCreate)
        {
            var userIds = teamToCreate.Users.Select(x => x.Id);
            var users = _db.Users.Where(x => userIds.Contains(x.Id)).ToList();
            var teamEntity = new TeamEntity
            {
                Name = teamToCreate.Name
            };

            var userTeams = new List<UserTeamEntity>();

            users.ForEach(x =>
            {
                userTeams.Add(new UserTeamEntity { TeamId = teamEntity.Id, UserId = x.Id });
            });

            _db.Teams.Add(new TeamEntity
            {
                Name = teamToCreate.Name,    
                UserTeams = userTeams
            });

            _db.SaveChanges();

            return teamToCreate;
        }
    }
}