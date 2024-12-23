using Drive.Presentation.Abstractions;
using Drive.Domain.Repositories;
using Drive.Data.Entities.Models;
using Drive.Domain.Enums;
using Drive.Presentation.Actions.MenuOptions;

namespace Drive.Presentation.Actions.UserRegister
{

    public class LogInAction : IAction
    {
        private readonly UserRepositroy _userRepository;
        public LogInAction(UserRepositroy userRepositroy)
        {
            _userRepository = userRepositroy;
        }

        public string Name { get; set; } = "Log in";
        public int MenuIndex { get; set; }
       
        public void Open()
        {
            var userByMail = GetUserByMail();
            while (true)
            {
                Console.Write("Password: ");
                var password = Console.ReadLine();           
                    
                if (IsPasswordValid(userByMail, password) == ResponseResultType.Success)
                    break;
                Console.WriteLine("Password is invalid. Try again.");
                Console.ReadKey();
            }

            
                   

        }
        private ResponseResultType IsPasswordValid(User user, string password)
        {
            if (VerifyPassword(password, user.PasswordHash))
                return ResponseResultType.Success;
            return ResponseResultType.ValidationError;
        }
        private User GetUserByMail()
        {
            while (true) 
            {
                Console.Clear();
                Console.Write("Enter your email: ");
                var email = Console.ReadLine();                  
                var userByMail = _userRepository.EmailExists(email);
                if (userByMail != null)
                    return userByMail;
                Console.WriteLine($"User with {email} doesn't exist. Try again.");
                Console.ReadKey();
            }
        }
        private bool VerifyPassword(string password, string hashedPassword)
        {
            return BCrypt.Net.BCrypt.Verify(password, hashedPassword);
        }
    }
}
