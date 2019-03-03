using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Reflection;
using System.Threading.Tasks;
using System.Windows;
using DirectionalDrilling.DataAccess;
using DirectionalDrilling.DataAccess.Survey;
using Ninject;
using Prism.Events;

namespace DirectionalDrilling.UI
{
    /// <summary>
    /// Interaction logic for App.xaml
    /// </summary>
    public partial class App : Application
    {
        protected override void OnStartup(StartupEventArgs e)
        {
            base.OnStartup(e);

            var kernel = new StandardKernel();
            kernel.Load(Assembly.GetExecutingAssembly());

            var mainWindowViewModel = kernel.Get<MainWindowViewModel>();
            mainWindowViewModel.MainWindow.Show();
        }
    }
}
