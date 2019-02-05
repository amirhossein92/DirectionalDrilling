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
using DevExpress.Xpf.Ribbon;
using DirectionalDrilling.UI.ViewModels;
using DirectionalDrilling.UI.Views;
using Prism.Events;
using MessageBox = System.Windows.Forms.MessageBox;

namespace DirectionalDrilling.UI
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : DXRibbonWindow
    {
        private SurveySelectionTreeListView _selectionTreeListUserControl;

        
        public MainWindow(MainWindowViewModel mainWindowViewModel, IEventAggregator eventAggregator)
        {
            InitializeComponent();
            this.DataContext = mainWindowViewModel;
            var gridView = new SurveyItemGridView(mainWindowViewModel, eventAggregator);
            var treeListView = new SurveySelectionTreeListView(eventAggregator);

            SecondGrid.Children.Add(gridView);
            SecondGrid.Children.Add(treeListView);
            treeListView.SetValue(Grid.ColumnProperty, 0);
            gridView.SetValue(Grid.ColumnProperty, 1);
            }

        public SurveySelectionTreeListView SelectionTreeListUserControl
        {
            get => _selectionTreeListUserControl;
        }
       
    }

   
}