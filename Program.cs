using ShortCircuitingApp.Repository;
using ShortCircuitingApp.Service;

var userRepository = new UserRepository();
var userService = new UserService(userRepository);

Console.WriteLine("Enter User ID:");
if (int.TryParse(Console.ReadLine(), out int userId))
{

    Console.WriteLine("Is user valid? (correct way to check): " + userService.GetUser(userId));
}
else
{
    Console.WriteLine("Invalid User ID.");
}

Console.WriteLine("Enter User ID:");
if (int.TryParse(Console.ReadLine(), out int userId2))
{
    Console.WriteLine("Is user valid? (incorrect way to check): " + userService.GetUserBadImplementation(userId2));
}
else
{
    Console.WriteLine("Invalid User ID.");
}