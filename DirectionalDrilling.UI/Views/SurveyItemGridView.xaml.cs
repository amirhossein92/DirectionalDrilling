using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using DirectionalDrilling.UI.ViewModels;
using Prism.Events;

namespace DirectionalDrilling.UI.Views
{
    /// <summary>
    /// Interaction logic for SurveyItemGridView.xaml
    /// </summary>
    public partial class SurveyItemGridView : UserControl
    {
        public SurveyItemGridView(MainWindowViewModel mainWindowViewModel, IEventAggregator eventAggregator)
        {
            this.DataContext = new SurveyItemGridViewModel(mainWindowViewModel, eventAggregator);
            InitializeComponent();
        }
    }}
