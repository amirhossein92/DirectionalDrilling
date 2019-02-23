using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UserControl = System.Windows.Controls.UserControl;

namespace DirectionalDrilling.UI.Base
{
    public abstract class UserControlViewBase : UserControl
    {
        public abstract void Instantiated();

        public UserControlViewModelBase UserControlViewModel { get; set; }
    }
}
