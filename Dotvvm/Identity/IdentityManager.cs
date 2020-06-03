using Microsoft.AspNetCore.Identity;
using Identity.Models;
using System.Linq;
using System.Threading.Tasks;
using Common.Enums;
using Common.Utilities;
using Service;

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
            var applicationUser = await _userManager.FindByNameAsync(userName);

            if (applicationUser == default(ApplicationUser))
                return null;

            var result = await _signInManager.PasswordSignInAsync(applicationUser, password, isPersistent, lockoutOnFailure);

            if (!result.Succeeded)
            {
                var signInResult = new Service.Values.SignInResult();
                signInResult.Succeeded = result.Succeeded;
                if (result.IsLockedOut)
                    signInResult.Error = SignInErrorEnum.IsLockedOut;
                else if (result.IsNotAllowed)
                    signInResult.Error = SignInErrorEnum.IsNotAllowed;
                else if (result.RequiresTwoFactor)
                    signInResult.Error = SignInErrorEnum.RequiresTwoFactor;
            }

            return new Service.Values.SignInResult
            {
                Succeeded = result.Succeeded
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
