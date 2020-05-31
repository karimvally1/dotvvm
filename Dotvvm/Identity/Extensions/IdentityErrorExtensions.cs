using Common.Enums;
using Microsoft.AspNetCore.Identity;
using System;

namespace Identity.Extensions
{
    public static class IdentityErrorExtensions
    {
        public static IdentityErrorEnum GetEnum(this IdentityError identityError) =>
        identityError.Code switch
        {
            "PasswordRequiresDigit" => IdentityErrorEnum.PasswordRequiresDigit,
            "PasswordRequiresLower" => IdentityErrorEnum.PasswordRequiresLower,
            "PasswordRequiresNonAlphanumeric" => IdentityErrorEnum.PasswordRequiresNonAlphanumeric,
            "PasswordRequiresUpper" => IdentityErrorEnum.PasswordRequiresUpper,
            _ => throw new ArgumentException(message: "Identity error not supported.", paramName: nameof(identityError.Code)),
        };
    }
}
