using Microsoft.AspNet.Identity.EntityFramework;
using System;
using System.Threading.Tasks;

namespace KatlaSport.DataAccess.UserCatalogue
{
    public class UserContext : IUserContext
    {
        private bool _disposed = false;

        private readonly ApplicationDbContext _db;
        private readonly ApplicationUserManager _userManager;
        private readonly ApplicationRoleManager _roleManager;

        public UserContext()
        {
            _db = new ApplicationDbContext();

            _userManager = new ApplicationUserManager(new UserStore<StoreUser>(_db));

            _roleManager = new ApplicationRoleManager(new RoleStore<StoreRole>(_db));
        }

        public ApplicationUserManager UserManager => _userManager;

        public ApplicationRoleManager RoleManager => _roleManager;

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }

        public virtual void Dispose(bool disposing)
        {
            if (!_disposed)
            {
                if (disposing)
                {
                    _userManager.Dispose();
                    _roleManager.Dispose();
                    _db.Dispose();
                }

                _disposed = true;
            }
        }

        public async Task SaveChangesAsync()
        {
            await _db.SaveChangesAsync();
        }
    }
}
