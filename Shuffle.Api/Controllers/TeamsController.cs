using Shuffle.Core.Models;
using Shuffle.Core.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

namespace Shuffle.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TeamsController : ControllerBase
    {
        private readonly ITeamService _teamService;

        public TeamsController(ITeamService teamService)
        {
            _teamService = teamService;
        }

        // GET api/values
        [HttpGet]
        public IEnumerable<Team> Get(string authId, bool others)
        {
            return _teamService.GetTeams(authId, others);
        }

        // GET api/values/5
        [HttpGet("{id}")]
        public Team Get(int id)
        {
            return _teamService.GetTeam(id);
        }

        // POST api/values
        [HttpPost]
        public Team Post([FromBody] Team team, [FromQuery] string authId)
        {
            return _teamService.CreateTeam(team, authId);
        }

        // PUT api/values/5
        [HttpPut("{id}")]
        public Team Put(int id, [FromBody] bool active)
        {
            return _teamService.ArchiveTeam(id, active);
        }

        // DELETE api/values/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}