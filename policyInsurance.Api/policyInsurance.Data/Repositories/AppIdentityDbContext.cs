using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using policyInsurance.Data.Models.Clients;
using policyInsurance.Data.Models.Policy;
using policyInsurance.Data.Models.Security;

namespace policyInsurance.Data.Repositories
{
    public class AppIdentityDbContext : IdentityDbContext<AppIdentityUser, AppIdentityRole, string>
    {
        public AppIdentityDbContext(DbContextOptions<AppIdentityDbContext> options)
            : base(options)
        { }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            // Data seeds
            modelBuilder.Entity<AppIdentityUser>().HasData(
               new AppIdentityUser() { Id = "1", UserName = "User 01", Email = "user01@email.com", EmailConfirmed = false, PasswordHash = "123", PhoneNumber = "1234567", PhoneNumberConfirmed = false, TwoFactorEnabled = false, LockoutEnabled = false, AccessFailedCount = 0, Age = 31 }
            );

            modelBuilder.Entity<AppIdentityRole>().HasData(
             new AppIdentityRole() { Id = "1", Name = "policies", NormalizedName = null, ConcurrencyStamp = null },
             new AppIdentityRole() { Id = "2", Name = "policies/assigments", NormalizedName = null, ConcurrencyStamp = null },
             new AppIdentityRole() { Id = "3", Name = "test", NormalizedName = null, ConcurrencyStamp = null }
             );

            modelBuilder.Entity<AppIdentityUserRoles>().HasData(
                new AppIdentityUserRoles() { UserId = "1", RoleId = "1" },
                new AppIdentityUserRoles() { UserId = "1", RoleId = "2" }
            );

            modelBuilder.Entity<PolicyType>().HasData(
                new PolicyType() { Id = 1, Name = "Earthquake" },
                new PolicyType() { Id = 2, Name = "Fire" },
                new PolicyType() { Id = 3, Name = "Robbery" },
                new PolicyType() { Id = 4, Name = "Lost" }
                );

            modelBuilder.Entity<PolicyRisk>().HasData(
                new PolicyRisk() { Id = 1, Name = "Low" },
                new PolicyRisk() { Id = 2, Name = "Medium" },
                new PolicyRisk() { Id = 3, Name = "Medium-High" },
                new PolicyRisk() { Id = 4, Name = "High" }
                );

            modelBuilder.Entity<Client>().HasData(
              new Client() { Id = 1, Name = "Client 01", LastName = "Client Lastname 01" },
              new Client() { Id = 2, Name = "Client 02", LastName = "Client Lastname 02" }
              );
        }

        public DbSet<Policy> Policy { get; set; }
    }
}
