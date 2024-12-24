using Drive.Domain.Repositories;
using Drive.Presentation.Abstractions;

namespace Drive.Presentation.Actions.MyDiskOptions
{
    public class MyDisk : IAction
    {
        private readonly UserRepositroy _userRepository;
        public MyDisk(UserRepositroy userRepositroy)
        {
            _userRepository = userRepositroy;
        }
        public string Name { get; set; } = "My Disk";
        public int MenuIndex { get; set; }

        public void Open()
        {
            Console.WriteLine("Samo da nije password HAHHAH! Disk opcija 1.");
            Console.ReadKey();
        }
    }
}
