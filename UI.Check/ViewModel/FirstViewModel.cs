using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DirectionalDrilling.UI.Commands;

namespace UI.Check.ViewModel
{
    public class FirstViewModel
    {
        public FirstViewModel(int id)
        {
            CloseTab = new RelayCommand(OnCloseTab);

        }

        private void OnCloseTab()
        {
        }

        public RelayCommand CloseTab { get; private set; }


    }
}

