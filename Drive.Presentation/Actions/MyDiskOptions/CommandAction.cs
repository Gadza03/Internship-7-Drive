﻿
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
    }
}