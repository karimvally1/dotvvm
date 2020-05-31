using System.Collections.Generic;

namespace Service.Values
{
    public class IdentityResult
    {
        public bool Succeeded { get; set; }
        public IdentityError[] Errors { get; set; }
    }
}
