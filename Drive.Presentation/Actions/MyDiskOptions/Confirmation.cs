using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Drive.Presentation.Actions.MyDiskOptions
{
    public static class Confirmation
    {
        public static bool ConfirmationDialog(string prompt)
        {
            while (true)
            {
                Console.Write($"Do you want to {prompt} (y/n): ");
                string choice = Console.ReadLine()?.Trim() ?? string.Empty;
                if (choice == "y")
                    return true;
                else if (choice == "n")
                    return false;
                
                Console.WriteLine("Invalid input type 'y' or 'n'. Try again.");
                Console.ReadKey();                   
            }
        }
    }
}
