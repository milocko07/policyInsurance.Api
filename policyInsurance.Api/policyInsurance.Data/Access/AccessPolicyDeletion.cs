using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace policyInsurance.Data.Access
{
    public class AccessPolicyDeletion : IAccessPolicyDeletion
    {
        UnitOfWork unitofWork;

        public AccessPolicyDeletion(UnitOfWork unitWork)
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
