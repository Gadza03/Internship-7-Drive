using File = Drive.Data.Entities.Models.File;
using Drive.Data.Entities.Models;
using Drive.Data.Enums;
using Drive.Domain.Enums;
using Drive.Domain.Repositories;
using Drive.Presentation.Actions.MenuOptions.SubMenus;
using Drive.Presentation.Utils;
using Drive.Domain.Factories;
using Drive.Presentation.Actions.Authentication;

namespace Drive.Presentation.Actions.MyDiskOptions.Command
{
    public class CommandAction
    {
        private readonly UserRepositroy _userRepository;
        private readonly FolderRepository _folderRepository;
        private readonly FileRepository _fileRepository;
        private readonly ShareRepository _shareRepository;
        private readonly CommentRepository _commentRepository;

        private Folder CurrentFolder { get; set; }
        public CommandAction(UserRepositroy userRepositroy, FolderRepository folderRepository, FileRepository fileRepository, ShareRepository shareRepository, CommentRepository commentRepository)
        {
            _userRepository = userRepositroy;
            _folderRepository = folderRepository;
            _fileRepository = fileRepository;
            CurrentFolder = new Folder();
            _shareRepository = shareRepository;
            _commentRepository = commentRepository;
        }

        public void CommandPrompt(User user, Folder parentFolder)
        {
            CurrentFolder = parentFolder;
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
                        HelpMenu.DisplayCommands();
                        break;
                    case "create.folder":
                        CreateItem(ItemType.Folder, name, user, CurrentFolder.Id);
                        break;
                    case "create.file":
                        CreateItem(ItemType.File, name, user, CurrentFolder.Id);
                        break;
                    case "enter.folder":
                        EnterFolder(name, user);
                        break;
                    case "edit.file":
                        EditFile(name, user);
                        break;
                    case "delete.f":
                        DeleteItem(name, user);
                        break;
                    case "rename.f":
                        RenameItem(name, user);
                        break;
                    case "share.f":
                        if (parts.Length < 3)
                        {
                            Console.WriteLine("Invalid command. Usage: stop.f <email> <item name>");
                            break;
                        }
                        var email = parts[1];
                        var nameOfItem = string.Join(" ", parts.Skip(2));
                        ShareItem(email, nameOfItem, user);
                        break;
                    case "stop.sharing.f":
                        if (parts.Length < 3)
                        {
                            Console.WriteLine("Invalid command. Usage: stop.sharing.f <email> <item name>");
                            break;
                        }
                        email = parts[1];
                        nameOfItem = string.Join(" ", parts.Skip(2));
                        StopSharingItem(email, nameOfItem, user);
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
        private void RefreshCommandPrompt(User user)
        {
            var refreshFiles = new MyDisk(RepositoryFactory.Create<UserRepositroy>(), RepositoryFactory.Create<FolderRepository>(), RepositoryFactory.Create<FileRepository>(), RepositoryFactory.Create<ShareRepository>(), RepositoryFactory.Create<CommentRepository>(), user);
            refreshFiles.Open();
        }
        private void CreateItem(ItemType type, string name, User user, int parentFolderId)
        {
            var responseResult = new ResponseResultType();
            if (type == ItemType.Folder)
            {
                responseResult = _folderRepository.ValidateItemName(ItemType.Folder, name, user.Id, parentFolderId, _fileRepository);
                if (responseResult == ResponseResultType.Success)
                {
                    CreateFolder(name, user, parentFolderId);
                    return;
                }
            }
            if (type == ItemType.File)
            {
                responseResult = _folderRepository.ValidateItemName(ItemType.File, name, user.Id, parentFolderId, _fileRepository);
                if (responseResult == ResponseResultType.Success)
                {
                    CreateFile(name, user, parentFolderId);
                    return;
                }
            }
            Console.WriteLine(ResponseHandler.ErrorMessage(responseResult));

        }
        private void CreateFolder(string name, User user, int parentFolderId)
        {
            if (!Confirmation.ConfiramtionResponse("create folder"))
                return;

            _folderRepository.CreateFolder(name, user.Id, parentFolderId);
            Console.WriteLine("Successfully added folder.");
            Console.ReadKey();
            RefreshCommandPrompt(user);

        }
        private void CreateFile(string name, User user, int folderId)
        {
            if (!Confirmation.ConfiramtionResponse("create file"))
                return;
            _fileRepository.CreateFile(name, user.Id, folderId);
            Console.WriteLine("Successfully added file.");
            Console.ReadKey();
            RefreshCommandPrompt(user);
        }
        private void EnterFolder(string name, User user)
        {
            if (name == "Root")
            {
                CurrentFolder = _folderRepository.GetRootFolder("Root", user);
                Console.WriteLine($"You entered the root folder: {CurrentFolder?.Name}");
                return;
            }

            var enteredFolder = _folderRepository.GetFolderByNameAndParentFolder(name, user, CurrentFolder?.Id ?? 0);
            if (enteredFolder == null)
            {
                Console.WriteLine($"Folder '{name}' does not exist in the current context (Parent Folder: '{CurrentFolder?.Name ?? "None"}').");
                return;
            }

            CurrentFolder = enteredFolder;
            Console.WriteLine($"You entered the folder: {CurrentFolder.Name}");
        }
        public void DeleteItem(string currentName, User user)
        {
            var file = _fileRepository.GetFileByNameAndFolder(currentName, user, CurrentFolder.Id);
            if (file != null)
            {
                DeleteFile(file, user);
                return;
            }

            if (currentName == "Root")
            {
                Console.WriteLine("You can't delete Root folder.");
                return;
            }

            var folder = _folderRepository.GetFolderByNameAndParentFolder(currentName, user, CurrentFolder.Id);
            if (folder != null)
            {
                DeleteFolder(folder, user);
                return;
            }

            Console.WriteLine("The item with the specified name does not exist.");

        }
        private void DeleteFolder(Folder folder, User user)
        {

            if (!Confirmation.ConfiramtionResponse("delete folder"))
                return;
            var responseResult = _folderRepository.Delete(folder);
            if (responseResult == ResponseResultType.Success)
            {                
                Console.WriteLine("Successfully deleted folder.");
                if (_shareRepository.DeleteShareByTypeAndItemId(ItemType.Folder, folder.Id) == ResponseResultType.Success)
                    Console.WriteLine("Folder is deleted from shared items.");

                Console.ReadKey();
                RefreshCommandPrompt(user);
            }

        }
        private void DeleteFile(File file, User user)
        {
            if (!Confirmation.ConfiramtionResponse("delete file"))
                return;
            var responseResult = _fileRepository.Delete(file);
            if (responseResult == ResponseResultType.Success)
            {
                Console.WriteLine("Successfully deleted file.");
                if (_shareRepository.DeleteShareByTypeAndItemId(ItemType.File, file.Id) == ResponseResultType.Success)

                    Console.WriteLine("Folder is deleted from shared items.");
                Console.ReadKey();
                RefreshCommandPrompt(user);
            }
        }
        private void EditFile(string name, User user)
        {
            var file = _fileRepository.GetFileByNameAndFolder(name, user, CurrentFolder.Id);
            if (file is null)
            {
                Console.WriteLine("Entered name of File doesn't exist.");
                return;
            }
            EditFileProcess(file, user);
        }
        public void EditFileProcess(File file, User user)
        {
            Console.Clear();
            Console.WriteLine($"Editing file - {file.Name}: \nType :help for a list of commands.\n");
            Console.WriteLine($"Current Content:\n{file.Content}\n");

            List<string> lines = new List<string>(file.Content?.Split(Environment.NewLine) ?? Array.Empty<string>());
            string currentLine = "";
            bool isSaved = false;

            while (true)
            {
                var key = Console.ReadKey(intercept: true);

                if (key.Key == ConsoleKey.Enter)
                {
                    if (currentLine.StartsWith(":"))
                    {
                        string command = currentLine.Substring(1).Trim();
                        if (command == "open comments")
                        {
                            var commentPrompt = new CommandCommentAction(_userRepository, _folderRepository, _fileRepository, _shareRepository, _commentRepository);
                            commentPrompt.CommandPromptForComments(file, user);
                            break;
                        }
                        if (HandleCommand(command, ref lines, file, ref isSaved))
                        {
                            break;
                        }
                        currentLine = "";
                        continue;
                    }

                    lines.Add(currentLine);
                    currentLine = "";
                    Console.WriteLine();
                }
                else if (key.Key == ConsoleKey.Backspace)
                {
                    if (currentLine.Length > 0)
                    {
                        currentLine = currentLine.Substring(0, currentLine.Length - 1);
                        Console.Write("\b \b");
                    }
                    else if (lines.Count > 0)
                    {
                        currentLine = lines[^1];
                        lines.RemoveAt(lines.Count - 1);
                        Console.CursorTop--;
                        Console.CursorLeft = 0;
                        Console.Write(new string(' ', Console.WindowWidth));
                        Console.CursorLeft = 0;
                        Console.Write(currentLine);
                    }
                }
                else
                {
                    currentLine += key.KeyChar;
                    Console.Write(key.KeyChar);
                }
            }
            Console.WriteLine(isSaved ? "File saved successfully." : "Changes were not saved.");
            if (user.Id == file.OwnerId)            
                RefreshCommandPrompt(user);            
            else
            {
                var sharedPrompt = new CommandSharedAction(_userRepository, _folderRepository, _fileRepository, _shareRepository, _commentRepository);
                sharedPrompt.RefreshCommandPromptForEditShare(user);
            }
        }
        private bool HandleCommand(string command, ref List<string> lines, File file, ref bool isSaved)
        {
            switch (command.ToLower())
            {
                case "help":
                    HelpMenu.DisplayEditFileCommands();
                    return false;
                case "save and exit":
                    Console.WriteLine("\nSaving changes...");
                    file.Content = string.Join(Environment.NewLine, lines);
                    file.LastModifiedAt = DateTime.UtcNow;
                    _fileRepository.Update(file);
                    isSaved = true;
                    return true;
                case "exit":
                    Console.WriteLine("\nExiting without saving...");
                    return true;

                default:
                    Console.WriteLine("\nUnknown command. Type :help for a list of commands.");
                    return false;
            }
        }
        public void RenameItem(string currentName, User user)
        {
            var file = _fileRepository.GetFileByNameAndFolder(currentName, user, CurrentFolder.Id);
            if (file != null)
            {
                RenameFile(file, user);
                return;
            }
            if (currentName == "Root")
            {
                Console.WriteLine("You can't rename Root folder.");
                return;
            }
            var folder = _folderRepository.GetFolderByNameAndParentFolder(currentName, user, CurrentFolder.Id);
            if (folder != null)
            {
                RenameFolder(folder, user);
                return;
            }


            Console.WriteLine("The item with the specified name does not exist.");
        }
        private void RenameFolder(Folder folder, User user)
        {
            Console.Write($"Selected folder: {folder.Name}\nEnter new name: ");
            var newName = Console.ReadLine()?.Trim() ?? string.Empty;

            var responseResult = _folderRepository.ValidateItemName(ItemType.Folder, newName, folder.OwnerId, folder.ParentFolderId, _fileRepository);
            if (responseResult != ResponseResultType.Success)
            {
                Console.WriteLine(ResponseHandler.ErrorMessage(responseResult));
                return;
            }
            if (!Confirmation.ConfirmationDialog("rename folder"))
            {
                Console.WriteLine("Canceled renaming.");
                return;
            }
            folder.Name = newName;
            folder.LastModified = DateTime.UtcNow;
            _folderRepository.Update(folder);
            Console.WriteLine($"Folder renamed to {newName}. \tRefreshing...");
            Console.ReadKey();
            RefreshCommandPrompt(user);

        }
        private void RenameFile(File file, User user)
        {
            Console.Write($"Selected file: {file.Name}\nEnter new name: ");
            var newName = Console.ReadLine()?.Trim() ?? string.Empty;

            var responseResult = _folderRepository.ValidateItemName(ItemType.File, newName, file.OwnerId, file.FolderId, _fileRepository);
            if (responseResult != ResponseResultType.Success)
            {
                Console.WriteLine(ResponseHandler.ErrorMessage(responseResult));
                return;
            }
            if (!Confirmation.ConfirmationDialog("rename file"))
            {
                Console.WriteLine("Canceled renaming.");
                return;
            }
            file.Name = newName;
            file.LastModifiedAt = DateTime.UtcNow;
            _fileRepository.Update(file);
            Console.WriteLine($"File renamed to {newName}.\tRefreshing...");
            Console.ReadKey();
            RefreshCommandPrompt(user);
        }
        private void ShareItem(string email, string nameOfItem, User sharedByUser)
        {
            var sharedWithUser = _userRepository.GetUserByMail(email);
            if (sharedWithUser == null)
            {
                Console.WriteLine($"User with email: {email} doesn't exists.");
                return;
            }
            if (nameOfItem == "Root")
            {
                Console.WriteLine("You can't Share Root folder.");
                return;
            }
            var folder = _folderRepository.GetFolderByNameAndParentFolder(nameOfItem, sharedByUser, CurrentFolder.Id);            
            if (folder != null)
            {                
                ShareFolder(folder, sharedByUser, sharedWithUser);
                return;
            }
            var file = _fileRepository.GetFileByNameAndFolder(nameOfItem, sharedByUser, CurrentFolder.Id);
            if (file != null)
            {
                
                ShareFile(file, sharedByUser, sharedWithUser);
                return;
            }

            Console.WriteLine("The item with the specified name does not exist.");
        }
        private void ShareFolder(Folder folder, User sharedByUser, User sharedWithUser)
        {
            var shareExists = _shareRepository.IsSharedItemExists(ItemType.Folder, folder.Id, sharedByUser, sharedWithUser);
            if (shareExists)
            {
                Console.WriteLine($"Folder {folder.Name} is already shared with {sharedWithUser.Email}.");
                return;
            }
            var share = new Share
            {
                ItemId = folder.Id,
                ItemType = ItemType.Folder,
                SharedById = sharedByUser.Id,
                SharedWithId = sharedWithUser.Id
            };
            var response = _shareRepository.Add(share);

            var filesInFolder = _fileRepository.GetFileByFolderAndOwner(folder, sharedByUser);
            foreach (var file in filesInFolder)
            {
                ShareFile(file, sharedByUser, sharedWithUser);
            }

            var subFolders = _folderRepository.GetFileByParentFolderAndOwner(folder, sharedByUser);
            foreach (var subFolder in subFolders)
            {
                ShareFolder(subFolder, sharedByUser, sharedWithUser);
            }

            Console.WriteLine($"Folder {folder.Name} and its contents successfully shared.");
        }
        private void ShareFile(File file, User sharedByUser, User sharedWithUser)
        {
            var shareExists = _shareRepository.IsSharedItemExists(ItemType.File, file.Id, sharedByUser, sharedWithUser);
            if (shareExists)
            {
                Console.WriteLine($"File {file.Name} is already shared with {sharedWithUser.Email}.");
                return;
            }
            var share = new Share
            {
                ItemId = file.Id,
                ItemType = ItemType.File,
                SharedById = sharedByUser.Id,
                SharedWithId = sharedWithUser.Id
            };
            var response = _shareRepository.Add(share);
            Console.WriteLine($"File {file.Name} successfully shared.");
        }
        private void StopSharingItem(string email, string nameOfItem, User userSharedBy)
        {
            var sharedToUser = _userRepository.GetUserByMail(email);
            if (sharedToUser == null)
            {
                Console.WriteLine($"User with email: {email} doesn't exists.");
                return;
            }
            var folder = _folderRepository.GetFolderByNameAndParentFolder(nameOfItem, userSharedBy, CurrentFolder.Id);
            if (folder != null)
            {
                StopSharingFolder(folder, userSharedBy, sharedToUser);
                return;
            }
            var file = _fileRepository.GetFileByNameAndFolder(nameOfItem, userSharedBy, CurrentFolder.Id);
            if (file != null)
            {
                StopSharingFile(file, userSharedBy, sharedToUser);
                return;
            }
            Console.WriteLine("The item with the specified name does not exist or is not shared with the specified user.");

        }
        private void StopSharingFolder(Folder folder, User sharedByUser, User sharedWithUser)
        {
            var share = _shareRepository.GetShare(sharedByUser, sharedWithUser, folder.Id);
            if (share == null)
            {
                Console.WriteLine($"Folder with ID: {folder.Id} is not shared with user {sharedWithUser.Name}.");
                return;
            }
            var response = _shareRepository.Delete(share);
            Console.WriteLine($"Folder: {folder.Name} it no longer shared with {sharedWithUser.Name}.");
            var filesInFolder = _fileRepository.GetFileByFolderAndOwner(folder, sharedByUser);
            foreach (var file in filesInFolder)
            {
                StopSharingFile(file, sharedByUser, sharedWithUser);
            }

            var subFolders = _folderRepository.GetFileByParentFolderAndOwner(folder, sharedByUser);
            foreach (var subFolder in subFolders)
            {
                StopSharingFolder(subFolder, sharedByUser, sharedWithUser);
            }
        }
        private void StopSharingFile(File file, User sharedByUser, User sharedWithUser)
        {

            var share = _shareRepository.GetShare(sharedByUser, sharedWithUser, file.Id);
            if (share == null)
            {
                Console.WriteLine($"File with ID: {file.Id} is not shared with user {sharedWithUser.Name}.");
                return;
            }
            var response = _shareRepository.Delete(share);
            Console.WriteLine($"File: {file.Name} it no longer shared with {sharedWithUser.Name}.");
        }
    }
}
