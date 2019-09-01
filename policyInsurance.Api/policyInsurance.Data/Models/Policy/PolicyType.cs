using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace policyInsurance.Data.Models.Policy
{
    public class PolicyType
    {
        public int Id { get; set; }

        [Required]
        [StringLength(60)]
        public string Name { get; set; }
      
        public virtual ICollection<Policy> Policies { get; set; }
    }
}
