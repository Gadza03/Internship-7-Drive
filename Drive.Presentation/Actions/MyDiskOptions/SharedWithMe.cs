using Drive.Data.Entities.Models;
using Drive.Domain.Repositories;
using Drive.Presentation.Abstractions;
using Drive.Presentation.Actions.Authentication;
using Drive.Presentation.Actions.MyDiskOptions.Command;
using Drive.Presentation.Helpers;

namespace Drive.Presentation.Actions.MyDiskOptions
{
    public class SharedWithMe : IAction
    {
        private readonly UserRepositroy _userRepository;
        private readonly FolderRepository _folderRepository;
        private readonly FileRepository _fileRepository;
        private readonly ShareRepository _shareRepository;
        private readonly CommentRepository _commentRepository;
        private User _user { get; set; }
        public SharedWithMe(UserRepositroy userRepositroy, FolderRepository folderRepository, FileRepository fileRepository, ShareRepository shareRepository, CommentRepository commentRepository,User user)
        {
            _userRepository = userRepositroy;
            _folderRepository = folderRepository;
            _fileRepository = fileRepository;
            _user = user;
            _shareRepository = shareRepository;
            _commentRepository = commentRepository;

        }
        public string Name { get; set; } = "Shared With Me";
        public int MenuIndex { get; set; }
        public void Open()
        {
            Console.Clear();
            var sharedFolders = _shareRepository.GetSharedFoldersWithUser(_user);
            var sharedFiles = _shareRepository.GetSharedFilesWithUser(_user);
            if (!sharedFolders.Any() && !sharedFiles.Any())
            {
                Console.WriteLine("You don't have items shared with you.");
                Console.ReadKey();
                var myDiskMenu = new LogInAction(_userRepository, _folderRepository, _fileRepository,_shareRepository, _commentRepository);
                myDiskMenu.OpenDiskMenu(_user);
                return;
            }
            Console.WriteLine("Items shared with you: ");
            foreach (var folder in sharedFolders)            
                Writer.DisplaySharedFolder(folder);
            
            foreach (var file in sharedFiles)            
                Writer.DisplaySharedFile(file);

            var commandPromptEdit = new CommandSharedAction(_userRepository, _folderRepository, _fileRepository, _shareRepository, _commentRepository);
            commandPromptEdit.CommandPromptForEditShare(_user, sharedFolders, sharedFiles);           


        }
    }
}
