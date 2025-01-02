

namespace Drive.Presentation.Actions.MenuOptions.SubMenus
{
    public static class HelpMenu
    {
        public static void DisplayCommands()
        {            
            Console.WriteLine("\nAvailable Commands:\n" +
                     "help – Displays all available commands.\n" +
                     "create.folder ‘folder name’ – Creates a folder in the current location.\n" +
                     "create.file ‘file name’ – Creates a file in the current location.\n" +
                     "enter.folder ‘folder name’ – Navigates into the specified folder.\n" +
                     "edit.file ‘file name’ – Edits the specified file.\n" +
                     "delete.f ‘folder or file name’ – Deletes the specified folder or file.\n" +
                     "rename.f ‘folder or file name’ to ‘new name’ – Renames the specified folder or file.\n" +
                     "share.f 'mail' ‘folder or file name’ to share item with other users.\n" +
                     "stop.sharing.f 'mail' ‘folder or file name’ to stop sharing item with other users.\n" + 
                     "back – Returns to the previous folder.\n");
        }

        public static void DisplayEditFileCommands()
        {
            Console.WriteLine("\nFile Editor Commands:\n" +
                        ":help - Display all commands\n" +
                        ":save and exit - Save changes and exit\n" +
                        ":exit - Exit without saving\n" +
                        ":open comments - Open all comments related to file\n");
        }
        public static void DisplayEditSharedItemsCommands()
        {
            Console.WriteLine("\nAvailable Commands:\n" +
                    "help – Displays all available commands.\n" +                    
                    "enter.folder ‘folder name’ – Navigates into the specified folder.\n" +
                    "edit.file ‘file name’ – Edits the specified file.\n" +
                    "delete.f ‘folder or file name’ – Deletes the specified folder or file.\n" +
                    "rename.f ‘folder or file name’ to ‘new name’ – Renames the specified folder or file.\n" +
                    "back – Returns to the previous folder.\n");
        }

        public static void DisplayCommentCommands()
        {
            Console.WriteLine("\nAvailable Commands:\n" +
                   "help – Displays all available commands.\n" +
                   "add.c - Create new comment for file\n" +
                   "edit.c 'comment-id' – Edits the specified comment.\n" +
                   "delete.c 'comment-id' – Deletes the specified comment.\n" +
                   "back – Returns to the previous folder.\n");

        }
    }
}
