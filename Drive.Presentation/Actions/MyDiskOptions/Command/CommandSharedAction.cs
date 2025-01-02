using Drive.Data.Entities.Models;
using Drive.Domain.Enums;
using Drive.Domain.Factories;
using Drive.Domain.Repositories;
using Drive.Presentation.Actions.Authentication;
using Drive.Presentation.Actions.MenuOptions.SubMenus;
using Drive.Presentation.Utils;
using File = Drive.Data.Entities.Models.File;

namespace Drive.Presentation.Actions.MyDiskOptions.Command
{
    public class CommandSharedAction
    {
        private readonly UserRepositroy _userRepository;
        private readonly FolderRepository _folderRepository;
        private readonly FileRepository _fileRepository;
        private readonly ShareRepository _shareRepository;
        private readonly CommentRepository _commentRepository;
        private CommandAction _commandAction;
        private Folder CurrentFolder { get; set; }
        public CommandSharedAction(UserRepositroy userRepositroy, FolderRepository folderRepository, FileRepository fileRepository, ShareRepository shareRepository, CommentRepository commentRepository)
        {
            _userRepository = userRepositroy;
            _folderRepository = folderRepository;
            _fileRepository = fileRepository;
            CurrentFolder = new Folder();
            _shareRepository = shareRepository;
            _commentRepository = commentRepository;
            _commandAction = new CommandAction(_userRepository, _folderRepository, _fileRepository, _shareRepository, _commentRepository);
        }
        public void CommandPromptForEditShare(User user, IEnumerable<Folder> sharedFolders, IEnumerable<File> sharedFiles)
        {
            while (true)
            {
                Console.Write("\nEnter a command (help - for list of commands): ");
                string input = Console.ReadLine()?.Trim() ?? "";
                string[] parts = !string.IsNullOrEmpty(input) ? input.Split(" ") : Array.Empty<string>();
                if (parts.Length < 1)
                {
                    Console.WriteLine("Invalid input, try again");
                    continue;
                }

                var name = string.Join(" ", parts.Skip(1));
                switch (parts[0])
                {
                    case "help":
                        HelpMenu.DisplayEditSharedItemsCommands();
                        break;
                    case "enter.folder":
                        EnterSharedFolder(name, user, sharedFolders);
                        break;
                    case "edit.file":
                        EditSharedFile(name, user, sharedFiles);
                        break;
                    case "delete.f":
                        DeleteSharedItem(name, user, sharedFolders, sharedFiles);
                        break;
                    case "back":
                        var logInMenu = new LogInAction(_userRepository, _folderRepository, _fileRepository, _shareRepository, _commentRepository);
                        logInMenu.OpenDiskMenu(user);
                        break;
                    default:
                        Console.WriteLine("Invalid input, try again.");
                        Console.ReadKey();
                        continue;
                }
            }
        }
        public void RefreshCommandPromptForEditShare(User user)
        {
            var refreshFiles = new SharedWithMe(RepositoryFactory.Create<UserRepositroy>(), RepositoryFactory.Create<FolderRepository>(), RepositoryFactory.Create<FileRepository>(), RepositoryFactory.Create<ShareRepository>(), RepositoryFactory.Create<CommentRepository>(), user);
            refreshFiles.Open();
        }
        private void EnterSharedFolder(string name, User user, IEnumerable<Folder> sharedFolders)
        {

            var sharedFolder = sharedFolders.FirstOrDefault(s => s.Name == name);
            if (sharedFolder == null)
            {
                Console.WriteLine("The entered folder does not exist in your shared items.");
                return;
            }

            CurrentFolder = sharedFolder;
            Console.WriteLine($"You entered shared folder - {CurrentFolder?.Name}");
        }
        private void EditSharedFile(string name, User user, IEnumerable<File> sharedFiles)
        {
            var file = _shareRepository.GetSharedFileByNameAndParentFolder(sharedFiles, name, CurrentFolder?.Id ?? 0);
            if (file is null)
            {
                Console.WriteLine("Entered name of File doesn't exist.");
                return;
            }
            _commandAction.EditFileProcess(file, user);
        }
        private void DeleteSharedItem(string name, User user, IEnumerable<Folder> sharedFolders, IEnumerable<File> sharedFiles)
        {
            var folderToDelete = _shareRepository.GetSharedFolderByNameAndParentFolder(sharedFolders, name, CurrentFolder?.Id ?? 0);
            if (folderToDelete != null)
            {
                DeleteSharedFolder(folderToDelete, user);
                return;
            }

            var fileToDelete = _shareRepository.GetSharedFileByNameAndParentFolder(sharedFiles, name, CurrentFolder?.Id ?? 0);
            if (fileToDelete != null)
            {
                DeleteSharedFile(fileToDelete, user);
                return;
            }

            Console.WriteLine("The item with the specified name does not exist.");
        }
        private void DeleteSharedFolder(Folder folder, User user)
        {
            if (!Confirmation.ConfiramtionResponse("delete folder"))
                return;

            var responseResult = _shareRepository.DeleteFolderFromShareWith(folder, user);

            if (responseResult == ResponseResultType.Success)
            {
                Console.WriteLine("Successfully deleted folder from Shared With Me.");
                Console.ReadKey();
                RefreshCommandPromptForEditShare(user);
            }
            else
                Console.WriteLine(ResponseHandler.ErrorMessage(responseResult));
        }
        private void DeleteSharedFile(File file, User user)
        {
            if (!Confirmation.ConfiramtionResponse("delete file"))
                return;
            var responseResult = _shareRepository.DeleteFileFromShareWith(file, user);

            if (responseResult == ResponseResultType.Success)
            {
                Console.WriteLine("Successfully deleted file from Shared With Me.");
                Console.ReadKey();
                RefreshCommandPromptForEditShare(user);
            }
            else
                Console.WriteLine(ResponseHandler.ErrorMessage(responseResult));

        }

    }
}
