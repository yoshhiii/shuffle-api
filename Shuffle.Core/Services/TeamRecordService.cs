using System.Linq;
using System.Collections.Generic;
using AutoMapper.QueryableExtensions;
using Shuffle.Data;
using Shuffle.Data.Entities;
using Shuffle.Core.Models;

namespace Shuffle.Core.Services
{
    public class TeamRecordService : ITeamRecordService
    {
        private readonly ShuffleDbContext _db;

        public TeamRecordService(ShuffleDbContext context)
        {
            _db = context;
        }

        public TeamRecord GetTeamRecord(int Id)
        {
            var teamRecord = _db.TeamRecords.Where(x => x.Id == Id).ProjectTo<TeamRecord>().FirstOrDefault();

            return teamRecord;
        }

        public List<TeamRecord> GetTeamRecords()
        {
            var teamRecords = _db.TeamRecords.ProjectTo<TeamRecord>().ToList();

            return teamRecords;
        }

        public TeamRecord CreateTeamRecord(TeamRecord recordToCreate)
        {
            var newUser = new UserEntity
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