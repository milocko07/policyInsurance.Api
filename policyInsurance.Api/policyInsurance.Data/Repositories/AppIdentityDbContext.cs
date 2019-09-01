using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using policyInsurance.Data.Models.Policy;
using policyInsurance.Data.Models.Security;

namespace policyInsurance.Data.Repositories
{
    public class AppIdentityDbContext : IdentityDbContext<AppIdentityUser, AppIdentityRole, string>
    {
        public AppIdentityDbContext(DbContextOptions<AppIdentityDbContext> options)
            : base(options)
        { }

        public DbSet<Policy> Policy { get; set; }

    }
}
