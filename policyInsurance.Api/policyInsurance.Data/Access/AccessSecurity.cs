using Microsoft.AspNetCore.Identity;
using policyInsurance.Data.Models.Security;
using policyInsurance.Data.Repositories;
using policyInsurance.Entities.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace policyInsurance.Data.Access
{
    public class AccessSecurity : IAccessSecurty
    {
        UserManager<AppIdentityUser> userManager;
        RoleManager<AppIdentityRole> rolesManager;
        IUnitOfWork unitofWork;

        public AccessSecurity(UserManager<AppIdentityUser> userManager, RoleManager<AppIdentityRole> rolesManager, IUnitOfWork unitWork)
        {
            this.userManager = userManager;
            this.rolesManager = rolesManager;
            this.unitofWork = unitWork;
        }

        public async Task<SecurityViewModel> Login(string userName, string passWord)
        {
            try
            {
                //var user = this.userManager.Users.FirstOrDefault(f => f.UserName == userName && f.PasswordHash == passWord);
                var user = unitofWork.IdentityUserRepository.Get(f => f.UserName == userName && f.PasswordHash == passWord);

                if (user != null && user.Any())
                {
                    var rolesUser = await this.userManager.GetRolesAsync(user.First());
                    //var roles2 = this.rolesManager.Roles.FirstOrDefault(r => r.Name == roles.FirstOrDefault());

                    var menuList = new List<MenuViewModel>();

                    foreach (var role in rolesUser)
                    {
                        menuList.Add(new MenuViewModel
                        {
                            name = role.Split("/").Count() == 2 ? role.Split("/")[1] : role,
                            url = "/" + role,
                            icon = "icon-speedometer",
                        });
                    }

                    return new SecurityViewModel { UserName = user.First().UserName, RoleName = rolesUser.FirstOrDefault(), MenuList = menuList };
                }
                else
                {
                    return null;
                }
            }
            catch (Exception ex)
            {
                throw;
            }
        }
    }
}
