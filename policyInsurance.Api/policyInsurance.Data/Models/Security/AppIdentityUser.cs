using Microsoft.AspNetCore.Identity;
using System.Collections.Generic;

namespace policyInsurance.Data.Models.Security
{
    public class AppIdentityUser : IdentityUser
    {
        public int? Age { get; set; }

    }
}
