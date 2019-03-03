using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
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
using DevExpress.Xpf.Bars;
using DevExpress.Xpf.Grid;
using DevExpress.Xpf.Printing;
using DevExpress.Xpf.Ribbon;
using DirectionalDrilling.UI.Base;
using DirectionalDrilling.UI.UserControls.SurveySelectionTreeList;
using Prism.Events;
using MessageBox = System.Windows.Forms.MessageBox;

namespace DirectionalDrilling.UI
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : DXRibbonWindow
    {
        private MainWindowViewModel _mainWindowViewModel;
        public MainWindow()
        {
            InitializeComponent();
        }

        public void Instantiate()
        {
            _mainWindowViewModel.ReportBaseAction += ReportBaseAction;
        }

        public MainWindowViewModel MainWindowViewModel
        {
            get => _mainWindowViewModel;
            set => _mainWindowViewModel = value;
        }

        private void ReportBaseAction(XtraReportBase reportBase)
        {
            reportBase.UpdateHeaderData();
            PrintHelper.ShowRibbonPrintPreview(this, reportBase);
        }
    }
}