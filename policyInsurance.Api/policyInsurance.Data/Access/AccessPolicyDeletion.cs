using policyInsurance.Data.Repositories;
using System.Threading.Tasks;

namespace policyInsurance.Data.Access
{
    public class AccessPolicyDeletion : IAccessPolicyDeletion
    {
        IUnitOfWork unitofWork;

        public AccessPolicyDeletion(IUnitOfWork unitWork)
        {
            this.unitofWork = unitWork;
        }

        public Task Delete(int id)
        {
            unitofWork.PolicyRepository.Delete(id);
            unitofWork.Save();
            return Task.FromResult("");
        }
    }
}
