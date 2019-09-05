using policyInsurance.Data.Models.Policy;
using policyInsurance.Data.Repositories;
using policyInsurance.Entities.ViewModels;
using System.Collections.Generic;
using System.Threading.Tasks;
using System.Linq;

namespace policyInsurance.Data.Access
{
    public class AccessPolicySelection : IAccessPolicySelection
    {
        IUnitOfWork unitofWork;

        public AccessPolicySelection(IUnitOfWork unitWork)
        {
            this.unitofWork = unitWork;
        }

        public Task<IEnumerable<PolicySelectionViewModel>> Get()
        {
            List<Policy> listPolicies = unitofWork.PolicyRepository.Get(null, null, "Type,Risk,PolicyClients") as List<Policy>;
            List<PolicySelectionViewModel> listPoliciesSelectionViewModel = new List<PolicySelectionViewModel>();
            if (listPolicies != null && listPolicies.Count > 0)
            {
                foreach (var policy in listPolicies)
                {
                    var listClients = policy.PolicyClients.Select(pc => pc.ClientId);
                    var clientNamesList = new List<string>();
                    foreach (var client in listClients)
                    {
                        clientNamesList.Add(unitofWork.ClientRepository.GetByID(client).Name);
                    }
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
                        ClientsAssigned = policy.PolicyClients.Any() ? string.Join(", ", clientNamesList) : ""
                    });
                }
            }

            return Task.FromResult(listPoliciesSelectionViewModel as IEnumerable<PolicySelectionViewModel>);
        }
    }
}
