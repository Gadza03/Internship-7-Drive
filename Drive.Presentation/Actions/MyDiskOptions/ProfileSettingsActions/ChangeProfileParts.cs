
using Drive.Data.Entities.Models;
using Drive.Domain.Enums;
using Drive.Domain.Repositories;
using Drive.Presentation.Actions.Authentication;

namespace Drive.Presentation.Actions.MyDiskOptions.ProfileSettingsActions
{
    public static class ChangeProfileParts
    {
        public static void RepeatLogIn(User user, UserRepositroy _userRepository)
        {
            Console.WriteLine("To change your profile informations first log in with you current email and password.\n");
            CurrentUserEmailValidation(user, _userRepository);
            CurrentUserPasswordValidation(user, _userRepository);
        }
        private static void CurrentUserEmailValidation(User user, UserRepositroy _userRepository)
        {
            while (true)
            {
                Console.WriteLine("Enter your email: ");
                var email = Console.ReadLine() ?? "";
                var correctMail = _userRepository.IsEmailMatching(user, email);
                if (correctMail)                
                    return;
                Console.WriteLine("Entered email is not correct.");
            }
        }
        private static void CurrentUserPasswordValidation(User user, UserRepositroy _userRepository)
        {
            while (true)
            {
                Console.WriteLine("Enter your password: ");
                var password = Console.ReadLine() ?? "";
                var correctPassword = _userRepository.IsPasswordValid(user, password);
                if (correctPassword == ResponseResultType.Success) 
                    return;
                Console.WriteLine("Entered password is not correct.");
            }
        }
        public static void UpdateUserInfo(User user, UserRepositroy userRepository, FolderRepository folderRepository,FileRepository fileRepository, ShareRepository shareRepository, CommentRepository commentRepository)
        {
            if (userRepository.Update(user) == ResponseResultType.Success)
            {
                Console.WriteLine("Successfully updated your informations.");
                Console.ReadKey();
            }
            else
            {
                Console.WriteLine("Something went wrong");
                Console.ReadKey();
            }
            var diskMenu = new LogInAction(userRepository, folderRepository, fileRepository, shareRepository, commentRepository);
            diskMenu.OpenDiskMenu(user);
        }
    }
}
