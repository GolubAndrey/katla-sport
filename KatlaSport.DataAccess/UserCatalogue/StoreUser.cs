using Microsoft.AspNet.Identity.EntityFramework;

namespace KatlaSport.DataAccess.UserCatalogue
{
    public class StoreUser : IdentityUser
    {
        public string FirstName { get; set; }

        public string LastName { get; set; }
    }
}
