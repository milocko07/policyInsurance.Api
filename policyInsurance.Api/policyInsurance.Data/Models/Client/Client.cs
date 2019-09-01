using policyInsurance.Data.Models.Policy;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace policyInsurance.Data.Models.Client
{
    public class Client
    {
        public int Id { get; set; }

        [Required]
        [StringLength(60)]
        public string Name { get; set; }

        [Required]
        [StringLength(60)]
        public string LastName { get; set; }

        public ICollection<PolicyClient> PolicyClients { get; set; }
    }
}
