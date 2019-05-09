using System.Linq;
using System.Collections.Generic;
using AutoMapper.QueryableExtensions;
using Shuffle.Data;
using Shuffle.Data.Entities;
using Shuffle.Core.Models;

namespace Shuffle.Core.Services
{
    public class RulesetService : IRulesetService
    {
        private readonly ShuffleDbContext _db;

        public RulesetService(ShuffleDbContext context)
        {
            _db = context;
        }

        public Ruleset GetRuleset(int id)
        {
            var ruleset = _db.Rulesets.Where(x => x.Id == id).ProjectTo<Ruleset>().FirstOrDefault();

            return ruleset ;
        }

        public List<Ruleset> GetRulesets()
        {
            var ruleset = _db.Rulesets.ProjectTo<Ruleset>().ToList();

            return ruleset;
        }

    }
}