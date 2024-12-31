
using File = Drive.Data.Entities.Models.File;
using Drive.Data.Entities.Models;
using Drive.Data.Enums;
using Drive.Domain.Enums;
using Drive.Domain.Repositories;
using Drive.Presentation.Actions.MenuOptions.SubMenus;
using Drive.Presentation.Actions.UserRegister;
using Drive.Presentation.Utils;
using Drive.Domain.Factories;
using System.ComponentModel.DataAnnotations;
using System.Net;
using Drive.Presentation.Helpers;

namespace Drive.Presentation.Actions.MyDiskOptions
{
    public class CommandAction
    {
        private readonly UserRepositroy _userRepository;
        private readonly FolderRepository _folderRepository;
        private readonly FileRepository _fileRepository;
        private readonly ShareRepository _shareRepository;
        private readonly CommentRepository _commentRepository;

        private Folder CurrentFolder { get; set; }
        public CommandAction(UserRepositroy userRepositroy, FolderRepository folderRepository, FileRepository fileRepository, ShareRepository shareRepository, CommentRepository commentRepository)
        {
            _userRepository = userRepositroy;
            _folderRepository = folderRepository;
            _fileRepository = fileRepository;
            CurrentFolder = new Folder();
            _shareRepository = shareRepository;
            _commentRepository = commentRepository;
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
                        CreateItem(ItemType.Folder, name, user, CurrentFolder.Id);
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
                        RenameItem(name, user);
                        break;
                    case "share.f":
                        if (parts.Length < 3)
                        {
                            Console.WriteLine("Invalid command. Usage: stop.f <email> <item name>");
                            break;
                        }
                        var email = parts[1];
                        var nameOfItem = string.Join(" ", parts.Skip(2));
                        ShareItem(email, nameOfItem, user);
                        break;
                    case "stop.sharing.f":
                        if (parts.Length < 3)
                        {
                            Console.WriteLine("Invalid command. Usage: stop.sharing.f <email> <item name>");
                            break;
                        }
                        email = parts[1];
                        nameOfItem = string.Join(" ", parts.Skip(2));
                        StopSharingItem(email, nameOfItem, user);
                        break;
                    case "back":
                        var logInMenu = new LogInAction(_userRepository, _folderRepository, _fileRepository, _shareRepository, _commentRepository);
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
            var refreshFiles = new MyDisk(RepositoryFactory.Create<UserRepositroy>(), RepositoryFactory.Create<FolderRepository>(), RepositoryFactory.Create<FileRepository>(), RepositoryFactory.Create<ShareRepository>(), RepositoryFactory.Create<CommentRepository>(), user);
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
                    CreateFile(name, user, parentFolderId);
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
            if (name == "Root")
            {
                CurrentFolder = _folderRepository.GetRootFolder("Root", user);
                Console.WriteLine($"You entered the root folder: {CurrentFolder?.Name}");
                return;
            }

            var enteredFolder = _folderRepository.GetFolderByNameAndParentFolder(name, user, CurrentFolder?.Id ?? 0);            
            if (enteredFolder == null)
            {
                Console.WriteLine($"Folder '{name}' does not exist in the current context (Parent Folder: '{CurrentFolder?.Name ?? "None"}').");
                return;
            }

            CurrentFolder = enteredFolder;
            Console.WriteLine($"You entered the folder: {CurrentFolder.Name}");
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
            EditFileProcess(file, user);
        }
        private void EditFileProcess(File file, User user)
        {
            Console.Clear();
            Console.WriteLine($"Editing file - {file.Name}: \nType :help for a list of commands.\n");
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
                        if (command == "open comments")
                        {
                            CommandPromptForComments(file, user);
                            break;
                        }
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
            if (user.Id == file.OwnerId)
            {
                RefreshCommandPrompt(user);
            }
            else
            {
                RefreshCommandPromptForEditShare(user);
            }

            
        }
        private bool HandleCommand(string command, ref List<string> lines, File file, ref bool isSaved)
        {
            switch (command.ToLower())
            {
                case "help":
                    HelpMenu.DisplayEditFileCommands();
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
                RenameFile(file, user);
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
        private void ShareItem(string email, string nameOfItem, User userSharedBy)
        {
            var userForShare = _userRepository.GetUserByMail(email);
            if (userForShare == null)
            {
                Console.WriteLine($"User with email: {email} doesn't exists.");
                return;
            }
            if (nameOfItem == "Root")
            {
                Console.WriteLine("You can't Share Root folder.");
                return;
            }
            var folder = _folderRepository.GetFolderByNameAndParentFolder(nameOfItem, userSharedBy, CurrentFolder.Id);
            if (folder != null)
            {
                ShareFolder(folder, userSharedBy, userForShare);
                return;
            }
            var file = _fileRepository.GetFileByNameAndFolder(nameOfItem, userSharedBy, CurrentFolder.Id);
            if (file != null)
            {
                ShareFile(file, userSharedBy, userForShare);
                return;
            }

            Console.WriteLine("The item with the specified name does not exist.");
        }
        private void ShareFolder(Folder folder, User sharedByUser, User sharedWithUser)
        {

            var share = new Share
            {
                ItemId = folder.Id,
                ItemType = ItemType.Folder,
                SharedById = sharedByUser.Id,
                SharedWithId = sharedWithUser.Id
            };
            var response = _shareRepository.Add(share);

            var filesInFolder = _fileRepository.GetFileByFolderAndOwner(folder, sharedByUser);
            foreach (var file in filesInFolder)
            {
                ShareFile(file, sharedByUser, sharedWithUser);
            }

            var subFolders = _folderRepository.GetFileByParentFolderAndOwner(folder, sharedByUser);
            foreach (var subFolder in subFolders)
            {
                ShareFolder(subFolder, sharedByUser, sharedWithUser);
            }

            Console.WriteLine($"Folder {folder.Name} and its contents successfully shared.");
        }
        private void ShareFile(File file, User sharedByUser, User sharedWithUser)
        {
            var share = new Share
            {
                ItemId = file.Id,
                ItemType = ItemType.File,
                SharedById = sharedByUser.Id,
                SharedWithId = sharedWithUser.Id
            };
            var response = _shareRepository.Add(share);
            Console.WriteLine($"File {file.Name} successfully shared.");
        }
        private void StopSharingItem(string email, string nameOfItem, User userSharedBy)
        {
            var sharedToUser = _userRepository.GetUserByMail(email);
            if (sharedToUser == null)
            {
                Console.WriteLine($"User with email: {email} doesn't exists.");
                return;
            }
            var folder = _folderRepository.GetFolderByNameAndParentFolder(nameOfItem, userSharedBy, CurrentFolder.Id);
            if (folder != null)
            {
                StopSharingFolder(folder, userSharedBy, sharedToUser);
                return;
            }
            var file = _fileRepository.GetFileByNameAndFolder(nameOfItem, userSharedBy, CurrentFolder.Id);
            if (file != null)
            {
                StopSharingFile(file, userSharedBy, sharedToUser);
                return;
            }
            Console.WriteLine("The item with the specified name does not exist or is not shared with the specified user.");

        }
        private void StopSharingFolder(Folder folder, User sharedByUser, User sharedWithUser)
        {
            var share = _shareRepository.GetShare(sharedByUser, sharedWithUser, folder.Id);
            if (share == null)
            {
                Console.WriteLine($"Folder with ID: {folder.Id} is not shared with user {sharedWithUser.Name}.");
                return;
            }
            var response = _shareRepository.Delete(share);
            Console.WriteLine($"Folder: {folder.Name} it no longer shared with {sharedWithUser.Name}.");
            var filesInFolder = _fileRepository.GetFileByFolderAndOwner(folder, sharedByUser);
            foreach ( var file in filesInFolder)
            {
                StopSharingFile(file, sharedByUser, sharedWithUser);
            }

            var subFolders = _folderRepository.GetFileByParentFolderAndOwner(folder, sharedByUser);
            foreach (var subFolder in subFolders)
            {
                StopSharingFolder(subFolder, sharedByUser, sharedWithUser);
            }
        }
        private void StopSharingFile(File file, User sharedByUser, User sharedWithUser)
        {

            var share = _shareRepository.GetShare(sharedByUser, sharedWithUser, file.Id);
            if (share == null)
            {
                Console.WriteLine($"File with ID: {file.Id} is not shared with user {sharedWithUser.Name}.");
                return;
            }
            var response = _shareRepository.Delete(share);
            Console.WriteLine($"File: {file.Name} it no longer shared with {sharedWithUser.Name}.");
        }        

        public void CommandPromptForEditShare(User user, IEnumerable<Folder> sharedFolders, IEnumerable<File> sharedFiles)
        {          
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
                        HelpMenu.DisplayEditSharedItemsCommands();
                        break;                                          
                    case "enter.folder":
                        EnterSharedFolder(name, user, sharedFolders);
                        break;
                    case "edit.file":
                        EditSharedFile(name, user, sharedFiles);
                        break;
                    case "delete.f":
                        DeleteSharedItem(name, user, sharedFolders, sharedFiles);
                        break;                    
                    case "back":
                        var logInMenu = new LogInAction(_userRepository, _folderRepository, _fileRepository, _shareRepository, _commentRepository);
                        logInMenu.OpenDiskMenu(user);
                        break;
                    default:
                        Console.WriteLine("Invalid input, try again.");
                        Console.ReadKey();
                        continue;
                }
            }
        }
        private void RefreshCommandPromptForEditShare(User user)
        {
            var refreshFiles = new SharedWithMe(RepositoryFactory.Create<UserRepositroy>(), RepositoryFactory.Create<FolderRepository>(), RepositoryFactory.Create<FileRepository>(), RepositoryFactory.Create<ShareRepository>(), RepositoryFactory.Create<CommentRepository>(), user);
            refreshFiles.Open();
        }
        private void EnterSharedFolder(string name, User user, IEnumerable<Folder> sharedFolders)
        {
            
            var sharedFolder = sharedFolders.FirstOrDefault(s => s.Name == name);
            if (sharedFolder == null)
            {
                Console.WriteLine("The entered folder does not exist in your shared items.");
                return;
            }

            CurrentFolder = sharedFolder;
            Console.WriteLine($"You entered shared folder - {CurrentFolder?.Name}");
        }
        private void EditSharedFile(string name, User user, IEnumerable<File> sharedFiles)
        {            
            var file = _shareRepository.GetSharedFileByNameAndParentFolder(sharedFiles, name, CurrentFolder?.Id ?? 0);
            if (file is null)
            {
                Console.WriteLine("Entered name of File doesn't exist.");
                return;
            }
            EditFileProcess(file, user);
        }
        private void DeleteSharedItem(string name, User user, IEnumerable<Folder> sharedFolders, IEnumerable<File> sharedFiles)
        {
            var folderToDelete = _shareRepository.GetSharedFolderByNameAndParentFolder(sharedFolders, name, CurrentFolder?.Id ?? 0);
            if (folderToDelete != null)
            {
                DeleteSharedFolder(folderToDelete, user);
                return;
            }

            var fileToDelete = _shareRepository.GetSharedFileByNameAndParentFolder(sharedFiles, name, CurrentFolder?.Id ?? 0);
            if (fileToDelete != null)
            {
                DeleteSharedFile(fileToDelete, user);
                return;
            }

            Console.WriteLine("The item with the specified name does not exist.");
        }
        private void DeleteSharedFolder(Folder folder, User user)
        {
            if (!Confirmation.ConfirmationDialog("delete file"))
            {
                Console.WriteLine("Canceled delete action!");
                return;
            }
            var responseResult = _shareRepository.DeleteFolderFromShareWith(folder, user);

            if (responseResult == ResponseResultType.Success)
            {
                Console.WriteLine("Successfully deleted folder from Shared With Me.");
                Console.ReadKey();
                RefreshCommandPromptForEditShare(user);
            }
            else
                Console.WriteLine(ResponseHandler.ErrorMessage(responseResult));
        }
        private void DeleteSharedFile(File file, User user)
        {
            if (!Confirmation.ConfirmationDialog("delete file"))
            {
                Console.WriteLine("Canceled delete action!");
                return;
            }
            var responseResult = _shareRepository.DeleteFileFromShareWith(file, user);

            if (responseResult == ResponseResultType.Success)
            {
                Console.WriteLine("Successfully deleted file from Shared With Me.");
                Console.ReadKey();
                RefreshCommandPromptForEditShare(user);
            }
            else
                Console.WriteLine(ResponseHandler.ErrorMessage(responseResult));           

        }

        public void CommandPromptForComments(File file, User user)
        {
            Console.Clear();
            var allComments = _commentRepository.GetAllComments(file);
            if (!allComments.Any())
            {
                Console.WriteLine("This file doesn't have any comments.");                
            }
            else
            {
                foreach (var comment in allComments)
                    Writer.DisplayComments(comment);
            }
            

            while (true)
            {
                Console.Write("\nEnter a command for comments (help - for list of commands): ");
                string input = Console.ReadLine()?.Trim() ?? "";
                string[] parts = !string.IsNullOrEmpty(input) ? input.Split(" ") : Array.Empty<string>();
                if (parts.Length < 1)
                {
                    Console.WriteLine("Invalid input, try again");
                    continue;
                }
                var commentId = string.Join(" ", parts.Skip(1));
                var parsedId = _commentRepository.ValidId(commentId);
               
                
                switch (parts[0])
                {
                    case "help":
                        HelpMenu.DisplayCommentCommands();
                        break;
                    case "add.c":
                        AddComment(file, user);
                        break;
                    case "edit.c":
                        if (parsedId is null)
                        {
                            Console.WriteLine("Invalid format of id, have to be number.");
                            break;
                        }
                        EditComment(file,user,parsedId);
                        break;
                    case "delete.c":
                        if (parsedId is null)
                        {
                            Console.WriteLine("Invalid format of id, have to be number.");
                            break;
                        }
                        DeleteComment(file,user,parsedId);
                        break;
                    case "back":
                        EditFileProcess(file, user);
                        break;
                    default:
                        Console.WriteLine("Invalid input, try again (help - for a list of commands).");
                        Console.ReadKey();
                        continue;
                }
            }
        }

        private void AddComment(File file,  User author)
        {            
            string? newCommentContent;
            while (true)
            {
                Console.WriteLine("Enter a new comment: ");
                newCommentContent = Console.ReadLine();
                if (!string.IsNullOrEmpty(newCommentContent))
                    break;
                Console.WriteLine("Invalid input, new content cannot be empty.");
            }
            var newCommnet = new Comment
            {
                Content = newCommentContent,
                FileId = file.Id,
                AuthorId = author.Id,
                CreatedAt = DateTime.UtcNow,
                LastModified = DateTime.UtcNow
            };            
            var responseResult = _commentRepository.Add(newCommnet);
            if (responseResult == ResponseResultType.Success)
            {
                file.LastModifiedAt = DateTime.UtcNow;
                _fileRepository.Update(file);
                Console.WriteLine($"Succesfully added comment in '{file.Name}' file.");
                Console.ReadKey();
            }
            EditFileProcess(file, author);
        }
        private void DeleteComment(File file, User user, int? commentId)
        {
            var commentWithId = _commentRepository.GetCommentById(file, commentId);
            if (commentWithId is null)
            {
                Console.WriteLine($"Comment with id - {commentId} doesn't exists for this file.");
                return;
            }
            var responseResult = _commentRepository.Delete(commentWithId);

            if (responseResult == ResponseResultType.Success)
            {
                file.LastModifiedAt = DateTime.UtcNow;
                _fileRepository.Update(file);
                Console.WriteLine($"Succesfully deleted comment in '{file.Name}' file.");
                Console.ReadKey();
            }          

            EditFileProcess(file, user);
        }
        //treba ga upgradeati
        private void EditComment(File file, User user, int? commentId)
        {
            
            var comment = _commentRepository.GetCommentById(file, commentId);
            if (comment is null)
            {
                Console.WriteLine($"Comment with id - {commentId} doesn't exist for this file.");
                return;
            }

            Console.WriteLine($"Current comment content: {comment.Content}");
            Console.Write("Edit the comment (the current content is preloaded): ");

            string newContent = Console.ReadLine()?.Trim() ?? comment.Content;


            if (string.IsNullOrEmpty(newContent))
            {
                Console.WriteLine("Comment cannot be empty. Keeping the original content.");
                Console.ReadKey();
                return;
            }

            comment.Content = newContent;
            comment.LastModified = DateTime.UtcNow;

            var responseResult = _commentRepository.Update(comment);
            if (responseResult == ResponseResultType.Success)
            {
                file.LastModifiedAt = DateTime.UtcNow;
                _fileRepository.Update(file);
                Console.WriteLine("Comment updated successfully!");
                Console.ReadKey();
            }
            else
            {
                Console.WriteLine("Failed to update the comment. Please try again.");
                Console.ReadKey();
            }
            EditFileProcess(file, user);
        }


    }    
}
