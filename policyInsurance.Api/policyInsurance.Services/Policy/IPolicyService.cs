using policyInsurance.Entities.ViewModels;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace policyInsurance.Services.Policy
{
    public interface IPolicyService
    {
        Task<IEnumerable<PolicySelectionViewModel>> Get();

        Task<string> Create(PolicySelectionViewModel model);

        Task<string> Update(PolicySelectionViewModel model);

        Task Delete(int id);
    }
}
