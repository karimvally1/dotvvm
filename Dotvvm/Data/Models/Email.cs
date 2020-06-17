using Identity.Models;
using System;
using System.ComponentModel.DataAnnotations.Schema;

namespace Data.Models
{
    public class Email
    {
        public int Id { get; set; }

        [ForeignKey("User")]
        public int UserId { get; set;  }

        public string From { get; set; }

        public string To { get; set; }

        public string Subject { get; set; }

        public string Body { get; set; }

        public DateTime Sent { get; set; }

        public User User { get; }
    }
}
