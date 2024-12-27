
using File = Drive.Data.Entities.Models.File;
using Drive.Data.Entities.Models;

namespace Drive.Presentation.Helpers
{
    public static class Writer
    {
        public static void DisplayFolder(Folder folder)
        {
            if (folder.ParentFolder != null)
                Console.WriteLine($"Folder: {folder.Name}, Parent Folder: {folder.ParentFolder.Name}");

            else
                Console.WriteLine($"Folder: {folder.Name}");
        }
        public static void DisplayFile(File file)
        {
            Console.WriteLine($"File: {file.Name}, Last Modified: {file.LastModifiedAt}, (Parent Folder: {file.Folder?.Name})");
        }
    }
}
