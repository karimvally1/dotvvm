using Common.Enums;
using Common.Utilities;
using Identity.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Service.Interfaces;
using System.Linq;
using System.Threading.Tasks;

namespace Identity
{
    public class IdentityManager : IIdentityManager
    {
        private readonly UserManager<ApplicationUser> _userManager;
        private readonly SignInManager<ApplicationUser> _signInManager;

        public IdentityManager(UserManager<ApplicationUser> userManager, SignInManager<ApplicationUser> signInManager)
        {
            _userManager = userManager;
            _signInManager = signInManager;
        }

        public async Task<Service.Values.SignInResult> PasswordSignIn(string userName, string password, bool isPersistent, bool lockoutOnFailure)
        {
            var result = await _signInManager.PasswordSignInAsync(userName, password, isPersistent, lockoutOnFailure);
            return new Service.Values.SignInResult
            {
                Succeeded = result.Succeeded,
                IsLockedOut = result.IsLockedOut,
                IsNotAllowed = result.IsNotAllowed,
                RequiresTwoFactor = result.RequiresTwoFactor
            };
        }

        public async Task<Service.Values.IdentityResult> Create(Service.Models.User user, string password)
        {
            var applicationUser = new ApplicationUser
            {
                Email = user.Email,
                UserName = user.UserName,
                User = new User
                {
                    FirstName = user.FirstName,
                    LastName = user.LastName
                }
            };

            var result = await _userManager.CreateAsync(applicationUser, password);

            return new Service.Values.IdentityResult
            {
                Succeeded = result.Succeeded,
                Errors = result.Errors.Select(e => new Service.Values.IdentityError
                {
                    Error = EnumHelper.FromString<IdentityErrorEnum>(e.Code),
                    Description = e.Description
                }).ToArray()
            };
        }
    }
}
