using System.ComponentModel.DataAnnotations.Schema;

namespace Identity.Models
{
    public class User
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

        [ForeignKey("AspNetUser")]
        public string AspNetUserId { get; set; }

        public string FirstName { get; set; }

        public string LastName { get; set; }

        public virtual ApplicationUser AspNetUser { get; set; }
    }
}
