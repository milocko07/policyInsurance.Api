using policyInsurance.Data.Models.Clients;

namespace policyInsurance.Data.Models.Policy
{
    public class PolicyClient
    {
        public int Id { get; set; }
        public int PolicyId { get; set; }
        public virtual Policy Policy { get; set; }
        public int ClientId { get; set; }
        public virtual Client Client { get; set; }
    }
}
