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

        private User _user {  get; set; }
        public MyDisk(UserRepositroy userRepositroy, FolderRepository folderRepository, User user)
        {
            _userRepository = userRepositroy;
            _folderRepository = folderRepository;
            _user = user;
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
            var commandAction = new CommandAction(_userRepository, _folderRepository);
            var rootFolder = _folderRepository.GetRootFolder(sortedFolders);
            if (rootFolder is null)
            {
                Console.WriteLine(ResponseHandler.ErrorMessage(ResponseResultType.NotFound),"Root Folder");
                Console.ReadKey();
                return;
            }
            
            commandAction.CommandPrompt(_user, rootFolder);
        }
    }
}
