using AutoMapper;
using KatlaSport.DataAccess.UserCatalogue;
using Microsoft.Owin.Security;
using Microsoft.Owin.Security.OAuth;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Security.Principal;
using System.Threading.Tasks;

namespace KatlaSport.Services.UserManagement
{
    public class UserService : IUserService
    {
        private readonly DataAccess.UserCatalogue.IUserContext _userContext;

        public UserService(DataAccess.UserCatalogue.IUserContext userContext)
        {
            _userContext = userContext;
        }

        public async Task<User> Register(RegisterModel registerRequest)
        {
            StoreUser user = await _userContext.UserManager.FindByNameAsync(registerRequest.UserName);
            if (user != null)
            {
                throw new RequestedResourceHasConflictException("User with the same name already exists");
            }

            user = new StoreUser()
            {
                FirstName = registerRequest.FirstName,
                LastName = registerRequest.LastName,
                UserName = registerRequest.UserName,
            };

            await _userContext.UserManager.CreateAsync(user, registerRequest.Password);
            await _userContext.UserManager.AddToRolesAsync(user.Id, registerRequest.Roles);

            await _userContext.SaveChangesAsync();

            return Mapper.Map<User>(user);
        }

        public async Task Authenticate(OAuthGrantResourceOwnerCredentialsContext context)
        {
            StoreUser user = await _userContext.UserManager.FindAsync(context.UserName, context.Password);

            if (user != null)
            {
                var identity = new ClaimsIdentity(context.Options.AuthenticationType);
                identity.AddClaim(new Claim("Id", user.Id));
                identity.AddClaim(new Claim("UserName", user.UserName));
                identity.AddClaim(new Claim("FirstName", user.FirstName));
                identity.AddClaim(new Claim("LastName", user.LastName));

                var userRoles = await _userContext.UserManager.GetRolesAsync(user.Id);
                foreach (string role in userRoles)
                {
                    identity.AddClaim(new Claim(ClaimTypes.Role, role));
                }

                var additionalData = new AuthenticationProperties(new Dictionary<string, string> {
                {
                    "role", Newtonsoft.Json.JsonConvert.SerializeObject(userRoles)
                }
                });

                var token = new AuthenticationTicket(identity, additionalData);

                context.Validated(token);
            }
        }

        public async Task<User> GetUserClaims(IPrincipal user)
        {
            var identityClaims = user.Identity as ClaimsIdentity;

            var bla = identityClaims.Claims.FirstOrDefault(c => c.Type == "UserName");
            User model = new User()
            {
                Id = identityClaims.Claims.FirstOrDefault(c => c.Type == "Id").Value,
                UserName = identityClaims.Claims.FirstOrDefault(c => c.Type == "UserName").Value,
                FirstName = identityClaims.Claims.FirstOrDefault(c => c.Type == "FirstName").Value,
                LastName = identityClaims.Claims.FirstOrDefault(c => c.Type == "LastName").Value
            };

            return model;
        }

        public async Task<List<RoleModel>> GetAllRoles()
        {
            var roles = _userContext.RoleManager.Roles.Select(x => new RoleModel()
            {
                Id = x.Id,
                Role = x.Name
            }).ToList();

            return roles;
        }
    }
}
