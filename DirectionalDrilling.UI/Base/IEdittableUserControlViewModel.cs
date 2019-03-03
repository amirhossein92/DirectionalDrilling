using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DirectionalDrilling.UI.Base
{
    public interface IEdittableUserControlViewModel
    {
        void LoadData(int selectedId);
        string ObjectName { get; set; }
        int SelectedId { get; set; }
    }
}
