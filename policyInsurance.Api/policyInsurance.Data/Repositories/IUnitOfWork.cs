using policyInsurance.Data.Models.Clients;
using policyInsurance.Data.Models.Policy;
using policyInsurance.Data.Models.Security;
using System.Threading.Tasks;

namespace policyInsurance.Data.Repositories
{
    public interface IUnitOfWork
    {
        GenericRepository<AppIdentityUser> IdentityUserRepository { get; }
        GenericRepository<AppIdentityRole> IdentityRoleRepository { get; }
        GenericRepository<AppIdentityUserRoles> IdentityUserRolesRepository { get; }
        GenericRepository<Policy> PolicyRepository { get; }
        GenericRepository<PolicyType> PolicyTypeRepository { get; }
        GenericRepository<PolicyRisk> PolicyRiskRepository { get; }
        GenericRepository<Client> ClientRepository { get; }
        GenericRepository<PolicyClient> PolicyClientRepository { get; }

        void Save();
        Task SaveAsync();
    }
}
