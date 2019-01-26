using System.Collections.Generic;
using System.Collections.ObjectModel;

namespace DirectionalDrilling.Model.Models
{
    public class Platform : NotifyPropertyChanged
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

        private ObservableCollection<Well> _wells;
        public ObservableCollection<Well> Wells
        {
            get => _wells;
            set
            {
                _wells = value;
                OnPropertyChanged();
            }
        }

        private ObservableCollection<PlatformRig> _platformRig;
        public ObservableCollection<PlatformRig> PlatformRig
        {
            get => _platformRig;
            set
            {
                _platformRig = value;
                OnPropertyChanged();
            }
        }

    }
}
