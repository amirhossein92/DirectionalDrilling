using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DirectionalDrilling.Model.Models
{
    public class SurveyTieIn : NotifyPropertyChanged
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
            get => Easting;
            set
            {
                _easting = value;
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

