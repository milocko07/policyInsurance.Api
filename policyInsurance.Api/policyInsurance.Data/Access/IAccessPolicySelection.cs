using policyInsurance.Entities.ViewModels;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace policyInsurance.Data.Access
{
    public interface IAccessPolicySelection
    {
        Task<IEnumerable<PolicySelectionViewModel>> Get();
    }
}
