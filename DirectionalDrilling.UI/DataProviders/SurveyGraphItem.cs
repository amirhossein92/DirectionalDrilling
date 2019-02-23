using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Prism.Mvvm;

namespace DirectionalDrilling.UI.DataProviders
{
    public class SurveyGraphItem : BindableBase
    {
        private double _measuredDepth;
        public double MeasuredDepth
        {
            get => _measuredDepth;
            set => SetProperty(ref _measuredDepth, value);
        }

        private double _trueVerticalDepth;
        public double TrueVerticalDepth
        {
            get => _trueVerticalDepth;
            set => SetProperty(ref _trueVerticalDepth, value);
        }

        private double _northing;
        public double Northing
        {
            get => _northing;
            set => SetProperty(ref _northing, value);
        }

        private double _easting;
        public double Easting
        {
            get => _easting;
            set => SetProperty(ref _easting, value);
        }

        private double _verticalSection;
        public double VerticalSection
        {
            get => _verticalSection;
            set => SetProperty(ref _verticalSection, value);
        }
    }
}
