using policyInsurance.Data.Models.Policy;
using policyInsurance.Data.Repositories;
using policyInsurance.Entities.ViewModels;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using System.Linq;

namespace policyInsurance.Data.Access
{
    public class AccessPolicyAssigment : IAccessPolicyAssigment
    {
        IUnitOfWork unitofWork;

        public AccessPolicyAssigment(IUnitOfWork unitWork)
        {
            this.unitofWork = unitWork;
        }

        public async Task<string> Assign(PolicyAssignationViewModel model)
        {
            var policy = unitofWork.PolicyRepository.GetByID(model.IdPolicy);
            var client = unitofWork.ClientRepository.GetByID(model.IdClient);

            PolicyClient newPolicyCliet = new PolicyClient();
            newPolicyCliet.Policy = policy;
            newPolicyCliet.Client = client;

            unitofWork.PolicyClientRepository.Insert(newPolicyCliet);
            var result = await unitofWork.PolicyClientRepository.SaveAsync();

            if (result <= 0)
            {
                throw new Exception("Error creating");
            }
            else
            {
                return null;
            }
        }
       
        public async Task<string> Cancel(PolicyAssignationViewModel model)
        {
            var policyClientToDelete = unitofWork.PolicyClientRepository.Get(pc => pc.PolicyId == model.IdPolicy && pc.ClientId == model.IdClient) as List<PolicyClient>;

            unitofWork.PolicyClientRepository.Delete(policyClientToDelete[0].Id);
            var result = await unitofWork.PolicyClientRepository.SaveAsync();

            if (result <= 0)
            {
                throw new Exception("Error deleting");
            }
            else
            {
                return null;
            }
        }

        public async Task<bool> Validate(PolicyAssignationViewModel model)
        {
            var policy = await unitofWork.PolicyRepository.GetByIDAsync(model.IdPolicy);
            var client = await unitofWork.ClientRepository.GetByIDAsync(model.IdClient);

            if (policy == null || client == null)
            {
                return false;
            }
            else
            {
                return true;
            }
        }

        public async Task<bool> ValidateAssignation(PolicyAssignationViewModel model)
        {
            var policyClientExist = unitofWork.PolicyClientRepository.Get(pc => pc.PolicyId == model.IdPolicy && pc.ClientId == model.IdClient);

            if (policyClientExist == null || policyClientExist.Count() <= 0)
            {
                return false;
            }
            else
            {
                return true;
            }
        }
    }
}
