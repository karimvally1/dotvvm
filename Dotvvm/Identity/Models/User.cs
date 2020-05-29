using Microsoft.AspNetCore.Identity;
using System.ComponentModel.DataAnnotations.Schema;

namespace Identity.Models
{
    public class User
    {
        public int Id { get; set; }

        public string AspNetUserId { get; set; }

        public string FirstName { get; set; }

        public string LastName { get; set; }

        public virtual ApplicationUser AspNetUser { get; set; }
    }
}
