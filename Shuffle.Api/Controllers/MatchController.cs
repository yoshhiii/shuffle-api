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
    public class MatchController : ControllerBase
    {
        private readonly IMatchService _matchService;

        public MatchController(IMatchService matchService)
        {
            _matchService = matchService;
        }

        // GET api/values
        [HttpGet]
        public IEnumerable<Match> Get(int? teamId, string authId, bool future = false)
        {
            return _matchService.GetMatches(teamId, authId, future);
        }

        // GET api/values/5
        [HttpGet("{id}")]
        public Match Get(int id)
        {
            return _matchService.GetMatch(id);
        }

        // POST api/values
        [HttpPost]
        public Match Post([FromBody] Match match)
        {
            return _matchService.CreateMatch(match);
        }

        // PUT api/values/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] Score result)
        {
            _matchService.CompleteMatch(id, result);
        }

        // DELETE api/values/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}