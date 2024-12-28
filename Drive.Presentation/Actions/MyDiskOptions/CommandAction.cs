
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
        private Folder? CurrentFolder {  get;  set; }
        public CommandAction(UserRepositroy userRepositroy, FolderRepository folderRepository, FileRepository fileRepository)
        {
            _userRepository = userRepositroy;
            _folderRepository = folderRepository;
            _fileRepository = fileRepository;           

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

                        break;
                    case "delete.f":

                        break;
                    case "rename.f":
                        RenameItem(name,user,CurrentFolder.Id);
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
        private void RefreshCommandPrompt(User user, Folder parentFolder)
        {
            var refreshFiles = new MyDisk(RepositoryFactory.Create<UserRepositroy>(), RepositoryFactory.Create<FolderRepository>(), RepositoryFactory.Create<FileRepository>(), user);
            refreshFiles.Open();
        }
        private void CreateItem(ItemType type,string name, User user, int parentFolderId)
        {
           var responseResult = _folderRepository.CreateFolderOrFile(type,name,user.Id,parentFolderId, _fileRepository);
            if (responseResult == ResponseResultType.Success)
            {
                Console.WriteLine($"Successfuly added {type}.");
                Console.ReadKey();
                RefreshCommandPrompt(user, CurrentFolder);                
            }                                   
            else
                Console.WriteLine(ResponseHandler.ErrorMessage(responseResult));            
        }
        private void EnterFolder(string name, User user)
        {
            if (!_folderRepository.IsFolderExists(name, user))
            {
                Console.WriteLine("Entered name of folder doesn't exisits.");              
                return;
            }            
            var enteredFolder = _folderRepository.GetFolderByName(name, user);
            CurrentFolder = enteredFolder;
            Console.WriteLine($"You entered folder - {CurrentFolder?.Name}");
        }
        
        public void RenameItem(string currentName, User user, int parentFolderId)
        {
            
            var folder = _folderRepository.GetFolderByName(currentName, user);
            if (folder != null)
            {
                RenameFolder(folder, user);
                return;
            }            
            var file = _fileRepository.GetFileByName(currentName, user);
            if (file != null)
            {
                RenameFile(file,user);
                return;
            }
          
            Console.WriteLine("The item with the specified name does not exist.");
        }
        private void RenameFolder(Folder folder, User user)
        {
            if (folder.Name == "Root")
            {
                Console.WriteLine("You can't rename Root folder!");
                return;
            }
            Console.Write($"Selected folder: {folder.Name}\nEnter new name: ");            
            var newName = Console.ReadLine().Trim();

            var responseResult = _folderRepository.ValidateItemName(ItemType.Folder, newName, folder.OwnerId, folder.ParentFolderId, _fileRepository);
            if (responseResult != ResponseResultType.Success)
            {
                Console.WriteLine(ResponseHandler.ErrorMessage(responseResult));
                return;
            }
            folder.Name = newName;
            folder.LastModified = DateTime.UtcNow;
            _folderRepository.Update(folder);
            Console.WriteLine($"Folder renamed to {newName}. \tRefreshing...");
            Console.ReadKey();
            RefreshCommandPrompt(user, CurrentFolder);

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

            file.Name = newName;
            file.LastModifiedAt = DateTime.UtcNow;
            _fileRepository.Update(file);
            Console.WriteLine($"File renamed to {newName}.\tRefreshing...");
            Console.ReadKey();
            RefreshCommandPrompt(user, CurrentFolder);
        }
  

    }
}
