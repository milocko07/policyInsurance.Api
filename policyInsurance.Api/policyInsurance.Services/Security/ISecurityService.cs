using policyInsurance.Entities.ViewModels;
using System.Threading.Tasks;

namespace policyInsurance.Services.Security
{
    public interface ISecurityService
    {
        Task<SecurityViewModel> Login(string userName, string passWord);
    }
}
