using System.Collections.Generic;
using System.Collections.ObjectModel;

namespace DirectionalDrilling.Model.Models
{
    public class Rig : NotifyPropertyChanged
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


        private string _type;
        public string Type
        {
            get => _type;
            set
            {
                _type = value;
                OnPropertyChanged();
            }
        }


        private ObservableCollection<PlatformRig> _platformRigs;
        public ObservableCollection<PlatformRig> PlatformRigs
        {
            get => _platformRigs;
            set
            {
                _platformRigs = value;
                OnPropertyChanged();
            }
        }


    }
}
