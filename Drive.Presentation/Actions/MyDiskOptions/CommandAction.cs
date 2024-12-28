
using File = Drive.Data.Entities.Models.File;
using Drive.Data.Entities.Models;
using Drive.Data.Enums;
using Drive.Domain.Enums;
using Drive.Domain.Repositories;
using Drive.Presentation.Actions.MenuOptions.SubMenus;
using Drive.Presentation.Actions.UserRegister;
using Drive.Presentation.Utils;
using Drive.Domain.Factories;

namespace Drive.Presentation.Actions.MyDiskOptions
{
    public class CommandAction
    {
        private readonly UserRepositroy _userRepository;
        private readonly FolderRepository _folderRepository;
        private readonly FileRepository _fileRepository;
        private Folder CurrentFolder {  get;  set; }
        public CommandAction(UserRepositroy userRepositroy, FolderRepository folderRepository, FileRepository fileRepository)
        {
            _userRepository = userRepositroy;
            _folderRepository = folderRepository;
            _fileRepository = fileRepository;
            CurrentFolder = new Folder();
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
                        CreateItem(ItemType.Folder,name, user, CurrentFolder.Id);
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
                        RenameItem(name,user);
                        break;
                    case "back":
                        var logInMenu = new LogInAction(_userRepository, _folderRepository, _fileRepository);
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
            var refreshFiles = new MyDisk(RepositoryFactory.Create<UserRepositroy>(), RepositoryFactory.Create<FolderRepository>(), RepositoryFactory.Create<FileRepository>(), user);
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
                    CreateFile(name,user, parentFolderId);
                    return;
                }
            }
            Console.WriteLine(ResponseHandler.ErrorMessage(responseResult));

        }
        private void CreateFolder(string name, User user, int parentFolderId)
        {
            if (!Confirmation.ConfirmationDialog("create folder"))
            {
                Console.WriteLine("Canceled create action.");
                return;
            }
            _folderRepository.CreateFolder(name, user.Id, parentFolderId);
            Console.WriteLine("Successfully added folder.");
            Console.ReadKey();
            RefreshCommandPrompt(user);

        }
        private void CreateFile(string name, User user, int folderId)
        {
            if (!Confirmation.ConfirmationDialog("create file"))
            {
                Console.WriteLine("Canceled create action.");
                return;
            }
            _fileRepository.CreateFile(name, user.Id, folderId);
            Console.WriteLine("Successfully added file.");
            Console.ReadKey();
            RefreshCommandPrompt(user);
        }
        private void EnterFolder(string name, User user)
        {
            if (!_folderRepository.IsFolderExists(name, user))
            {
                Console.WriteLine("Entered name of folder doesn't exisits.");              
                return;
            }
            if (name == "Root")            
                CurrentFolder = _folderRepository.GetRootFolder("Root", user);
            else
            {

                var enteredFolder = _folderRepository.GetFolderByNameAndParentFolder(name, user, CurrentFolder.Id);
                CurrentFolder = enteredFolder;
            }
            
            Console.WriteLine($"You entered folder - {CurrentFolder?.Name}");
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
            
            if (!Confirmation.ConfirmationDialog("delete folder"))
            {
                Console.WriteLine("Canceled delete action.");
                return;
            }
            var responseResult = _folderRepository.Delete(folder);
            if (responseResult == ResponseResultType.Success)
            {
                Console.WriteLine("Successfully deleted folder.");
                Console.ReadKey();
                RefreshCommandPrompt(user);
            }
               
        }
        private void DeleteFile(File file, User user)
        {
            if (!Confirmation.ConfirmationDialog("delete file"))
            {
                Console.WriteLine("Canceled delete action.");
                return;
            }
            var responseResult = _fileRepository.Delete(file);
            if (responseResult == ResponseResultType.Success)
            {
                Console.WriteLine("Successfully deleted file.");
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

            Console.WriteLine($"Editing file - {name}: \nType :help for a list of commands.\n");
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
        }

        private bool HandleCommand(string command, ref List<string> lines, File file, ref bool isSaved)
        {
            switch (command.ToLower())
            {
                case "help":
                    HelpMenu.DisplayEditCommands();
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
            var file = _fileRepository.GetFileByNameAndFolder(currentName, user, CurrentFolder.Id);
            if (file != null)
            {
                RenameFile(file,user);
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
            var newName = Console.ReadLine().Trim();

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
  

    }
}
