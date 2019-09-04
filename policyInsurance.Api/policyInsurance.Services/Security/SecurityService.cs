using policyInsurance.Data.Access;
using policyInsurance.Entities.ViewModels;
using System.Threading.Tasks;

namespace policyInsurance.Services.Security
{
    public class SecurityService : ISecurityService
    {
        readonly IAccessSecurty _accessSecurity;

        public SecurityService(IAccessSecurty accessSecurity)
        {
            _accessSecurity = accessSecurity;
        }

        public Task<SecurityViewModel> Login(string userName, string passWord)
        {
            return _accessSecurity.Login(userName, passWord);
        }
    }
}
