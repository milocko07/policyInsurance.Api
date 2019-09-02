using policyInsurance.Data.Models.Policy;
using policyInsurance.Entities.ViewModels;
using System.Threading.Tasks;

namespace policyInsurance.Data.Access
{
    public class AccessPolicyEdition : IAccessPolicyEdition
    {
        UnitOfWork unitofWork;

        public AccessPolicyEdition(UnitOfWork unitWork)
        {
            this.unitofWork = unitWork;
        }

        public Task<string> Update(PolicySelectionViewModel model)
        {
            Policy policyToUpdate = unitofWork.PolicyRepository.GetByID(model.Id);
            policyToUpdate.Name = model.Name;
            policyToUpdate.Description = model.Description;
            policyToUpdate.Opening = model.Opening;
            policyToUpdate.Coverage = model.Coverage;
            policyToUpdate.TimeCoverage = model.TimeCoverage;
            policyToUpdate.Price = model.Price;
            policyToUpdate.Type = unitofWork.PolicyTypeRepository.GetByID((int.Parse(model.Type)));
            policyToUpdate.Risk = unitofWork.PolicyRiskRepository.GetByID((int.Parse(model.Risk)));
            unitofWork.PolicyRepository.Update(policyToUpdate);
            var result = unitofWork.PolicyRepository.Save();

            if (result <= 0)
            {
                return Task.FromResult("Error updating");
            }
            else
            {
                return null;
            }
        }
    }
}
