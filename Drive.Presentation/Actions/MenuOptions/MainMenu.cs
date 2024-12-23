using Drive.Domain.Factories;
using Drive.Domain.Repositories;
using Drive.Presentation.Abstractions;
using Drive.Presentation.Actions.UserRegister;

namespace Drive.Presentation.Actions.MenuOptions
{
    public class MainMenu : BaseMenuAction
    {
        public int MenuIndex { get; set; }
        public string Name { get; set; } = "Main Menu";
        public IList<IAction> Actions { get; set; }
        public MainMenu(List<IAction> actions) : base(actions)
        {
                     
        }
        
    }
}
