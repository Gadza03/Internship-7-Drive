using Drive.Data.Entities.Models;
using Drive.Domain.Repositories;
using Drive.Presentation.Abstractions;
using Drive.Domain.Enums;
using Drive.Presentation.Utils;

namespace Drive.Presentation.Actions.UserRegister
{
    public class RegisterAction : IAction
    {
        private readonly UserRepositroy _userRepository;
        public RegisterAction(UserRepositroy userRepositroy)
        {
            _userRepository = userRepositroy;
        }
        
        public string Name { get; set; } = "Register";
        public int MenuIndex { get; set; }
        public void Open()
        {
            var firstName = EnterNewName("Enter your first name: ");
            var lastName = EnterNewName("Enter your last name: ");
            var email = EnterNewMail();
            var password = EnterNewPassword();
            var confirmedPassword = IsPasswordMatch(password);
            var captcha = Captcha.GenerateCaptcha();
            Console.WriteLine($"Captcha: {captcha}.\n Type captcha to verify you are human enter to exit:");
            if (!Captcha.ValidateCaptcha(captcha))
                return;

            var user = new User(firstName, lastName, email, HashPassword(password));
            var responseResult = _userRepository.Add(user);
            if (responseResult == ResponseResultType.Success)
            {
                Console.WriteLine($"Welcome\nSuccessful login user {firstName}.");
                Console.ReadKey();
            }               

        }
        
        private string EnterNewMail()
        {
            while (true)
            {
                Console.Clear();
                Console.WriteLine("Enter your mail: ");
                var email = Console.ReadLine();
                if (!_userRepository.IsValidEmail(email))
                {
                    Console.WriteLine("Invalid email format. Try again");
                    Console.ReadKey();
                    continue;
                }
                var user = _userRepository.EmailExists(email);
                if (user == null)
                    return email;
                Console.WriteLine("The email is already in use. Try again");
                Console.ReadKey();
            }
        }
        
        private string EnterNewName(string prompt)
        {
            while (true)
            {
                Console.Clear();
                Console.WriteLine(prompt);
                var name = Console.ReadLine();
                if (!string.IsNullOrEmpty(name)) return name;
                Console.WriteLine("Name must have at least one letter. Try again");
                Console.ReadKey();
            }
        }
        private string EnterNewPassword()
        {
            while (true)
            {
                Console.Clear();
                Console.WriteLine("Enter your new password: ");
                var password = Console.ReadLine();
                if (_userRepository.IsPasswordValid(password, out var errorMessage))                
                    return password;                

                Console.WriteLine(errorMessage);
                Console.ReadKey();
            }
        }
        private bool IsPasswordMatch(string password)
        {
            while (true)
            {
                Console.Write("Re-Enter your new password: ");
                var passwordConfirmation = Console.ReadLine();
                if (password == passwordConfirmation)
                    return true;
                Console.WriteLine("The passwords do not match. Please try again.");
                Console.ReadKey();
            }
        }


        private string HashPassword(string password)
        {
            return BCrypt.Net.BCrypt.HashPassword(password);
        }
    }
}
