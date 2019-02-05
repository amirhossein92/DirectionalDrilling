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
using DevExpress.Xpf.Grid;
using DirectionalDrilling.DataAccess.Platform;
using DirectionalDrilling.DataAccess.Survey;
using DirectionalDrilling.DataAccess.Well;
using DirectionalDrilling.DataAccess.Wellbore;
using DirectionalDrilling.UI.DataProviders;
using DirectionalDrilling.UI.ViewModels;
using Prism.Events;
using MessageBox = System.Windows.Forms.MessageBox;

namespace DirectionalDrilling.UI.Views
{
    /// <summary>
    /// Interaction logic for SurveySelectionTreeListView.xaml
    /// </summary>
    public partial class SurveySelectionTreeListView : UserControl
    {
        private SurveySelectionTreeListViewModel _surveySelectionTreeListViewModel;

        public SurveySelectionTreeListView(IEventAggregator eventAggregator)
        {
            _surveySelectionTreeListViewModel = new SurveySelectionTreeListViewModel(eventAggregator);
            this.DataContext = _surveySelectionTreeListViewModel;
            InitializeComponent();
        }

        //private void DataControlBase_OnSelectedItemChanged(object sender, SelectedItemChangedEventArgs e)
        //{
        //    var obj = (TreeListControl) sender;
        //    var selectedItem = (TreeListLookUpItem) obj.SelectedItem;
        //    if (selectedItem != null && selectedItem.SurveyId != 0)
        //        _surveySelectionTreeListViewModel.SelectedSurveyId = selectedItem.SurveyId;
        //}


    }
}
