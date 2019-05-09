using System.Linq;
using System.Collections.Generic;
using AutoMapper.QueryableExtensions;
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

        public List<Team> GetTeams()
        {
            var team = _db.Users.ProjectTo<Team>().ToList();

            return team;
        }

        public Team CreateTeam(Team teamToCreate)
        {

        }
    }
}