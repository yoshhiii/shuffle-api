using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Shuffle.Core.Models;
using Shuffle.Core.Services;

namespace Shuffle.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class RulesetsController : ControllerBase
    {
        private readonly IRulesetService _rulesetService;

        public RulesetsController(IRulesetService rulesetService)
        {
            _rulesetService = rulesetService;
        }

        // GET api/values
        [HttpGet]
        public IEnumerable<Ruleset> Get()
        {
            return _rulesetService.GetRulesets();
        }

        // GET api/values/5
        [HttpGet("{id}")]
        public Ruleset Get(int id)
        {
            return _rulesetService.GetRuleset(id);
        }

        // POST api/values
        [HttpPost]
        public void Post([FromBody] Ruleset ruleset)
        {

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