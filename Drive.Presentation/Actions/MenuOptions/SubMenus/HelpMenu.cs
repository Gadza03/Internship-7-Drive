

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
                     "delete.folder/file ‘folder or file name’ – Deletes the specified folder or file.\n" +
                     "rename.folder/file ‘folder or file name’ to ‘new name’ – Renames the specified folder or file.\n" +
                     "back – Returns to the previous folder.\n");
        }
    }
}
