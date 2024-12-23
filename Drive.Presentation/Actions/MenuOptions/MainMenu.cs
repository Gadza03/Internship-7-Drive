using Drive.Presentation.Abstractions;

namespace Drive.Presentation.Actions.MenuOptions
{
    public class MainMenu : BaseMenuAction
    {
        public int MenuIndex { get; set; }
        public string Name { get; set; }
        public IList<IAction> Actions { get; set; }
        public MainMenu() : base(new List<IAction>
        {
            new RegisterAction(),
            new LogInAction()            
        })
        {
            Name = "Main Menu";          
        }
        
    }
}
