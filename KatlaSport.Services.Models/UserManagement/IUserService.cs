using Microsoft.Owin.Security.OAuth;
using System.Collections.Generic;
using System.Security.Principal;
using System.Threading.Tasks;

namespace KatlaSport.Services.UserManagement
{
    public interface IUserService
    {
        Task<User> Register(RegisterModel user);

        Task Authenticate(OAuthGrantResourceOwnerCredentialsContext context);

        Task<List<RoleModel>> GetAllRoles();

        Task<User> GetUserClaims(IPrincipal user);
    }
}
