using System.Collections.Generic;
using System.Collections.ObjectModel;

namespace DirectionalDrilling.Model.Models
{
    public class Survey : NotifyPropertyChanged
    {

        private int _id;
        public int Id
        {
            get => _id;
            set
            {
                _id = value;
                OnPropertyChanged();
            }
        }

        private string _name;
        public string Name
        {
            get => _name;
            set
            {
                _name = value;
                OnPropertyChanged();
            }
        }

        private int _wellboreId;
        public int WellboreId
        {
            get => _wellboreId;
            set
            {
                _wellboreId = value;
                OnPropertyChanged();
            }
        }

        private double _verticalSectionDirection;
        public double VerticalSectionDirection
        {
            get => _verticalSectionDirection;
            set
            {
                _verticalSectionDirection = value;
                OnPropertyChanged();
            }
        }

        private ObservableCollection<SurveyItem> _surveyItems;
        public ObservableCollection<SurveyItem> SurveyItems
        {
            get => _surveyItems;
            set
            {
                _surveyItems = value;
                OnPropertyChanged();
            }
        }

        private Wellbore _wellbore;
        public Wellbore Wellbore
        {
            get => _wellbore;
            set
            {
                _wellbore = value;
                OnPropertyChanged();
            }
        }

        private SurveyTieIn _surveyTieIn;
        public SurveyTieIn SurveyTieIn
        {
            get => _surveyTieIn;
            set
            {
                _surveyTieIn = value;
                OnPropertyChanged();
            }
        }


    }
}
