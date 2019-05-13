using System;
using System.Threading.Tasks;

namespace KatlaSport.DataAccess.UserCatalogue
{
    public interface IUserContext: IDisposable
    {
        ApplicationUserManager UserManager { get; }

        ApplicationRoleManager RoleManager { get; }

        Task SaveChangesAsync();
    }
}
