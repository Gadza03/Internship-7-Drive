
using Drive.Data.Entities.Models;
using Drive.Domain.Repositories;
using Drive.Presentation.Abstractions;
using Drive.Presentation.Actions.Authentication;

namespace Drive.Presentation.Actions.MyDiskOptions.ProfileSettingsActions
{
    public class ChangeEmail : IAction
    {
        private readonly UserRepositroy _userRepository;
        private readonly FolderRepository _folderRepository;
        private readonly FileRepository _fileRepository;
        private readonly ShareRepository _shareRepository;
        private readonly CommentRepository _commentRepository;
        private User _user { get; set; }
        public ChangeEmail(UserRepositroy userRepositroy, FolderRepository folderRepository, FileRepository fileRepository, ShareRepository shareRepository, CommentRepository commentRepository, User user)
        {
            _userRepository = userRepositroy;
            _folderRepository = folderRepository;
            _fileRepository = fileRepository;
            _user = user;
            _shareRepository = shareRepository;
            _commentRepository = commentRepository;
        }
        public string Name { get; set; } = "Change Email";
        public int MenuIndex { get; set; }
        public void Open()
        {
            ChangeProfileParts.RepeatLogIn(_user, _userRepository);
            Console.WriteLine("Changing email: \n");
            Console.Clear();
            var registerProces = new RegisterAction(_userRepository, _folderRepository, _fileRepository);
            var newEmail = registerProces.EnterNewMail();            
            _user.Email = newEmail;
            ChangeProfileParts.UpdateUserInfo(_user, _userRepository, _folderRepository, _fileRepository, _shareRepository, _commentRepository);
        }
    }
}
