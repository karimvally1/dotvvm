using System.ComponentModel.DataAnnotations;

namespace Web.Attributes
{
    public class CustomRequiredAttribute : RequiredAttribute
    {
        public CustomRequiredAttribute()
        {
            ErrorMessage = "This field is required.";
        }
    }
}
