using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using policyInsurance.Data.Access;
using policyInsurance.Data.Models.Policy;
using policyInsurance.Entities.ViewModels;
using policyInsurance.Services.Policy;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace policyInsurance.Tests
{
    public class PolicyServiceTest
    {
        private readonly Mock<IAccessPolicySelection> _mockPolicySelection;
        private readonly Mock<IAccessPolicyCreation> _mockPolicyCreation;
        private readonly Mock<IAccessPolicyEdition> _mockPolicyEdition;
        private readonly Mock<IAccessPolicyDeletion> _mockPolicyDeletion;

        public PolicyServiceTest()
        {
            _mockPolicySelection = new Mock<IAccessPolicySelection>();
            _mockPolicyCreation = new Mock<IAccessPolicyCreation>();
            _mockPolicyEdition = new Mock<IAccessPolicyEdition>();
            _mockPolicyDeletion = new Mock<IAccessPolicyDeletion>();
        }

        [Fact, Trait("Category", "Unit")]
        public async Task SelectPoliciesSuccess()
        {
            IList<PolicySelectionViewModel> _testPolicies = new List<PolicySelectionViewModel> {
                new PolicySelectionViewModel() {
                    Id = 1,
                    Name = "Policy 01"
                },
                new PolicySelectionViewModel() {
                    Id = 2,
                    Name = "Policy 02"
                }
            };

            _mockPolicySelection.Setup(s => s.Get())
                .Returns(Task.FromResult(_testPolicies as IEnumerable<PolicySelectionViewModel>));

            var service = BuildPolicyService();

            var result = await service.Get();

            var list = result as List<PolicySelectionViewModel>;
            Xunit.Assert.NotNull(result);
            Xunit.Assert.True(list.Count == 2);
            Xunit.Assert.Equal(1, list[0].Id);
        }

        [Fact, Trait("Category", "Unit")]
        public async Task SelectPoliciesReturnsNull()
        {
            _mockPolicySelection.Setup(s => s.Get())
               .Throws(new Exception("Error!"));

            var service = BuildPolicyService();

            await Xunit.Assert.ThrowsAsync<Exception>(() => service.Get());

        }

        private PolicyService BuildPolicyService()
        {
            return new PolicyService(_mockPolicySelection.Object, _mockPolicyCreation.Object, _mockPolicyEdition.Object, _mockPolicyDeletion.Object);
        }

    }
}
