

using Drive.Data.Entities.Models;
using Drive.Domain.Repositories;
using Drive.Presentation.Abstractions;
using Drive.Presentation.Actions.UserRegister;
using Drive.Presentation.Utils;

namespace Drive.Presentation.Actions.MyDiskOptions.ProfileSettingsActions
{
    public class ChangePassword : IAction
    {
        private readonly UserRepositroy _userRepository;
        private readonly FolderRepository _folderRepository;
        private readonly FileRepository _fileRepository;
        private readonly ShareRepository _shareRepository;
        private readonly CommentRepository _commentRepository;
        
        private User _user { get; set; }
        public ChangePassword(UserRepositroy userRepositroy, FolderRepository folderRepository, FileRepository fileRepository, ShareRepository shareRepository, CommentRepository commentRepository, User user)
        {
            _userRepository = userRepositroy;
            _folderRepository = folderRepository;
            _fileRepository = fileRepository;
            _user = user;
            _shareRepository = shareRepository;
            _commentRepository = commentRepository;
        }

        public string Name { get; set; } = "Change Password";
        public int MenuIndex { get; set; }

        public void Open()
        {
            ChangeProfileParts.RepeatLogIn(_user, _userRepository);
            Console.Clear();
            Console.WriteLine("Changing password: \n");
            var registerProces = new RegisterAction(_userRepository, _folderRepository, _fileRepository);
            var newPassword = registerProces.EnterNewPassword();
            var newPasswordMatch = registerProces.IsPasswordMatch(newPassword);
            if (newPasswordMatch)
            {
                _user.PasswordHash = Hash.HashPassword(newPassword);
                ChangeProfileParts.UpdateUserInfo(_user, _userRepository, _folderRepository, _fileRepository, _shareRepository, _commentRepository);
            }

        }

    }
}
