using Drive.Domain.Repositories;
using Drive.Presentation.Abstractions;


namespace Drive.Presentation.Actions.MyDiskOptions
{
    public class SharedWithMe : IAction
    {
        private readonly UserRepositroy _userRepository;
        public SharedWithMe(UserRepositroy userRepositroy)
        {
            _userRepository = userRepositroy;
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
