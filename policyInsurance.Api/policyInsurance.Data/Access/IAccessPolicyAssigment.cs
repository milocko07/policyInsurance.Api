using policyInsurance.Entities.ViewModels;
using System.Threading.Tasks;

namespace policyInsurance.Data.Access
{
    public interface IAccessPolicyAssigment
    {
        Task<string> Assign(PolicyAssignationViewModel model);
        Task<string> Cancel(PolicyAssignationViewModel model);
        Task<bool> Validate(PolicyAssignationViewModel model);
        Task<bool> ValidateAssignation(PolicyAssignationViewModel model);
    }
}
