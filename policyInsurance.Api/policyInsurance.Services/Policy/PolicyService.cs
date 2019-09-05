using policyInsurance.Data.Access;
using policyInsurance.Entities.ViewModels;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace policyInsurance.Services.Policy
{
    public class PolicyService : IPolicyService
    {
        readonly IAccessPolicySelection _accessPolicySelection;
        readonly IAccessPolicyCreation _accessPolicyCreation;
        readonly IAccessPolicyEdition _accessPolicyEdition;
        readonly IAccessPolicyDeletion _accessPolicyDeletion;

        public PolicyService(IAccessPolicySelection accessPolicySelection, IAccessPolicyCreation accessPolicyCreation, IAccessPolicyEdition accessPolicyEdition, IAccessPolicyDeletion accessPolicyDeletion)
        {
            _accessPolicySelection = accessPolicySelection;
            _accessPolicyCreation = accessPolicyCreation;
            _accessPolicyEdition = accessPolicyEdition;
            _accessPolicyDeletion = accessPolicyDeletion;
        }

        public Task<IEnumerable<PolicySelectionViewModel>> Get()
        {
            try
            {
                return _accessPolicySelection.Get();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public Task<string> Create(PolicySelectionViewModel model)
        {
            try
            {
                return _accessPolicyCreation.Create(model);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public Task<string> Update(PolicySelectionViewModel model)
        {
            return _accessPolicyEdition.Update(model);
        }

        public Task Delete(int id)
        {
            return _accessPolicyDeletion.Delete(id);
        }
    }
}
