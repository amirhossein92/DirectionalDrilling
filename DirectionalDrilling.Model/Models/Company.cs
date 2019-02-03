using System.Collections.Generic;

namespace DirectionalDrilling.Model.Models
{
    public class Company : NotifyPropertyChanged
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

        private bool _isClient;
        public bool IsClient
        {
            get => _isClient;
            set
            {
                _isClient = value;
                OnPropertyChanged();
            }
        }

        private bool _isRigContractor;
        public bool IsRigContractor
        {
            get => _isRigContractor;
            set
            {
                _isRigContractor = value;
                OnPropertyChanged();
            }
        }

        private bool _isOperator;
        public bool IsOperator
        {
            get => _isOperator;
            set
            {
                _isOperator = value;
                OnPropertyChanged();
            }
        }

        private bool _isServiceCompany;
        public bool IsServiceCompany
        {
            get => _isServiceCompany;
            set
            {
                _isServiceCompany = value;
                OnPropertyChanged();
            }
        }

        private ICollection<PlatformRig> _platformRigs;
        public ICollection<PlatformRig> PlatformRigs
        {
            get => _platformRigs;
            set
            {
                _platformRigs = value;
                OnPropertyChanged();
            }
        }

        public override string ToString()
        {
            return _name;
        }
    }
}
