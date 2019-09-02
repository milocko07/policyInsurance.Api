using policyInsurance.Entities.ViewModels;
using System.Threading.Tasks;

namespace policyInsurance.Data.Access
{
    public interface IAccessSecurty
    {
        Task<SecurityViewModel> Login(string userName, string passWord);
    }
}
