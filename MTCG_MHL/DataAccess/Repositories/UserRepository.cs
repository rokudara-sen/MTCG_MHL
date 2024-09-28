using System.Collections.Concurrent;
using MTCG_MHL.Models.Player;

namespace MTCG_MHL.DataAccess.Repositories
{
    public class UserRepository
    {
        // In-memory user storage for simplicity
        private readonly ConcurrentDictionary<string, User> _users = new ConcurrentDictionary<string, User>();  // Username -> User

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
            return _users.TryAdd(user.Username, user); // Add the user object
        }

        // Method to validate login credentials
        public bool ValidateUser(string username, string password)
        {
            if (_users.TryGetValue(username, out var user))
            {
                return user.Password == password;
            }
            return false;
        }

        // Method to get a user by their auth token
        public User GetUserByToken(string token)
        {
            return _users.Values.FirstOrDefault(u => u.AuthToken == token);
        }
    }
}