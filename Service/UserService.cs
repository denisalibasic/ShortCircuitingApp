using ShortCircuitingApp.Repository;
using System.Text.Json;

namespace ShortCircuitingApp.Service
{
    public class UserService
    {
        private readonly UserRepository _userRepository;

        public UserService(UserRepository userRepository)
        {
            _userRepository = userRepository;
        }

        public (string? UserJson, string? Message) GetUser(int userId)
        {
            var user = _userRepository.GetUserById(userId);
            if(user != null && user.IsActive)
            {
                string userJson = JsonSerializer.Serialize(user);
                return (userJson, "Valid user found");
            } else
            {
                return ("No user", "Valid user not found");
            }
        }

        public (string? UserJson, string? Message) GetUserBadImplementation(int userId)
        {
            var user = _userRepository.GetUserById(userId);
            if (user.IsActive && user != null)
            {
                string userJson = JsonSerializer.Serialize(user);
                return (userJson, "Valid user found");
            }
            else
            {
                return ("No user", "Valid user not found");
            }
        }
    }
}
