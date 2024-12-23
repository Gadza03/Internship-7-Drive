using Drive.Presentation.Abstractions;
using Drive.Presentation.Actions.MenuOptions;
using Drive.Presentation.Actions.UserRegister;
using Drive.Presentation.Actions;
using Drive.Domain.Factories;
using Drive.Domain.Repositories;
internal class Program
{
    private static void Main(string[] args)
    {
        var actions = new List<IAction> {
            new RegisterAction(RepositoryFactory.Create<UserRepositroy>()),
            new LogInAction(RepositoryFactory.Create<UserRepositroy>())            
        };
        var mainMenu = new MainMenu(actions);
        mainMenu.Open();
    }
}