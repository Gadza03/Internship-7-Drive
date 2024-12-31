using Drive.Presentation.Abstractions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Drive.Presentation.Actions.MenuOptions
{
    public class ProfileSettingsMenu : BaseMenuAction
    {
        public ProfileSettingsMenu(List<IAction> actions) : base(actions, "Profile Settings")
        { }
    }
}
