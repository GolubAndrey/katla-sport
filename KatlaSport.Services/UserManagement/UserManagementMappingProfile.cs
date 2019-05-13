using AutoMapper;
using KatlaSport.DataAccess.UserCatalogue;

namespace KatlaSport.Services.UserManagement
{
    public sealed class UserManagementMappingProfile : Profile
    {
        public UserManagementMappingProfile()
        {
            CreateMap<StoreUser, User>()
                .ForMember(li => li.Password, opt => opt.MapFrom(p => p.PasswordHash));
        }
    }
}
