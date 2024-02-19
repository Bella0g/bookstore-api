namespace UserModel
{
    public class User
    {
        public int UserId { get; set; }
        public string Email { get; set; }
        public string Username { get; set; }
        public string Password { get; set; }

        public User(int userId, string email, string username, string password)
        {
            UserId = userId;
            Email = email;
            Username = username;
            Password = password;
        }
    }
}