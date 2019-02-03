using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace DirectionalDrilling.ViewModel
{
    public class MainWindowViewModel
    {
        public NavigationViewModel NavigationViewModel { get; private set; }
        public MainWindowViewModel(NavigationViewModel navigationViewModel)
        {
            NavigationViewModel = navigationViewModel;
        }

        public void Load()
        {
            NavigationViewModel.Load();
        }
    }
}
