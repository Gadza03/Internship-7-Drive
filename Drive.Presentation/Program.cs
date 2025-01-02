﻿using Drive.Presentation.Abstractions;
using Drive.Presentation.Actions.MenuOptions;
using Drive.Presentation.Actions.Authentication;
using Drive.Presentation.Actions;
using Drive.Domain.Factories;
using Drive.Domain.Repositories;
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
            new LogInAction(RepositoryFactory.Create<UserRepositroy>(),RepositoryFactory.Create<FolderRepository>(),RepositoryFactory.Create<FileRepository>(),RepositoryFactory.Create<ShareRepository>(),RepositoryFactory.Create<CommentRepository>()),
            new ExitAction()
        };
        var mainMenu = new MainMenu(actions);
        mainMenu.Open();
    }
}