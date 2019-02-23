namespace DirectionalDrilling.Model.Models
{
    public class Formation : NotifyPropertyChanged
    {
        public Formation()
        {
            
        }
        /// <summary>
        /// Formation Id
        /// </summary>
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

        /// <summary>
        /// Formation Name
        /// </summary>
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

        private double _formationTopMeasuredDepth;
        public double FormationTopMeasuredDepth
        {
            get => _formationTopMeasuredDepth;
            set
            {
                _formationTopMeasuredDepth = value;
                OnPropertyChanged();
            }
        }

        private double _formationTopTrueVerticalDepth;
        public double FormationTopTrueVerticalDepth
        {
            get => _formationTopTrueVerticalDepth;
            set
            {
                _formationTopTrueVerticalDepth = value;
                OnPropertyChanged();
            }
        }

        private double _formationBottomMeasuredDepth;
        public double FormationBottomMeasuredDepth
        {
            get => _formationBottomMeasuredDepth;
            set
            {
                _formationBottomMeasuredDepth = value;
                OnPropertyChanged();
            }
        }

        private double _formationBottomTrueVerticalDepth;
        public double FormationBottomTrueVerticalDepth
        {
            get => _formationBottomTrueVerticalDepth;
            set
            {
                _formationBottomTrueVerticalDepth = value;
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

        private string _description;
        public string Description
        {
            get => _description;
            set
            {
                _description = value;
                OnPropertyChanged();
            }
        }

        private string _color;
        public string Color
        {
            get => _color;
            set
            {
                _color = value;
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
    }
}
