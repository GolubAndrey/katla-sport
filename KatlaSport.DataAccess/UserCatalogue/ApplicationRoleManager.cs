using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;

namespace KatlaSport.DataAccess.UserCatalogue
{
    public class ApplicationRoleManager : RoleManager<StoreRole>
    {
        public ApplicationRoleManager(RoleStore<StoreRole> store)
            : base(store)
        { }
    }
}
