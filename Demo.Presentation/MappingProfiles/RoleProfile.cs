using AutoMapper;
using Demo.Presentation.ViewModels.RoleViewModels;
using Microsoft.AspNetCore.Identity;

namespace Demo.Presentation.MappingProfiles
{
    public class RoleProfile : Profile
    {
        public RoleProfile()
        {
            CreateMap<IdentityRole, RoleVM>()
                .ForMember(dest => dest.RoleName, opt => opt.MapFrom(src => src.Name))
                .ReverseMap();

            CreateMap<RoleVM, IdentityRole>()
                .ForMember(dest => dest.Name, opt => opt.MapFrom(src => src.RoleName))
                .ForMember(dest => dest.Id, opt => opt.MapFrom(src => string.IsNullOrEmpty(src.Id) ? Guid.NewGuid().ToString() : src.Id));
        }
    }
}
