namespace Web.ViewModels
{
	public class DefaultViewModel : MasterPageViewModel
    {
        public string FirstName { get; set; }

        public string LastName { get; set; }

        public DefaultViewModel()
        {
            Title = "Default";
        }

        public void SetName()
        {
            FirstName = "Karim";
            LastName = "Vally";
        }
    }
}
