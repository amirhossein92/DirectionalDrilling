using System.Collections.Generic;
using System.Collections.ObjectModel;

namespace DirectionalDrilling.Model.Models
{
    public class Well : NotifyPropertyChanged
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

        private int _platformId;
        public int PlatformId
        {
            get => _platformId;
            set
            {
                _platformId = value;
                OnPropertyChanged();
            }
        }

        private ObservableCollection<Wellbore> _wellbores;
        public ObservableCollection<Wellbore> Wellbores
        {
            get => _wellbores;
            set
            {
                _wellbores = value;
                OnPropertyChanged();
            }
        }

        private Platform _platform;
        public Platform Platform
        {
            get => _platform;
            set
            {
                _platform = value;
                OnPropertyChanged();
            }
        }
    }
}
