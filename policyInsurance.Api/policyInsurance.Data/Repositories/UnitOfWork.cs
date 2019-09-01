using policyInsurance.Data.Models.Security;
using policyInsurance.Data.Repositories;

namespace policyInsurance.Data
{

    public class UnitOfWork : IUnitOfWork
    {
        private readonly AppIdentityDbContext _identityContext;

        private GenericRepository<AppIdentityUser> _identityUserRepository;
        private GenericRepository<AppIdentityRole> _identityRoleRepository;
        private GenericRepository<AppIdentityUserRoles> _identityUserRolesRepository;

        public UnitOfWork(AppIdentityDbContext _context)
        {
            _identityContext = _context;
        }

        public GenericRepository<AppIdentityUser> IdentityUserRepository
        {
            get
            {
                return _identityUserRepository = _identityUserRepository ?? new GenericRepository<AppIdentityUser>(_identityContext);
            }
        }

        public GenericRepository<AppIdentityRole> IdentityRoleRepository
        {
            get
            {
                return _identityRoleRepository = _identityRoleRepository ?? new GenericRepository<AppIdentityRole>(_identityContext);
            }
        }

        public GenericRepository<AppIdentityUserRoles> IdentityUserRolesRepository
        {
            get
            {
                return _identityUserRolesRepository = _identityUserRolesRepository ?? new GenericRepository<AppIdentityUserRoles>(_identityContext);
            }
        }

        public void Save()
        {
            _identityContext.SaveChanges();
        }
    }
}
