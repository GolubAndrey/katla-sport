namespace KatlaSport.Services.UserManagement
{
    public class User
    {
        public string Id { get; set; }

        public string UserName { get; set; }

        public string Password { get; set; }

        public string FirstName { get; set; }

        public string LastName { get; set; }

        public string[] Roles { get; set; }
    }
}
