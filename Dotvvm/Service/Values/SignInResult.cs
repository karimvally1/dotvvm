using Common.Enums;

namespace Service.Values
{
    public class SignInResult
    {
        public bool Succeeded { get; set; }
        public SignInErrorEnum Error { get; set; }
    }
}
