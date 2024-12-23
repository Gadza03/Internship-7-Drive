using Drive.Presentation.Abstractions;

namespace Drive.Presentation.Actions
{
    public class ExitAction : IAction
    {
        public int MenuIndex { get; set; }
        public string Name { get; set; } = "Exit";

        public void Open()
        {            
            Console.Clear();
            Console.WriteLine("Exiting app...");
            Environment.Exit(0);
        }
    }
}
