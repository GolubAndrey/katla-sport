namespace KatlaSport.Services.UserManagement
{
    public class RegisterModel
    {
        public string UserName { get; set; }

        public string Password { get; set; }

        public string FirstName { get; set; }

        public string LastName { get; set; }

        public string[] Roles { get; set; }
    }
}
