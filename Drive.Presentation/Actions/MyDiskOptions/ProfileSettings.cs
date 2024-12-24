using Drive.Domain.Repositories;
using Drive.Presentation.Abstractions;


namespace Drive.Presentation.Actions.MyDiskOptions
{
    public class ProfileSettings : IAction
    {
        private readonly UserRepositroy _userRepository;
        public ProfileSettings(UserRepositroy userRepositroy)
        {
            _userRepository = userRepositroy;
        }
        public string Name { get; set; } = "Profile Settings";
        public int MenuIndex { get; set; }

        public void Open()
        {
            Console.WriteLine("Samo da nije password HAHHAH! Disk opcija 3.");
            Console.ReadKey();
        }
    }
}
