using System.Linq;
using AutoMapper;
using Shuffle.Data.Entities;
using Shuffle.Core.Models;

namespace shuffleboard.core.Models.Mappings
{
    public class TeamRecordMap : Profile
    {
        public TeamRecordMap()
        {
<<<<<<< HEAD
            CreateMap<UserEntity, User>()
                .ForMember(x => x.Name, opt => opt.MapFrom(x => x.Name))
                .ForMember(x => x.AuthId, opt => opt.MapFrom(x => x.AuthId))
                .ForMember(x => x.Email, opt => opt.MapFrom(x => x.Email))
                .ForMember(x => x.Id, opt => opt.MapFrom(x => x.Id))
                .ForMember(x => x.FcmToken, opt => opt.MapFrom(x => x.FcmToken));

=======
            CreateMap<TeamRecordEntity, TeamRecord>()
                .ForMember(x => x.Name, opt => opt.MapFrom(x => x.Team.Name))
                .ForMember(x => x.TeamId, opt => opt.MapFrom(x => x.Id))
                .ForMember(x => x.Elo, opt => opt.MapFrom(x => x.Elo))
                .ForMember(x => x.Losses, opt => opt.MapFrom(x => x.Losses))
                .ForMember(x => x.Wins, opt => opt.MapFrom(x => x.Wins))
                .ForMember(x => x.RulesetId, opt => opt.MapFrom(x => x.RulesetId));
>>>>>>> 2e45d953d4ea75c3070adaed05b284dfee65f606
        }
    }
}