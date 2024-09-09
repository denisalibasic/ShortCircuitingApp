# ShortCircuitingApp
Example of console application that demonstrates short-circuiting .NET C#

## Table of Contents

- [Overview](#overview)
- [Project Structure](#project-structure)
- [Short-Circuiting Explanation](#short-circuiting-explanation)
- [Correct vs Incorrect Implementations](#correct-vs-incorrect-implementations)
  - [Correct User Validation](#correct-user-validation)
  - [Incorrect User Validation](#incorrect-user-validation)
- [How to Run](#how-to-run)
- [Contributing](#contributing)
- [License](#license)
- [Blog](#blog)

## Overview

This project demonstrates the concept of **short-circuiting** in C# and how it applies to conditional checks  in user validation scenario. It compares a correct implementation of user validation with an incorrect one, showing how improper ordering of conditions can lead to runtime exceptions like `NullReferenceException`.

## Project Structure

```bash
ShortCircuitingApp/
├── Models/
│   └── User.cs
├── Repository/
│   └── UserRepository.cs
├── Service/
│   └── UserService.cs
├── Program.cs
```
- User: Defines the user model.
- UserRepository: Contains the mock database and method to fetch users.
- UserService: Contains the business logic for validating users, including the correct and incorrect implementations.
- Program: Entry point of the application where the service is used and tested.

## Short-Circuiting Explanation
Short-circuiting refers to the evaluation of logical expressions where if the result is already determined the remaining conditions are not evaluated. 

In C#, logical && and || operators are short-circuiting:
- && (AND): If the first condition is false, the second condition is not evaluated.
- || (OR): If the first condition is true, the second condition is not evaluated.
In this project, we use short-circuiting to demonstrate how to correctly validate user objects

## Correct vs Incorrect Implementations
### Correct User Validation
The correct implementation of user validation ensures that all conditions are checked in a safe order, preventing potential exceptions. This method first checks if the user object is null before accessing properties.

```bash
public (string? UserJson, string? Message) GetUser(int userId)
{
    var user = _userRepository.GetUserById(userId);
    if (user != null && user.IsActive)
    {
        string userJson = JsonSerializer.Serialize(user);
        return (userJson, "Valid user found");
    }
    else
    {
        return ("No user", "Valid user not found");
    }
}
```

### Incorrect User Validation
In this example the method improperly checks user.IsActive before confirming if user is null. This can cause a NullReferenceException if user is null.

```bash
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
```

## How to Run

1. Clone the repository:
  ```bash
  git clone https://github.com/denisalibasic/ShortCircuitingApp
  cd ShortCircuitingApp
  ```
   
2. Run the application:
  ```bash
  dotnet run
  ```

3. Enter a user ID when prompted to test both the correct and incorrect implementations of user validation

## Contributing
Contributions are welcome! Feel free to submit a pull request or open an issue if you encounter any bugs or have suggestions for improvements.


## License
This project is licensed under the MIT License - see the [LICENSE](LICENSE) file for details.

## Blog
TO UPDATE
