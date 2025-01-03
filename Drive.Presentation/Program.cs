using Drive.Presentation.Abstractions;
using Drive.Presentation.Actions.MenuOptions;
using Drive.Presentation.Actions.Authentication;
using Drive.Presentation.Actions;
using Drive.Domain.Factories;
using Drive.Domain.Repositories;
class Program
{
    static void Main(string[] args)
    {
        DisplayWelcomeScreen();
        OpenMainMenu();
    }

    public static void OpenMainMenu()
    {
        var actions = new List<IAction> {
            new RegisterAction(RepositoryFactory.Create<UserRepositroy>(),RepositoryFactory.Create<FolderRepository>(),RepositoryFactory.Create<FileRepository>()),
            new LogInAction(RepositoryFactory.Create<UserRepositroy>(),RepositoryFactory.Create<FolderRepository>(),RepositoryFactory.Create<FileRepository>(),RepositoryFactory.Create<ShareRepository>(),RepositoryFactory.Create<CommentRepository>()),
            new ExitAction()
        };
        var mainMenu = new MainMenu(actions);
        mainMenu.Open();
    }

    private static void DisplayWelcomeScreen()
    {      

        Console.ForegroundColor = ConsoleColor.Cyan;
        Console.WriteLine("====================================\n" +
            "\tWELCOME TO DUMP DRIVE\n" +
            "====================================");              
        Console.WriteLine("Manage your files effortlessly.");
        Console.ResetColor();
        Console.WriteLine("\nPress any key to continue...");
        Console.ReadKey(); 
    }
}