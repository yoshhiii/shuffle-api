using Shuffle.Core.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Shuffle.Core.Services
{
    public interface ITeamRecordService
    {
        List<TeamRecord> GetTeamRecords(int? Id);
        TeamRecord GetTeamRecord(int Id);
        TeamRecord CreateTeamRecord(TeamRecord recordToCreate);
    }
}