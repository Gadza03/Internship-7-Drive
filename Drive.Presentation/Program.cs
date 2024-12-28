using Drive.Presentation.Abstractions;
using Drive.Presentation.Actions.MenuOptions;
using Drive.Presentation.Actions.UserRegister;
using Drive.Presentation.Actions;
using Drive.Domain.Factories;
using Drive.Domain.Repositories;
using System.Security.Cryptography.Pkcs;
class Program
{
    static void Main(string[] args)
    {
        OpenMainMenu();
    }

    public static void OpenMainMenu()
    {
        var actions = new List<IAction> {
            new RegisterAction(RepositoryFactory.Create<UserRepositroy>(),RepositoryFactory.Create<FolderRepository>(),RepositoryFactory.Create<FileRepository>()),
            new LogInAction(RepositoryFactory.Create<UserRepositroy>(),RepositoryFactory.Create<FolderRepository>(),RepositoryFactory.Create<FileRepository>()),
            new ExitAction()
        };
        var mainMenu = new MainMenu(actions);
        mainMenu.Open();
    }
}