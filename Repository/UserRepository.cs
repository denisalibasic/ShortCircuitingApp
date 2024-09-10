using ShortCircuitingApp.Model;

namespace ShortCircuitingApp.Repository
{
    public class UserRepository
    {
        private static readonly List<User> Users = new List<User>
        {
            new User { Id = 1, Email = "admin@contoso.com", IsActive = true, Role = "Admin" },
            new User { Id = 2, Email = "moderator@contoso.com", IsActive = true, Role = "Moderator" },
            new User { Id = 3, Email = "user1@contoso.com", IsActive = true, Role = "User" },
            new User { Id = 4, Email = "user2@contoso.com", IsActive = true, Role = "User" },
            new User { Id = 5, Email = "user3@contoso.com", IsActive = true, Role = "User" },
            new User { Id = 6, Email = "user4@contoso.com", IsActive = true, Role = "User" }
        };

        public User GetUserById(int id)
        {
            return Users.FirstOrDefault(user => user.Id == id);
        }
    }
}
