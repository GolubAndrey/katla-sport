using Microsoft.AspNet.Identity;

namespace KatlaSport.DataAccess.UserCatalogue
{
    public class ApplicationUserManager : UserManager<StoreUser>
    {
        public ApplicationUserManager(IUserStore<StoreUser> store)
                : base(store)
        {
        }
    }
}
