using Common.Enums;
using Common.Utilities;
using Identity.Models;
using Microsoft.AspNetCore.Identity;
using Service.Interfaces;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
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

        public async Task<IList<string>> GetUserRoles(string userName)
        {
            var applicationUser = await _userManager.FindByNameAsync(userName);
            return await _userManager.GetRolesAsync(applicationUser);
        }

        public async Task AddClaims(string userName, IList<Claim> claims)
        {
            var applicationUser = await _userManager.FindByNameAsync(userName);   
            await _userManager.AddClaimsAsync(applicationUser, claims);
            await _signInManager.RefreshSignInAsync(applicationUser);
        }

        public async Task SignIn(string userName)
        {
            var user = await _userManager.FindByNameAsync(userName);
            await _signInManager.SignInAsync(user, true);
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

        public async Task SignOut()
        {
            await _signInManager.SignOutAsync();
        }

        public async Task<string> CreateEmailConfirmationToken(string userName)
        {
            var applicationUser = await _userManager.FindByNameAsync(userName);
            return await _userManager.GenerateEmailConfirmationTokenAsync(applicationUser);
        }

        public async Task<Service.Values.IdentityResult> ConfirmEmailToken(string userName, string token)
        {
            var applicationUser = await _userManager.FindByNameAsync(userName);
            var result = await _userManager.ConfirmEmailAsync(applicationUser, token);
         
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

        public async Task<bool> IsEmailConfirmed(string userName)
        {
            var applicationUser = await _userManager.FindByNameAsync(userName);
            return await _userManager.IsEmailConfirmedAsync(applicationUser);
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
