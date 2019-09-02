using policyInsurance.Entities.ViewModels;
using System.Threading.Tasks;

namespace policyInsurance.Data.Access
{
    public interface IAccessPolicyEdition
    {
        Task<string> Update(PolicySelectionViewModel model);
    }
}
