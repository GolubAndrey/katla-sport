using KatlaSport.Services.UserManagement;
using System.Threading.Tasks;
using System.Web.Http;

namespace KatlaSport.WebApi.Controllers
{
    public class RoleController : ApiController
    {
        private readonly IUserService _userService;
        public RoleController(IUserService userService)
        {
            _userService = userService;
        }

        [HttpGet]
        [Route("api/GetAllRoles")]
        [AllowAnonymous]
        public async Task<IHttpActionResult> GetAllRoles()
        {
            var roles = await _userService.GetAllRoles();

            return Ok(roles);
        }
    }
}
