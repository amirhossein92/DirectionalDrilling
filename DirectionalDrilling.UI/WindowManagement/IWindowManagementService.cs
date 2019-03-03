using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DirectionalDrilling.UI.Base;

namespace DirectionalDrilling.UI.WindowManagement
{
    public interface IWindowManagementService
    {
        void OpenWindowByViewModel<T>(int selectedSurveyId) where T : UserControlViewModelBase;
        void OpenWindowByViewModel<T>() where T : UserControlViewModelBase;
        void OpenWindowForEditByViewModel<T>(int id) where T : UserControlViewModelBase;

    }
}
