using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Humanizer;
using UserControl = System.Windows.Controls.UserControl;

namespace DirectionalDrilling.UI.Base
{
    public abstract class UserControlViewBase : UserControl
    {
        public UserControlViewBase()
        {
            var className = this.GetType().Name;
            _header = this.GetType().Name.Substring(0, className.Length - 4).Humanize(LetterCasing.Title);
        }
        public abstract void Instantiated();

        public UserControlViewModelBase UserControlViewModel { get; set; }

        private string _header;
        public string Header
        {
            get => _header;
            set => _header = value;
        }
    }
}
