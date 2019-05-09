using System.Linq;
using AutoMapper;
using Shuffle.Data.Entities;
using Shuffle.Core.Models;

namespace shuffleboard.core.Models.Mappings
{
    public class MatchMap : Profile
    {
        public MatchMap()
        {
            CreateMap<MatchEntity, Match>()
                .ForMember(x => x.Id, opt => opt.MapFrom(x => x.Id))
                .ForMember(x => x.ChallengerId, opt => opt.MapFrom(x => x.ChallengerId))
                .ForMember(x => x.ChallengerName, opt => opt.MapFrom(x => x.Challenger.Name))
                .ForMember(x => x.ChallengerScore, opt => opt.MapFrom(x => x.ChallengerScore))
                .ForMember(x => x.OppositionId, opt => opt.MapFrom(x => x.OppositionId))
                .ForMember(x => x.OppositionName, opt => opt.MapFrom(x => x.Opposition.Name))
                .ForMember(x => x.OppositionScore, opt => opt.MapFrom(x => x.OppositionScore))
                .ForMember(x => x.MatchDate, opt => opt.MapFrom(x => x.MatchDate))
                .ForMember(x => x.RulesetId, opt => opt.MapFrom(x => x.RulesetId));
        }
    }
}