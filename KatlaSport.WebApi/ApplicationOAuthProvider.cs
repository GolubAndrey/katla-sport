using KatlaSport.Services.UserManagement;
using Microsoft.Owin.Security.OAuth;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace KatlaSport.WebApi
{
    public class ApplicationOAuthProvider: OAuthAuthorizationServerProvider
    {
        private readonly IUserService _userService;

        public ApplicationOAuthProvider()
        {
        }

        public ApplicationOAuthProvider(IUserService userService)
        {
            _userService = userService;
        }

        public override async Task ValidateClientAuthentication(OAuthValidateClientAuthenticationContext context)
        {
            context.Validated();
        }

        public override async Task GrantResourceOwnerCredentials(OAuthGrantResourceOwnerCredentialsContext context)
        {
            await _userService.Authenticate(context);
        }

        public override Task TokenEndpoint(OAuthTokenEndpointContext context)
        {
            foreach (KeyValuePair<string, string> property in context.Properties.Dictionary)
            {
                context.AdditionalResponseParameters.Add(property.Key, property.Value);
            }

            return Task.FromResult<object>(null);
        }
    }
}