using policyInsurance.Entities.ViewModels;
using System.Threading.Tasks;

namespace policyInsurance.Data.Access
{
    public interface IAccessPolicyCreation
    {
        Task<string> Save(PolicySelectionViewModel model);
    }
}
