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

        public override IdentityError PasswordRequiresDigit() { return new IdentityError { Code = nameof(PasswordRequiresDigit), Description = IdentityErrors.PasswordRequiresDigit }; }
        public override IdentityError PasswordRequiresLower() { return new IdentityError { Code = nameof(PasswordRequiresLower), Description = IdentityErrors.PasswordRequiresLower }; }
        public override IdentityError PasswordRequiresNonAlphanumeric() { return new IdentityError { Code = nameof(PasswordRequiresNonAlphanumeric), Description = IdentityErrors.PasswordRequiresNonAlphanumeric }; }
        public override IdentityError PasswordRequiresUpper() { return new IdentityError { Code = nameof(PasswordRequiresUpper), Description = IdentityErrors.PasswordRequiresUpper }; }

    }
}
