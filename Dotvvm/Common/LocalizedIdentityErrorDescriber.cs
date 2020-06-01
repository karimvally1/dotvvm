using Common.Resources;
using Microsoft.AspNetCore.Identity;
using System.Resources;

namespace Common
{
    public class LocalizedIdentityErrorDescriber : IdentityErrorDescriber
    {
        private ResourceManager ResourceManager { get; set; }

        public LocalizedIdentityErrorDescriber()
        {
            ResourceManager = IdentityErrors.ResourceManager;
        }

        #region Passwords

        public override IdentityError PasswordRequiresDigit() { return new IdentityError { Code = nameof(PasswordRequiresDigit), Description = IdentityErrors.PasswordRequiresDigit }; }
        public override IdentityError PasswordRequiresLower() { return new IdentityError { Code = nameof(PasswordRequiresLower), Description = IdentityErrors.PasswordRequiresLower }; }
        public override IdentityError PasswordRequiresNonAlphanumeric() { return new IdentityError { Code = nameof(PasswordRequiresNonAlphanumeric), Description = IdentityErrors.PasswordRequiresNonAlphanumeric }; }
        public override IdentityError PasswordRequiresUpper() { return new IdentityError { Code = nameof(PasswordRequiresUpper), Description = IdentityErrors.PasswordRequiresUpper }; }
        public override IdentityError PasswordTooShort(int length) { return new IdentityError { Code = nameof(PasswordTooShort), Description = IdentityErrors.PasswordTooShort }; }
        public override IdentityError PasswordMismatch() { return new IdentityError { Code = nameof(PasswordMismatch), Description = IdentityErrors.PasswordMismatch }; }
        public override IdentityError UserAlreadyHasPassword() { return new IdentityError { Code = nameof(UserAlreadyHasPassword), Description = IdentityErrors.UserAlreadyHasPassword }; }

        #endregion

        #region Usernames
        public override IdentityError InvalidUserName(string userName) { return new IdentityError { Code = nameof(InvalidUserName), Description = string.Format(IdentityErrors.InvalidUserName, userName) }; }
        public override IdentityError DuplicateUserName(string userName) { return new IdentityError { Code = nameof(DuplicateUserName), Description = string.Format(IdentityErrors.DuplicateUserName, userName) }; }
        #endregion

        #region Emails
        public override IdentityError InvalidEmail(string email) { return new IdentityError { Code = nameof(InvalidEmail), Description = string.Format(IdentityErrors.InvalidEmail, email) }; }
        public override IdentityError DuplicateEmail(string email) { return new IdentityError { Code = nameof(DuplicateEmail), Description = string.Format(IdentityErrors.DuplicateEmail,email) }; }
        #endregion

        #region Roles
        public override IdentityError InvalidRoleName(string role) { return new IdentityError { Code = nameof(InvalidRoleName), Description = string.Format(IdentityErrors.InvalidRoleName, role) }; }
        public override IdentityError DuplicateRoleName(string role) { return new IdentityError { Code = nameof(DuplicateRoleName), Description = string.Format(IdentityErrors.DuplicateRoleName, role) }; }
        public override IdentityError UserAlreadyInRole(string role) { return new IdentityError { Code = nameof(UserAlreadyInRole), Description = string.Format(IdentityErrors.UserAlreadyInRole, role) }; }
        public override IdentityError UserNotInRole(string role) { return new IdentityError { Code = nameof(UserNotInRole), Description = string.Format(IdentityErrors.UserNotInRole, role) }; }
        #endregion

        #region Other

        #endregion
    }
}
