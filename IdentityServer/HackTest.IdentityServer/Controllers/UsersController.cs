using HackTest.IdentityServer.DTOs;
using HackTest.IdentityServer.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System.Text;
using System.Threading.Tasks;

namespace HackTest.IdentityServer.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UsersController : ControllerBase
    {
        private readonly UserManager<ApplicationUser> _userManager;

        public UsersController(UserManager<ApplicationUser> userManager)
        {
            _userManager = userManager;
        }

        public async Task<IActionResult> SignUp(SignUpDto user)
        {
            if(ModelState.IsValid)
            {
                var newUser = new ApplicationUser
                {
                    Email = user.Email,
                    UserName = user.Email,
                    FirstName = user.FirstName,
                    LastName = user.LastName,
                };

                var result1 = await _userManager.CreateAsync(newUser, user.Password);

                var result2 = await _userManager.AddToRoleAsync(newUser, SeedData.Customer);

                if(!result1.Succeeded || !result2.Succeeded) 
                {   
                    return BadRequest(result1.Errors + "\n" + result2.Errors);
                }
            }

            return NoContent();
        }
    }
}
