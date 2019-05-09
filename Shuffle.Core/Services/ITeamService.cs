using Shuffle.Core.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Shuffle.Core.Services
{
    public interface ITeamService
    {
        List<Team> GetTeams(int? userId);
        Team GetTeam(int Id);
        Team CreateTeam(Team teamToCreate);
    }
}