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
using DevExpress.Xpf.Charts;

namespace DirectionalDrilling.UI.UserControls.Schematic
{
    /// <summary>
    /// Interaction logic for WellProfileView.xaml
    /// </summary>
    public partial class WellProfileView : UserControl
    {
        public WellProfileView()
        {
            InitializeComponent();
        }

        private void Export_OnClick(object sender, RoutedEventArgs e)
        {
            ChartControl.ShowPrintPreview(this, PrintSizeMode.Stretch);
        }
    }
}