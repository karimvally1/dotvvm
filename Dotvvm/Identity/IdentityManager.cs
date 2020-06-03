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

        public async Task<Service.Models.User> FindByUserName(string userName)
        {
            var applicationUser = await _userManager.FindByNameAsync(userName);

            if (applicationUser == default(ApplicationUser))
                return null;

            return MapApplicationUserToUser(applicationUser);
        }

        public async Task<Service.Models.User> FindByEmail(string email)
        {
            var applicationUser = await _userManager.FindByEmailAsync(email);

            if (applicationUser == default(ApplicationUser))
                return null;

            return MapApplicationUserToUser(applicationUser);
        }

        public async Task<Service.Values.SignInResult> CheckPassword(string userName, string password, bool isPersistent, bool lockoutOnFailure)
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
                User = new Models.User
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

        private Service.Models.User MapApplicationUserToUser(ApplicationUser applicationUser)
        {
            return new Service.Models.User
            {
                AspNetUserId = applicationUser.Id,
                Id = applicationUser.User.Id,
                Email = applicationUser.Email,
                UserName = applicationUser.UserName,
                FirstName = applicationUser.User.FirstName,
                LastName = applicationUser.User.LastName
            };
        }
    }
}
