using Shuffle.Core.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Shuffle.Core.Services
{
    public interface IMatchService
    {
        List<Match> GetMatches();
        Match GetMatch(int Id);
        Match CreateMatch(Match matchToCreate);
        void CompleteMatch(int id, Score finalScore);
    }
}