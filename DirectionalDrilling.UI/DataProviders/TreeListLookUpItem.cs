using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DirectionalDrilling.Model;

namespace DirectionalDrilling.UI.DataProviders
{
    public class TreeListLookUpItem : NotifyPropertyChanged
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

        private int _parentId;
        public int ParentId
        {
            get => _parentId;
            set
            {
                _parentId = value;
                OnPropertyChanged();
            }
        }

        private int _objectRealId;
        public int ObjectRealId
        {
            get => _objectRealId;
            set
            {
                _objectRealId = value;
                OnPropertyChanged();
            }
        }

        private TreeListStatus _status;
        public TreeListStatus Status
        {
            get => _status;
            set
            {
                _status = value;
                OnPropertyChanged();
            }
        }

    }

    public enum TreeListStatus
    {
        IsPlatform,
        IsWell,
        IsWellbore,
        IsSurvey
    }
}
