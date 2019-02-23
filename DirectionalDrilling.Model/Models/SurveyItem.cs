using System;

namespace DirectionalDrilling.Model.Models
{
    public class SurveyItem : NotifyPropertyChanged
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

        private int _surveyId;
        public int SurveyId
        {
            get => _surveyId;
            set
            {
                _surveyId = value;
                OnPropertyChanged();
            }
        }

        private DateTime? _date;
        public DateTime? Date
        {
            get => _date;
            set
            {
                _date = value;
                OnPropertyChanged();
            }
        }

        private double _measuredDepth;
        public double MeasuredDepth
        {
            get => _measuredDepth;
            set
            {
                _measuredDepth = value;
                OnPropertyChanged();
            }
        }

        private double _inclination;
        public double Inclination
        {
            get => _inclination;
            set
            {
                _inclination = value;
                OnPropertyChanged();
            }
        }

        private double _azimuth;
        public double Azimuth
        {
            get => _azimuth;
            set
            {
                _azimuth = value;
                OnPropertyChanged();
            }
        }

        private double _trueVerticalDepth;
        public double TrueVerticalDepth
        {
            get => _trueVerticalDepth;
            set
            {
                _trueVerticalDepth = value;
                OnPropertyChanged();
            }
        }

        private double _northing;
        public double Northing
        {
            get => _northing;
            set
            {
                _northing = value;
                OnPropertyChanged();
            }
        }

        private double _easting;
        public double Easting
        {
            get => _easting;
            set
            {
                _easting = value;
                OnPropertyChanged();
            }
        }

        private double _verticalSection;
        public double VerticalSection
        {
            get => _verticalSection;
            set
            {
                _verticalSection = value;
                OnPropertyChanged();
            }
        }
        
        private double _holeDiameter;
        public double HoleDiameter
        {
            get => _holeDiameter;
            set
            {
                _holeDiameter = value;
                OnPropertyChanged();
            }
        }


        private string _surveyTool;
        public string SurveyTool
        {
            get => _surveyTool;
            set
            {
                _surveyTool = value;
                OnPropertyChanged();
            }
        }

        private string _remark;
        public string Remark
        {
            get => _remark;
            set
            {
                _remark = value;
                OnPropertyChanged();
            }
        }

        private Survey _survey;
        public Survey Survey
        {
            get => _survey;
            set
            {
                _survey = value;
                OnPropertyChanged();
            }
        }
    }
}
