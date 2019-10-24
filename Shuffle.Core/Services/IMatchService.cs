using Shuffle.Core.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Shuffle.Core.Services
{
    public interface IMatchService
    {
        List<Match> GetMatches(int? teamId, string authId, DateTime? dateToCheck);
        Match GetMatch(int Id);
        Match CreateMatch(Match matchToCreate);
        void CompleteMatch(int id, Score finalScore);
        void ToggleMatchStatus(int id, bool active);
    }
}