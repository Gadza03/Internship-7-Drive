
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

        public static void DisplaySharedFolder(Folder folder)
        {
            if (folder.ParentFolder != null)
                Console.WriteLine($"Folder: {folder.Name}, Parent Folder: {folder.ParentFolder.Name} "+
                 $" -- Owner: Id: {folder.OwnerId} Name: {folder.Owner?.Name} {folder.Owner?.Surname}");
            else
                Console.WriteLine($"Folder: {folder.Name} -- Owner: Id: {folder.OwnerId} Name: {folder.Owner?.Name} {folder.Owner?.Surname}");
        }
        public static void DisplaySharedFile(File file)
        {
            Console.WriteLine($"File: {file.Name}, Last Modified: {file.LastModifiedAt}, (Parent Folder: {file.Folder?.Name})" +
                $" -- Owner: Id: {file.OwnerId} Name: {file.Owner?.Name} {file.Owner?.Surname}");
        }
        public static void DisplayComments(Comment comment)
        {
            Console.WriteLine($"Id: {comment.Id} - {comment.Author?.Email} - {comment.LastModified}\n" +
                $"Content:\n{comment.Content}\n");
        }
    }
}
