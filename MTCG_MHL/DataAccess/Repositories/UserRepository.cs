using System.Collections.Concurrent;
using MTCG_MHL.Models.Player;

namespace MTCG_MHL.DataAccess.Repositories
{
    public class UserRepository
    {
        private readonly ConcurrentDictionary<string, User> _users = new ConcurrentDictionary<string, User>();  // Username -> User

        public bool UserExists(string username)
        {
            return _users.ContainsKey(username);
        }

        public bool AddUser(User user)
        {
            if (UserExists(user.Username))
            {
                return false;
            }
            return _users.TryAdd(user.Username, user);
        }

        public bool ValidateUser(string username, string password)
        {
            if (_users.TryGetValue(username, out var user))
            {
                return user.Password == password;
            }
            return false;
        }

        public User GetUserByToken(string token)
        {
            return _users.Values.FirstOrDefault(u => u.AuthToken == token);
        }
    }
}