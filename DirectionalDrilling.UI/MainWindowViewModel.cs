using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using DirectionalDrilling.Model;
using DirectionalDrilling.UI.ViewModels;

namespace DirectionalDrilling.UI
{
    public class MainWindowViewModel : NotifyPropertyChanged
    {
        private SurveySelectionTreeListViewModel _surveySelectionTreeListViewModel;
        private int _selectedSurveyId;

        public MainWindowViewModel(SurveySelectionTreeListViewModel surveySelectionTreeListViewModel)
        {
            _surveySelectionTreeListViewModel = surveySelectionTreeListViewModel;

            if (SelectedSurveyId != 0)
            {
                MessageBox.Show("Test");
            }
        }

        public int SelectedSurveyId{
            get
            {
                if (_surveySelectionTreeListViewModel.SelectedSurvey.SurveyId != 0)
                {
                    MessageBox.Show("Test");
                }
                return _surveySelectionTreeListViewModel.SelectedSurveyId; 
            }set
            {
                _selectedSurveyId = value;
                OnPropertyChanged();
            }
        }
    }
}
