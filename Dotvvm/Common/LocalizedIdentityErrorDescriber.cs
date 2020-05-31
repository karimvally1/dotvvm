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

        public override IdentityError PasswordRequiresDigit() { return new IdentityError { Code = nameof(PasswordRequiresDigit), Description = ResourceManager.GetString("PasswordRequiresDigit") }; }
        public override IdentityError PasswordRequiresLower() { return new IdentityError { Code = nameof(PasswordRequiresLower), Description = ResourceManager.GetString("PasswordRequiresLower") }; }
    }
}
