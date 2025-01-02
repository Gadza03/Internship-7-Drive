using Drive.Presentation.Abstractions;

namespace Drive.Presentation.Actions.MenuOptions
{
    public class ProfileSettingsMenu : BaseMenuAction
    {
        public ProfileSettingsMenu(List<IAction> actions) : base(actions, "Profile Settings")
        { }
    }
}
