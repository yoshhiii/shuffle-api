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

        public List<TeamRecord> GetTeamRecords(int? rulesetId)
        {
            var teamRecords = _db.TeamRecords;
            if (rulesetId.HasValue)
            {
                var teamRecordsList = teamRecords.Where(x => x.RulesetId == rulesetId).ToList();
                var modelList = new List<TeamRecord>();
                teamRecordsList.ForEach(x => {
                    modelList.Add(new TeamRecord() { Elo = x.Elo, Losses = x.Losses, Wins = x.Wins, RulesetId = x.RulesetId, TeamId = x.TeamId });
                });
                return modelList;
            }
            var tr = teamRecords.ProjectTo<TeamRecord>().ToList();

            return tr;
        }

        public TeamRecord CreateTeamRecord(TeamRecord recordToCreate)
        {
            return null;
        }
    }
}