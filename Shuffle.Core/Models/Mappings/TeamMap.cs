using System.Linq;
using AutoMapper;
using Shuffle.Data.Entities;
using Shuffle.Core.Models;

namespace shuffleboard.core.Models.Mappings
{
    public class TeamMap : Profile
    {
        public TeamMap()
        {
            CreateMap<TeamEntity, Team>()
                .ForMember(x => x.Id, opt => opt.MapFrom(x => x.Id))
                .ForMember(x => x.Name, opt => opt.MapFrom(x => x.Name))
                .ForMember(x => x.Color, opt => opt.MapFrom(x => x.Color))
                .ForMember(x => x.Users, opt => opt.MapFrom(x => x.UserTeams.Select(u => new User {
                    Id = u.UserId,
                    Name = u.User.Name,
                    Email = u.User.Email,
                    AuthId = u.User.AuthId
                })));
        }
    }
}