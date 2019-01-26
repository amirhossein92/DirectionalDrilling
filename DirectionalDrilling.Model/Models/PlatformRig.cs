using System;

namespace DirectionalDrilling.Model.Models
{
    public class PlatformRig : NotifyPropertyChanged
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

        private int _rigId;
        public int RigId
        {
            get => _rigId;
            set
            {
                _rigId = value;
                OnPropertyChanged();
            }
        }

        private int _companyId;
        public int CompanyId
        {
            get => _companyId;
            set
            {
                _companyId = value;
                OnPropertyChanged();
            }
        }


        private DateTime? _startDate;
        public DateTime? StartDate
        {
            get => _startDate;
            set
            {
                _startDate = value;
                OnPropertyChanged();
            }
        }

        private DateTime? _endDate;
        public DateTime? EndDate
        {
            get => _endDate;
            set
            {
                _endDate = value;
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


        private Rig _rig;
        public Rig Rig
        {
            get => _rig;
            set
            {
                _rig = value;
                OnPropertyChanged();
            }
        }


        private Company _company;
        public Company Company
        {
            get => _company;
            set
            {
                _company = value;
                OnPropertyChanged();
            }
        }


    }
}
