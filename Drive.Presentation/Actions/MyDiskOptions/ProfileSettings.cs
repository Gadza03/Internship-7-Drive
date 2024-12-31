using Drive.Data.Entities.Models;
using Drive.Domain.Repositories;
using Drive.Presentation.Abstractions;
using Drive.Presentation.Actions.MenuOptions;
using Drive.Presentation.Actions.MyDiskOptions.ProfileSettingsActions;


namespace Drive.Presentation.Actions.MyDiskOptions
{
    public class ProfileSettings : IAction
    {
        private readonly UserRepositroy _userRepository;
        private readonly FolderRepository _folderRepository;
        private readonly FileRepository _fileRepository;
        private readonly ShareRepository _shareRepository;
        private readonly CommentRepository _commentRepository;
        private User _user { get; set; }

        public ProfileSettings(UserRepositroy userRepositroy, FolderRepository folderRepository, FileRepository fileRepository, ShareRepository shareRepository, CommentRepository commentRepository, User user)
        {
            _userRepository = userRepositroy;
            _folderRepository = folderRepository;
            _fileRepository = fileRepository;
            _user = user;
            _shareRepository = shareRepository;
            _commentRepository = commentRepository;

        }
        public string Name { get; set; } = "Profile Settings";
        public int MenuIndex { get; set; }

        public void Open()
        {
            Console.WriteLine("Samo da nije password HAHHAH! Disk opcija 3.");
            Console.ReadKey();
        }
        private void OpenProfileSettingsMenu()
        {
            var profileMenu = new ProfileSettingsMenu
            {
                new ChangePassword(_userRepository, _folderRepository, _fileRepository, _shareRepository, _commentRepository, _user),
                new ChangeEmail(_userRepository, _folderRepository, _fileRepository, _shareRepository, _commentRepository, _user),
            };
        }
    }
}
