using Shuffle.Core.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Shuffle.Core.Services
{
    public interface IRulesetService
    {
        List<Ruleset> GetRulesets();
        Ruleset GetRuleset(int id);
    }
}