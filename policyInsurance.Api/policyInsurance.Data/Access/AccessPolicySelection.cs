using policyInsurance.Data.Models.Policy;
using policyInsurance.Entities.ViewModels;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace policyInsurance.Data.Access
{
    public class AccessPolicySelection : IAccessPolicySelection
    {
        UnitOfWork unitofWork;

        public AccessPolicySelection(UnitOfWork unitWork)
        {
            this.unitofWork = unitWork;
        }

        Task<IEnumerable<PolicySelectionViewModel>> IAccessPolicySelection.Get()
        {
            List<Policy> listPolicies = unitofWork.PolicyRepository.Get(null, null, "Type,Risk") as List<Policy>;
            List<PolicySelectionViewModel> listPoliciesSelectionViewModel = new List<PolicySelectionViewModel>();
            if (listPolicies != null && listPolicies.Count > 0)
            {
                foreach (var policy in listPolicies)
                {
                    listPoliciesSelectionViewModel.Add(new PolicySelectionViewModel
                    {
                        Id = policy.Id,
                        Name = policy.Name,
                        Description = policy.Description,
                        Opening = policy.Opening,
                        Coverage = policy.Coverage,
                        TimeCoverage = policy.TimeCoverage,
                        Price = policy.Price,
                        TypeId = policy.Type.Id,
                        Type = policy.Type.Name,
                        RiskId = policy.Risk.Id,
                        Risk = policy.Risk.Name,
                    });
                }
            }

            return Task.FromResult(listPoliciesSelectionViewModel as IEnumerable<PolicySelectionViewModel>);
        }
    }
}
