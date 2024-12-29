using Drive.Data.Entities.Models;
using Drive.Domain.Enums;
using Drive.Domain.Repositories;
using Drive.Presentation.Abstractions;
using Drive.Presentation.Helpers;
using Drive.Presentation.Utils;
using File = Drive.Data.Entities.Models.File;
namespace Drive.Presentation.Actions.MyDiskOptions
{
    public class MyDisk : IAction
    {
        private readonly UserRepositroy _userRepository;
        private readonly FolderRepository _folderRepository;
        private readonly FileRepository _fileRepository;
        private readonly ShareRepository _shareRepository;
        private readonly CommentRepository _commentRepository;

        private User _user {  get; set; }
        public MyDisk(UserRepositroy userRepositroy, FolderRepository folderRepository,FileRepository fileRepository, ShareRepository shareRepository, CommentRepository commentRepository, User user)
        {
            _userRepository = userRepositroy;
            _folderRepository = folderRepository;
            _fileRepository = fileRepository;
            _user = user;
            _shareRepository = shareRepository;
            _commentRepository = commentRepository;
        }
        public string Name { get; set; } = "My Disk";
        public int MenuIndex { get; set; }

        public void Open()
        {
            var sortedFolders = _userRepository.GetFoldersOrFiles<Folder>(_user);
            var sortedFiles = _userRepository.GetFoldersOrFiles<File>(_user);
            Console.Clear();
            //if (!sortedFolders.Any() && !sortedFiles.Any())
            //    Console.WriteLine("You don't have any files or folders.");

            Console.WriteLine("Your documents: ");
            foreach (var folder in sortedFolders)
            {
                Writer.DisplayFolder(folder);
            }
            foreach (var file in sortedFiles)
            {
                Writer.DisplayFile(file);
            }            
            var rootFolder = _folderRepository.GetRootFolder("Root", _user);
            if (rootFolder is null)
            {
                Console.WriteLine(ResponseHandler.ErrorMessage(ResponseResultType.NotFound),"Root Folder");
                Console.ReadKey();
                return;
            }
            var commandAction = new CommandAction(_userRepository, _folderRepository, _fileRepository, _shareRepository, _commentRepository);
            commandAction.CommandPrompt(_user, rootFolder);
        }
    }
}
