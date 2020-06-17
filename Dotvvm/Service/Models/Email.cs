using System;

namespace Service.Models
{
    public class Email : Model
    {
        public string From { get; set; }
        public string[] To { get; set; }
        public string Subject { get; set; }
        public string Body { get; set; }
        public DateTime Sent { get; set; }
        public User User { get; set; }
    }
}
