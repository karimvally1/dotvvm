namespace Service.Models
{
    public class User : Model
    {
        public string AspNetUserId { get; set; }
        public string Email { get; set; }
        public string UserName { get; set; }
        public string FirstName { get; set; } 
        public string LastName { get; set; }
    }
}
