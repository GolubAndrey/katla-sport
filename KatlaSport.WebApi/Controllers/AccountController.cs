using KatlaSport.Services;
using KatlaSport.Services.UserManagement;
using Microsoft.Owin.Security;
using Swashbuckle.Swagger.Annotations;
using System.Net;
using System.Threading.Tasks;
using System.Web;
using System.Web.Http;

namespace KatlaSport.WebApi.Controllers
{
    [RoutePrefix("api/User")]
    public class AccountController : ApiController
    {
        private readonly IUserService _userService;

        public AccountController(IUserService userService)
        {
            _userService = userService;
        }

        [Route("Register")]
        [HttpPost]
        [AllowAnonymous]
        [SwaggerResponse(HttpStatusCode.BadRequest)]
        [SwaggerResponse(HttpStatusCode.Conflict)]
        [SwaggerResponse(HttpStatusCode.InternalServerError)]
        public async Task<IHttpActionResult> Register([FromBody] RegisterModel model)
        {
            try
            {
                var identity = await _userService.Register(model);

                return Ok(identity);
            }
            catch(RequestedResourceHasConflictException)
            {
                return BadRequest("User with the same name already exists");
            }
        }

        [Route("GetUserClaims")]
        [HttpGet]
        [SwaggerResponse(HttpStatusCode.NotFound)]
        [SwaggerResponse(HttpStatusCode.InternalServerError)]
        public async Task<IHttpActionResult> GetUserClaims([FromUri] LoginModel model)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var user = await _userService.GetUserClaims(User);

            return Ok(user);
        }

        private IAuthenticationManager AuthenticationManager
        {
            get
            {
                return HttpContext.Current.GetOwinContext().Authentication;
            }
        }
    }
}