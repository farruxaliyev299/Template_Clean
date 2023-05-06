using HackTest.IdentityServer.Data;
using HackTest.IdentityServer.Models;
using IdentityModel;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore.Internal;
using System.Security.Claims;

namespace HackTest.IdentityServer.Initialize
{
    public class DbInitialize : IDbInitialize
    {
        private readonly ApplicationDbContext _db;
        private readonly UserManager<ApplicationUser> _userManager;
        private readonly RoleManager<IdentityRole> _roleManager;

        public DbInitialize(
            ApplicationDbContext db,
            UserManager<ApplicationUser> userManager,
            RoleManager<IdentityRole> roleManager)
        {
            _db = db;
            _roleManager = roleManager;
            _userManager = userManager;
        }

        public void Initialize()
        {
            if (_roleManager.FindByNameAsync(SeedData.Admin).Result == null)
            {
                _roleManager.CreateAsync(new IdentityRole(SeedData.Admin)).GetAwaiter().GetResult();
                _roleManager.CreateAsync(new IdentityRole(SeedData.Customer)).GetAwaiter().GetResult();
            }
            else { return; }

            if (!_userManager.Users.Any())
            {
                ApplicationUser adminUser = new ApplicationUser()
                {
                    UserName = "admin1@gmail.com",
                    Email = "admin1@gmail.com",
                    EmailConfirmed = true,
                    PhoneNumber = "111111111111",
                    FirstName = "Admin",
                    LastName = "FullPermission"
                };

                _userManager.CreateAsync(adminUser, "Admin12*").GetAwaiter().GetResult();
                _userManager.AddToRoleAsync(adminUser, SeedData.Admin).GetAwaiter().GetResult();

                var temp1 = _userManager.AddClaimsAsync(adminUser, new Claim[] {
                    new Claim(JwtClaimTypes.GivenName,adminUser.FirstName),
                    new Claim(JwtClaimTypes.FamilyName,adminUser.LastName),
                    new Claim(JwtClaimTypes.Role,SeedData.Admin)
                }).Result;

                ApplicationUser customerUser = new ApplicationUser()
                {
                    UserName = "customer1@gmail.com",
                    Email = "customer1@gmail.com",
                    EmailConfirmed = true,
                    PhoneNumber = "111111111111",
                    FirstName = "Customer",
                    LastName = "SomePermission"
                };

                _userManager.CreateAsync(customerUser, "Customer12*").GetAwaiter().GetResult();
                _userManager.AddToRoleAsync(customerUser, SeedData.Customer).GetAwaiter().GetResult();

                var temp2 = _userManager.AddClaimsAsync(customerUser, new Claim[] {
                    new Claim(JwtClaimTypes.GivenName,customerUser.FirstName),
                    new Claim(JwtClaimTypes.FamilyName,customerUser.LastName),
                    new Claim(JwtClaimTypes.Role,SeedData.Customer),
                }).Result;
            }

        }
    }
}
