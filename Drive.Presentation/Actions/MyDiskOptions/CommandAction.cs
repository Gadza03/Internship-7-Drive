

using Drive.Data.Entities.Models;
using Drive.Domain.Repositories;
using Drive.Presentation.Actions.MenuOptions.SubMenus;

namespace Drive.Presentation.Actions.MyDiskOptions
{
    public class CommandAction
    {
        private readonly UserRepositroy _userRepository;
        private readonly FolderRepository _folderRepository;        
        public CommandAction(UserRepositroy userRepository, FolderRepository folderRepository)
        {
            _userRepository = userRepository;
            _folderRepository = folderRepository;
        }


        public void CommandPrompt(User user, Folder parentFolder)
        {
            var currentFolder = parentFolder;
            while (true)
            {
                Console.WriteLine("Enter a command (help - for list of commands): ");
                var choice = Console.ReadLine();
                switch (choice)
                {
                    case "help":
                        HelpMenu.DisplayCommands();
                        break;

                    case "exit":
                        return;
                    default:
                        Console.WriteLine("Invalid input, try again.");
                        Console.ReadKey();
                        continue;
                }
            }
           

        }
    }
}
