namespace BusinessWorkManagementSystem.ViewModels
{
    public class AddUserViewModel
    {
        public string UserFirstName { get; set; }

        public string UserLastName { get; set; }

        public long UserContactNumber { get; set; }
        public int UserCreatedBy { get; set; }

      
        public DateTime UserCreatedOn { get; set; }

        public int UserUpdatedBy { get; set; }
        public DateTime UpdatedOn { get; set; }
        public bool Active { get; set; }
    }
}
