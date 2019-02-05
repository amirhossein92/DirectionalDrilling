using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Threading.Tasks;
using System.Windows;
using DirectionalDrilling.DataAccess;
using DirectionalDrilling.DataAccess.Survey;
using DirectionalDrilling.UI.ViewModels;
using DirectionalDrilling.UI.Views;
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
            var eventAggregator = new EventAggregator();
            var mainWindow =
                new MainWindow(new MainWindowViewModel(new SurveySelectionTreeListViewModel(eventAggregator)), eventAggregator);
            mainWindow.Show();
        }
    }
}
