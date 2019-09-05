using policyInsurance.Entities.ViewModels;
using System.Threading.Tasks;

namespace policyInsurance.Services.Policy
{
    public interface IPolicyAssigmentService
    {
        Task<string> Assign(PolicyAssignationViewModel model);
        Task<string> Cancel(PolicyAssignationViewModel model);
    }
}
