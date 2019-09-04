using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;
using policyInsurance.Data.Models.Security;
using policyInsurance.Data.Repositories;
using policyInsurance.Entities.ViewModels;
using policyInsurance.Services.Security;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace policyInsurance.WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SecurityController : Controller
    {
        private readonly ISecurityService _securityService;


        public SecurityController(
           UserManager<AppIdentityUser> userManager, RoleManager<AppIdentityRole> rolesManager, AppIdentityDbContext context, ISecurityService securityService)
        {
            _securityService = securityService;
        }

        [HttpPost]
        //[ValidateAntiForgeryToken]
        [EnableCors("CorsPolicy")]
        public async Task<IActionResult> LoginAsync([FromBody] LoginViewModel model)
        {
            if (model == null)
            {
                return BadRequest("Invalid client request");
            }

            if (!ModelState.IsValid)
                return View(model);


            var securityViewModel = await this._securityService.Login(model.Username, model.Password);

            if (securityViewModel != null)
            {
                var secretKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes("superSecretKey@345"));

                var signinCredentials = new SigningCredentials(secretKey, SecurityAlgorithms.HmacSha256);

                var claims = new List<Claim>
                {
                    new Claim(ClaimTypes.Name, securityViewModel.UserName),
                    new Claim(ClaimTypes.Role, securityViewModel.RoleName),
                    new Claim(ClaimTypes.Authentication, model.Password),
                };

                var tokeOptions = new JwtSecurityToken(
                    issuer: "http://localhost:5000",
                    audience: "http://localhost:5000",
                    claims: claims,
                    expires: DateTime.Now.AddMinutes(10),
                    signingCredentials: signinCredentials
                );

                securityViewModel.Token = new JwtSecurityTokenHandler().WriteToken(tokeOptions);

                return Ok(securityViewModel);
            }
            else
            {
                return Unauthorized();
            }
        }
    }
}