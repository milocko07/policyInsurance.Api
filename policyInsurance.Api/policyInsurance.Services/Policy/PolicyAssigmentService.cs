using policyInsurance.Data.Access;
using policyInsurance.Entities.ViewModels;
using System;
using System.Threading.Tasks;

namespace policyInsurance.Services.Policy
{
    public class PolicyAssigmentService : IPolicyAssigmentService
    {
        readonly IAccessPolicyAssigment _accessPolicyAssigment;

        public PolicyAssigmentService(IAccessPolicyAssigment accessPolicyAssigment)
        {
            _accessPolicyAssigment = accessPolicyAssigment;
        }

        public async Task<string> Assign(PolicyAssignationViewModel model)
        {
            try
            {
                var validate = await _accessPolicyAssigment.Validate(model);
                var validateAssignation = await _accessPolicyAssigment.ValidateAssignation(model);

                if (validate)
                {
                    if (!validateAssignation)
                    {
                        return await _accessPolicyAssigment.Assign(model);
                    }
                    else
                    {
                        throw new Exception("Policy was assigned previously to the selected client");
                    }
                }
                else
                {
                    throw new Exception("Policy or Client do not exist");
                }
            }
            catch (Exception)
            {
                throw;
            }
        }

        public async Task<string> Cancel(PolicyAssignationViewModel model)
        {
            try
            {
                var validate = await _accessPolicyAssigment.Validate(model);
                var validateAssignation = await _accessPolicyAssigment.ValidateAssignation(model);

                if (validate && validateAssignation)
                {
                    return await _accessPolicyAssigment.Cancel(model);
                }
                else
                {
                    throw new Exception("Policy or Client do not exist");
                }
            }
            catch (Exception)
            {
                throw;
            }
        }
    }
}
