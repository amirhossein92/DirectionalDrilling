namespace DirectionalDrilling.Model.Models
{
    public class Wellbore : NotifyPropertyChanged
    {
        /// <summary>
        /// Wellbore Id
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
        /// Wellbore Name
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

        private int _wellId;
        public int WellId
        {
            get => _wellId;
            set
            {
                _wellId = value;
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

        private Well _well;
        public Well Well
        {
            get => _well;
            set
            {
                _well = value;
                OnPropertyChanged();
            }
        }
    }
}
