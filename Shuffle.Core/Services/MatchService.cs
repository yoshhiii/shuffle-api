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
                FirstName = userToCreate.FirstName,
                LastName = userToCreate.LastName,
                Email = userToCreate.Email,
                Password = userToCreate.Password
            };

            var user = _db.Users.Add(newUser);

            var result = _db.SaveChanges();

            return new User
            {
                FirstName = userToCreate.FirstName,
                LastName = userToCreate.LastName,
                Email = userToCreate.Email,
                Password = userToCreate.Password,
                Id = result
            };
        }
    }
}