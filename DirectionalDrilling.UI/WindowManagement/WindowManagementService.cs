using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DirectionalDrilling.UI.Base;

namespace DirectionalDrilling.UI.WindowManagement
{
    public class WindowManagementService : IWindowManagementService
    {
        public void OpenWindowByViewModel<T>() where T : UserControlViewModelBase
        {
            throw new NotImplementedException();
        }
    }
}
