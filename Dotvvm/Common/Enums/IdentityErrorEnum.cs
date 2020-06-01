using Common.Resources;
using System;

namespace Common.Enums
{
    public enum IdentityErrorEnum
    {
        PasswordRequiresDigit,
        PasswordRequiresLower,
        PasswordRequiresNonAlphanumeric,
        PasswordRequiresUpper,
        PasswordTooShort,
        UserAlreadyHasPassword,
        PasswordMismatch,
        InvalidUserName,
        DuplicateUserName,
        InvalidEmail,
        DuplicateEmail,
        InvalidRoleName,
        DuplicateRoleName,
        UserAlreadyInRole,
        UserNotInRole
    }
}  
