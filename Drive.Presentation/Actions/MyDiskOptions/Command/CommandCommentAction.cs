using Drive.Data.Entities.Models;
using Drive.Domain.Enums;
using Drive.Domain.Repositories;
using Drive.Presentation.Actions.MenuOptions.SubMenus;
using Drive.Presentation.Helpers;
using Drive.Presentation.Utils;
using File = Drive.Data.Entities.Models.File;

namespace Drive.Presentation.Actions.MyDiskOptions.Command
{
    public class CommandCommentAction
    {
        private readonly UserRepositroy _userRepository;
        private readonly FolderRepository _folderRepository;
        private readonly FileRepository _fileRepository;
        private readonly ShareRepository _shareRepository;
        private readonly CommentRepository _commentRepository;
        private CommandAction _commandAction;

        public CommandCommentAction(UserRepositroy userRepositroy, FolderRepository folderRepository, FileRepository fileRepository, ShareRepository shareRepository, CommentRepository commentRepository)
        {
            _userRepository = userRepositroy;
            _folderRepository = folderRepository;
            _fileRepository = fileRepository;
            _shareRepository = shareRepository;
            _commentRepository = commentRepository;
            _commandAction = new CommandAction(_userRepository, _folderRepository, _fileRepository, _shareRepository, _commentRepository);
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
                        EditComment(file, user, parsedId);
                        break;
                    case "delete.c":
                        if (parsedId is null)
                        {
                            Console.WriteLine("Invalid format of id, have to be number.");
                            break;
                        }
                        DeleteComment(file, user, parsedId);
                        break;
                    case "back":                        
                        _commandAction.EditFileProcess(file, user);
                        break;
                    default:
                        Console.WriteLine("Invalid input, try again (help - for a list of commands).");
                        Console.ReadKey();
                        continue;
                }
            }
        }
        private void AddComment(File file, User author)
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
            _commandAction.EditFileProcess(file, author);
        }
        private void DeleteComment(File file, User user, int? commentId)
        {
            var comment = ValidateComment(file, user, commentId);
            if (comment == null)
                return;
            if (!Confirmation.ConfiramtionResponse("delete comment"))
                return;
            var responseResult = _commentRepository.Delete(comment);

            if (responseResult == ResponseResultType.Success)
            {
                file.LastModifiedAt = DateTime.UtcNow;
                _fileRepository.Update(file);
                Console.WriteLine($"Succesfully deleted comment in '{file.Name}' file.");
                Console.ReadKey();
            }
            _commandAction.EditFileProcess(file, user);
        }
        private void EditComment(File file, User user, int? commentId)
        {

            var comment = ValidateComment(file, user, commentId);
            if (comment == null)
                return;
            Console.Clear();
            Console.WriteLine($"Current comment content: {comment.Content}\n");
            Console.Write("Edit the comment (press enter to save current content): ");

            string newContent = Console.ReadLine()?.Trim() ?? comment.Content+"";


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
            _commandAction.EditFileProcess(file, user);
        }
        private Comment? ValidateComment(File file, User user, int? commentId)
        {

            var comment = _commentRepository.GetCommentById(file, commentId);
            if (comment is null)
            {
                Console.WriteLine($"Comment with id - {commentId} doesn't exist for this file.");
                Console.ReadKey();
                return null;
            }
            if (comment.AuthorId != user.Id)
            {
                Console.WriteLine("You can't change a comment that isn't yours.");
                Console.ReadKey();
                return null;
            }
            return comment;
        }
    }
}
