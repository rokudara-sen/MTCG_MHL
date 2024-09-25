using MTCG_MHL.Models.Player;

namespace MTCG_MHL.DataAccess.Repositories
{
    public class UserRepository
    {
        // In-memory user storage for simplicity
        private readonly Dictionary<string, string> _users = new();  // Username -> Password

        // Method to check if a user exists
        public bool UserExists(string username)
        {
            return _users.ContainsKey(username);
        }

        // Method to add a new user
        public bool AddUser(User user)
        {
            if (UserExists(user.Username))
            {
                return false; // User already exists
            }
            _users.Add(user.Username, user.Password);
            return true;
        }

        // Method to validate login credentials
        public bool ValidateUser(string username, string password)
        {
            return _users.TryGetValue(username, out var storedPassword) && storedPassword == password;
        }

        // Method to retrieve all users (if needed)
        public Dictionary<string, string> GetAllUsers()
        {
            return _users;
        }
    }
}