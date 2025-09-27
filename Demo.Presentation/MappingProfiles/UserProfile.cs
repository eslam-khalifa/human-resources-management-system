using AutoMapper;
using Demo.DataAccess.Entities.IdentityEntities;
using Demo.Presentation.ViewModels.UserViewModels;

namespace Demo.Presentation.MappingProfiles
{
    public class UserProfile : Profile
    {
        public UserProfile()
        {
            CreateMap<ApplicationUser, UserVM>()
                .ForMember(nameof(UserVM.Fname), options => options.MapFrom(src => src.FirstName))
                .ForMember(nameof(UserVM.Lname), options => options.MapFrom(src => src.LastName));

            CreateMap<UserVM, ApplicationUser>()
                .ForMember(nameof(ApplicationUser.FirstName), options => options.MapFrom(src => src.Fname))
                .ForMember(nameof(ApplicationUser.LastName), options => options.MapFrom(src => src.Lname));
        }
    }
}
