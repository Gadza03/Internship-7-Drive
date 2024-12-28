using Drive.Data.Entities.Models;
using Drive.Domain.Repositories;
using Drive.Presentation.Abstractions;


namespace Drive.Presentation.Actions.MyDiskOptions
{
    public class SharedWithMe : IAction
    {
        private readonly UserRepositroy _userRepository;
        private readonly FolderRepository _folderRepository;
        private readonly FileRepository _fileRepository;
        private User _user { get; set; }

        public SharedWithMe(UserRepositroy userRepositroy, FolderRepository folderRepository, FileRepository fileRepository, User user)
        {
            _userRepository = userRepositroy;
            _folderRepository = folderRepository;
            _fileRepository = fileRepository;
            _user = user;

        }
        public string Name { get; set; } = "Shared With Me";
        public int MenuIndex { get; set; }

        public void Open()
        {
            Console.WriteLine("Samo da nije password HAHHAH! Disk opcija 2.");
            Console.ReadKey();
        }
    }
}
