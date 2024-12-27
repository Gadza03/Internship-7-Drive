
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
        public CommandAction(UserRepositroy userRepository, FolderRepository folderRepository)
        {
            _userRepository = userRepository;
            _folderRepository = folderRepository;
            _fileRepository = RepositoryFactory.Create<FileRepository>();
        }

        public void CommandPrompt(User user, Folder parentFolder)
        {
            CurrentFolder = parentFolder;
            while (true)
            {
                Console.Write("\nEnter a command (help - for list of commands): ");
                string[] parts = Console.ReadLine().Trim().Split(" ");
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
                        CreateItem(ItemType.Folder,name, user.Id, CurrentFolder.Id);
                        break;
                    case "create.file":
                        CreateItem(ItemType.File, name, user.Id, CurrentFolder.Id);

                        break;
                    case "enter.folder":
                        EnterFolder(name, user.Id);
                        break;
                    case "edit.file":

                        break;
                    case "delete.f":

                        break;
                    case "rename.f":
                        RenameItem(name,user.Id,CurrentFolder.Id);
                        break;
                    case "back":
                        var logInMenu = new LogInAction(_userRepository);
                        logInMenu.OpenDiskMenu(user);
                        break;
                    default:
                        Console.WriteLine("Invalid input, try again.");
                        Console.ReadKey();
                        continue;
                }
                
                
            }
        }
       
        private void CreateItem(ItemType type,string name, int userId, int parentFolderId)
        {
           var responseResult = _folderRepository.CreateFolderOrFile(type,name,userId,parentFolderId, _fileRepository);
            if (responseResult == ResponseResultType.Success)            
                Console.WriteLine("Successfuly added item.");            
            else
                Console.WriteLine(ResponseHandler.ErrorMessage(responseResult));            
        }
        private void EnterFolder(string name, int userId)
        {
            if (!_folderRepository.IsFolderExists(name, userId))
            {
                Console.WriteLine("Entered name of folder doesn't exisits.");              
                return;
            }            
            var enteredFolder = _folderRepository.GetFolderByName(name, userId);
            CurrentFolder = enteredFolder;
            Console.WriteLine($"You entered folder - {CurrentFolder?.Name}");
        }
        
        public void RenameItem(string currentName, int userId, int parentFolderId)
        {
            
            var folder = _folderRepository.GetFolderByName(currentName, userId);
            if (folder != null)
            {
                RenameFolder(folder);
                return;
            }            
            var file = _fileRepository.GetFileByName(currentName, userId);
            if (file != null)
            {
                RenameFile(file);
                return;
            }
          
            Console.WriteLine("The item with the specified name does not exist.");
        }
        private void RenameFolder(Folder folder)
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
            Console.WriteLine($"Folder renamed to {newName}.");
        }
        private void RenameFile(File file)
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
            Console.WriteLine($"File renamed to {newName}.");
        }
  

    }
}
