using Microsoft.AspNetCore.Identity;
using System.Collections.Generic;

namespace policyInsurance.Data.Models.Security
{
    public class AppIdentityUser : IdentityUser
    {
        public int? Age { get; set; }

        public virtual ICollection<policyInsurance.Data.Models.Policy.Policy> Policies { get; set; }
    }
}
