using Drive.Domain.Repositories;
using Drive.Presentation.Abstractions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
