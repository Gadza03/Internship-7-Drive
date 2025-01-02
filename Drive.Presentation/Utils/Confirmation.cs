
namespace Drive.Presentation.Utils
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

        public static bool ConfiramtionResponse(string prompt)
        {
            if (!ConfirmationDialog(prompt))
            {
                Console.WriteLine($"Canceled {prompt} action.");
                return false;
            }
            return true;
        }
    }
}
