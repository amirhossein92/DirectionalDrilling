using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DirectionalDrilling.UI.Commands;
using UI.Check.ViewModel;

namespace UI.Check
{
    class MainWindowViewModel : BindableBase
    {
        private object _currentView;
        private ObservableCollection<object> _currentViews;
        private FirstViewModel _firstViewModel;
        private SecondViewModel _secondViewModel;

        public MainWindowViewModel()
        {
            LoadCommand = new RelayCommand(OnLoadCommand);
            _firstViewModel = new FirstViewModel(1);
            _secondViewModel = new SecondViewModel(2);
            CurrentViews = new ObservableCollection<object>();
        }

        
        public RelayCommand LoadCommand { get; private set; }
        public object CurrentView
        {
            get => _currentView;
            set
            {
                _currentView = value;
                OnPropertyChanged();
            }
        }

        public ObservableCollection<object> CurrentViews
        {
            get => _currentViews;
            set
            {
                _currentViews = value;
                OnPropertyChanged();
            }
        }

        private void OnLoadCommand()
        {
            var random = new Random();
            var i = random.Next(4);
            CurrentView = _secondViewModel;
            if (i > 1)
                CurrentView = _firstViewModel;
            if (!CurrentViews.Contains(CurrentView))
                CurrentViews.Add(CurrentView);
        }
    }
}