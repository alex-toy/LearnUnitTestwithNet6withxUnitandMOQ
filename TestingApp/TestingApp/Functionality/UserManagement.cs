using TestingApp.Models;

namespace TestingApp.Functionality
{
    public class UserManagement
    {
        private readonly List<User> _users = new List<User>();
        private int idCounter = 1;

        public IEnumerable<User> AllUsers => _users;

        public void Add(User user)
        {
            _users.Add(user with { Id = idCounter++});
        }

        public void UpdatePhone(User user)
        {
            User? dbuser = _users.First(u => u.Id == user.Id);
            dbuser.Phone = user.Phone;
        }

        public void VerifyEmail(int userId)
        {
            User? dbuser = _users.First(u => u.Id == userId);
            dbuser.VerifiedEmail = true;
        }
    }
}
