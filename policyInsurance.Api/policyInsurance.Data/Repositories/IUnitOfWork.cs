using policyInsurance.Data.Models.Security;

namespace policyInsurance.Data.Repositories
{
    public interface IUnitOfWork
    {
        GenericRepository<AppIdentityUser> IdentityUserRepository { get; }
        GenericRepository<AppIdentityRole> IdentityRoleRepository { get; }
        GenericRepository<AppIdentityUserRoles> IdentityUserRolesRepository { get; }

        void Save();
    }
}
