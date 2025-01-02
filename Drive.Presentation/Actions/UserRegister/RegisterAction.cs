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
        private readonly FolderRepository _folderRepository;
        private readonly FileRepository _fileRepository;

        public RegisterAction(UserRepositroy userRepositroy, FolderRepository folderRepository, FileRepository fileRepository)
        {
            _userRepository = userRepositroy;
            _folderRepository = folderRepository;
            _fileRepository = fileRepository;
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
            Console.WriteLine($"Captcha: {captcha}.\n Type captcha to verify you are human (enter to exit):");
            if (!Captcha.ValidateCaptcha(captcha))
                return;

            var user = new User(firstName, lastName, email, Hash.HashPassword(password));
            var responseResultUser = _userRepository.Add(user);

            var folder = new Folder
            {
                Name = "Root",
                ParentFolderId = null,
                CreatedAt = DateTime.UtcNow,
                LastModified = DateTime.UtcNow,
                OwnerId = user.Id,
            };
            var responseResultFolder = _folderRepository.Add(folder);
            if (responseResultUser == ResponseResultType.Success)
            {
                Console.WriteLine($"Welcome\nSuccessful login user {firstName}.");
                Console.ReadKey();
                Program.OpenMainMenu();
            }               

        }        
        public string EnterNewMail()
        {
            while (true)
            {
                Console.Write("Enter your new mail: ");
                var email = Console.ReadLine() ?? "";
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
        public string EnterNewPassword()
        {
            while (true)
            {                
                Console.WriteLine("Enter your new password: ");
                var password = Console.ReadLine() ?? "";
                if (_userRepository.IsPasswordValid(password, out var errorMessage))                
                    return password;                

                Console.WriteLine(errorMessage);
                Console.ReadKey();
            }
        }
        public bool IsPasswordMatch(string password)
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
    
    }
}
