namespace Web.ViewModels
{
    public class RegisterViewModel : MasterPageViewModel
    {
        public string FirstName { get; set; }

        public string LastName { get; set; }

        public RegisterViewModel()
        {
            Title = "Create an account";
        }

        public void Create()
        {  

        }
    }
}

