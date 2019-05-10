using Shuffle.Core.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Shuffle.Core.Services
{
    public interface ITeamRecordService
    {
<<<<<<< HEAD
        List<TeamRecord> GetTeamRecords(int? rulesetId);
=======
        List<TeamRecord> GetTeamRecords(int? Id);
>>>>>>> 9b209244f3eb151307a73a1bdef72e2ef39ed9e5
        TeamRecord GetTeamRecord(int Id);
        TeamRecord CreateTeamRecord(TeamRecord recordToCreate);
    }
}