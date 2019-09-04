using AutoFixture;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using policyInsurance.Data.Access;
using policyInsurance.Data.Models.Policy;
using policyInsurance.Data.Models.Security;
using policyInsurance.Entities.ViewModels;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Xunit;

namespace policyInsurance.Tests
{
    [TestClass]
    public class PolicyAcessTests
    {
        public static Mock<DbSet<T>> CreateDbSetMock<T>(IEnumerable<T> elements) where T : class
        {
            var elementsAsQueryable = elements.AsQueryable();
            var dbSetMock = new Mock<DbSet<T>>();

            dbSetMock.As<IQueryable<T>>().Setup(m => m.Provider).Returns(elementsAsQueryable.Provider);
            dbSetMock.As<IQueryable<T>>().Setup(m => m.Expression).Returns(elementsAsQueryable.Expression);
            dbSetMock.As<IQueryable<T>>().Setup(m => m.ElementType).Returns(elementsAsQueryable.ElementType);
            dbSetMock.As<IQueryable<T>>().Setup(m => m.GetEnumerator()).Returns(elementsAsQueryable.GetEnumerator());

            return dbSetMock;
        }

        [Fact]
        public static void GetList_True()
        {
            var mock = new Mock<IAccessPolicySelection>();

            List<PolicySelectionViewModel> listPoliciesSelectionViewModel = new List<PolicySelectionViewModel>();

            listPoliciesSelectionViewModel.Add(new PolicySelectionViewModel
            {
                Id = 1,
                Name = "Policy 01"
            });

            listPoliciesSelectionViewModel.Add(new PolicySelectionViewModel
            {
                Id = 2,
                Name = "Policy 02"
            });

            mock.Setup(s => s.Get()).Returns(Task.FromResult(listPoliciesSelectionViewModel as IEnumerable<PolicySelectionViewModel>));
            Xunit.Assert.True(mock.Object.Get().Result.Count() == 2);  
            Xunit.Assert.True(mock.Object.Get().Result.FirstOrDefault().Id.ToString() == "1");
        }

        [Fact]
        public static void Create_Succesfully()
        {
            var mock = new Mock<IAccessPolicyCreation>();

            PolicySelectionViewModel model = new PolicySelectionViewModel()
            {
                Id = 3,
                Name = "Policy 03"
            };

            mock.Setup(s => s.Create(model));
            Xunit.Assert.True(mock.Object.Create(model).Result == null);
        }


        [Fact]
        public static void Create_Error()
        {
            var mock = new Mock<IAccessPolicyCreation>();

            PolicySelectionViewModel model = new PolicySelectionViewModel()
            {
                Id = 3,
                Name = "Policy 03"
            };

            mock.Setup(s => s.Create(model)).Returns(Task.FromResult("Error"));
            Xunit.Assert.True(mock.Object.Create(model).Result == "Error");
        }



        [Fact]
        public void TestUserMocking()
        {
            var fixture = new Fixture();
            //var lockedUser = fixture.Build<IdentityUser>().With(u => u.Email, "").Create();

            var user = new AppIdentityUser() { UserName = "User 01", Id = "1", Email = "user01@email.com", EmailConfirmed = false, PasswordHash = "123", PhoneNumber = "1234567", PhoneNumberConfirmed = false, TwoFactorEnabled = false, LockoutEnabled = false, AccessFailedCount = 0, Age = 31 };
            var role = new IdentityRole() { Id = "1", Name = "Role 01", NormalizedName = "1", ConcurrencyStamp = "fdf" };

            var listUsers = new List<AppIdentityUser>();
            listUsers.Add(user);

            var listRoles = new List<IdentityRole>();
            listRoles.Add(role);

            //var usersMock = CreateDbSetMock(listUsers);

            //var options = new DbContextOptionsBuilder<AppIdentityDbContext>()
            //                .Options;

            //var userContextMock = new Mock<AppIdentityDbContext>(options);
            //userContextMock.Setup(x => x.Users).Returns(usersMock.Object);
        }

        [Fact]
        public void TestPolicyMocking()
        {
            var type = new PolicyType { Id = 1, Name = "Fire" };
            var policy = new Policy() { Name = "Policy 01", Id = 1, Type = type };

            var listPolicies = new List<Policy>();
            listPolicies.Add(policy);

            //var policyMock = CreateDbSetMock(listPolicies);

            //var policyContextMock = new Mock<AppIdentityDbContext>();
            //policyContextMock.Setup(x => x.Policy).Returns(policyMock.Object);
        }
    }
}
