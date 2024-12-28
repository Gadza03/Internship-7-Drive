
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
                        CreateIte(ItemType.Folder,name, user, CurrentFolder.Id);
                        break;
                    case "create.file":
                        CreateIte(ItemType.File, name, user, CurrentFolder.Id);

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

        private void CreateIte(ItemType type, string name, User user, int parentFolderId)
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
        private void CreateItem(ItemType type,string name, User user, int parentFolderId)
        {
           var responseResult = _folderRepository.CreateFolderOrFile(type,name,user.Id,parentFolderId, _fileRepository);
            if (responseResult == ResponseResultType.Success)
            {
                Console.WriteLine($"Successfuly added {type}.");
                Console.ReadKey();
                RefreshCommandPrompt(user);                
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
            if (!_fileRepository.IsFileExistsInDrive(name, user.Id))
            {
                Console.WriteLine("Entered name of File doesn't exists.");
                return;
            }
            Console.WriteLine($"Editing file - {name}: \n Type :help for a list of commands.\n");

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
