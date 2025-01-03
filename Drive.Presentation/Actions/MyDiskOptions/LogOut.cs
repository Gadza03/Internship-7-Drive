
using Drive.Presentation.Abstractions;

namespace Drive.Presentation.Actions.MyDiskOptions
{
    public class LogOut : IAction
    {       
        public string Name { get; set; } = "Log Out";
        public int MenuIndex { get; set; }

        public void Open()
        {
            Console.Clear();
            Console.WriteLine("Returning to main menu.");
            Program.OpenMainMenu();
            Console.ReadKey();
        }
    }
}
