using policyInsurance.Entities.ViewModels;
using System.Threading.Tasks;

namespace policyInsurance.Access
{
    interface IAccessSecurty
    {
        Task<SecurityViewModel> Login(string userName, string passWord);
    }
}
