using System.Threading.Tasks;

namespace policyInsurance.Data.Access
{
    public interface IAccessPolicyDeletion
    {
        Task Delete(int id);
    }
}
