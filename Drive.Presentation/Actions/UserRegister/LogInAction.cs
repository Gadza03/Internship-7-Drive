using Drive.Presentation.Abstractions;
using Drive.Domain.Repositories;
using Drive.Data.Entities.Models;
using Drive.Domain.Enums;
using Drive.Presentation.Utils;
using Drive.Domain.Factories;
using Drive.Presentation.Actions.MenuOptions;
using Drive.Presentation.Actions.MyDiskOptions;

namespace Drive.Presentation.Actions.UserRegister
{

    public class LogInAction : IAction
    {
        private readonly UserRepositroy _userRepository;
        private readonly FolderRepository _folderRepository;
        private readonly FileRepository _fileRepository;
        public LogInAction(UserRepositroy userRepositroy, FolderRepository folderRepository, FileRepository fileRepository)
        {
            _userRepository = userRepositroy;
            _folderRepository = folderRepository;
            _fileRepository = fileRepository;
        }

        public string Name { get; set; } = "Log in";
        public int MenuIndex { get; set; }
       
        public void Open()
        {
            var userByMail = GetUserByMail();
            while (true)
            {
                var lastAttemptTime = DateTime.Now;
                Console.Write("Password: ");
                var password = Console.ReadLine() ?? "";

                if (_userRepository.IsPasswordValid(userByMail, password) == ResponseResultType.Success)
                    break;

                Console.WriteLine("Password is invalid. Try again after 30 seconds.");
                Thread.Sleep(5000);   //5s                
            }
            OpenDiskMenu(userByMail);
        }       
        private User GetUserByMail()
        {
            while (true) 
            {
                Console.Clear();
                Console.Write("Enter your email: ");
                var email = Console.ReadLine() ?? "";                  
                var userByMail = _userRepository.EmailExists(email);
                if (userByMail != null)
                    return userByMail;
                Console.WriteLine($"User with {email} doesn't exist. Try again.");
                Console.ReadKey();
            }
        }
        
        public void OpenDiskMenu(User user)
        {
            var actions = new List<IAction> {
                new MyDisk(_userRepository, _folderRepository,_fileRepository, user),
                new SharedWithMe(_userRepository, _folderRepository,_fileRepository, user),
                new ProfileSettings(_userRepository, _folderRepository,_fileRepository, user),
                new LogOut()
             };
            var diskMenu = new DiskMenu(actions);
            diskMenu.Open();
        }
    }
}
