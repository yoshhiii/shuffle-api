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
        public IEnumerable<Team> Get(int? userId)
        {
            return _teamService.GetTeams(userId);
        }

        // GET api/values/5
        [HttpGet("{id}")]
        public Team Get(int id)
        {
            return _teamService.GetTeam(id);
        }

        // POST api/values
        [HttpPost]
        public Team Post([FromBody] Team team)
        {
            return _teamService.CreateTeam(team);
        }

        // PUT api/values/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE api/values/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}