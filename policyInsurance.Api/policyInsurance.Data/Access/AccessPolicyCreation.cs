using policyInsurance.Data.Models.Policy;
using policyInsurance.Data.Repositories;
using policyInsurance.Entities.ViewModels;
using System.Threading.Tasks;

namespace policyInsurance.Data.Access
{
    public class AccessPolicyCreation : IAccessPolicyCreation
    {
        IUnitOfWork unitofWork;

        public AccessPolicyCreation(IUnitOfWork unitWork)
        {
            this.unitofWork = unitWork;
        }

        public Task<string> Create(PolicySelectionViewModel model)
        {
            Policy newPolicy = new Policy();
            newPolicy.Name = model.Name;
            newPolicy.Description = model.Description;
            newPolicy.Opening = model.Opening;
            newPolicy.Coverage = model.Coverage;
            newPolicy.TimeCoverage = model.TimeCoverage;
            newPolicy.Price = model.Price;
            newPolicy.Type = unitofWork.PolicyTypeRepository.GetByID((int.Parse(model.Type)));
            newPolicy.Risk = unitofWork.PolicyRiskRepository.GetByID((int.Parse(model.Risk)));
            unitofWork.PolicyRepository.Insert(newPolicy);
            var result = unitofWork.PolicyRepository.Save();

            if (result <= 0)
            {
                return Task.FromResult("Error creating");
            }
            else
            {
                return null;
            }
        }
    }
}
