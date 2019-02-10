using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DirectionalDrilling.DataAccess;
using DirectionalDrilling.Model.Models;
using DirectionalDrilling.UI.Base;
using DirectionalDrilling.UI.Commands;
using Microsoft.Win32;
using BindableBase = Prism.Mvvm.BindableBase;

namespace DirectionalDrilling.UI.UserControls.SurveyManagement.ViewModel
{
    class ImportSurveyViewModel : BindableBase, IUserControlViewModel
    {
        private string _filePath;
        private string _fileText;
        private ObservableCollection<SurveyItem> _importedSurveyItems;
        private int _selectedSurveyId;
        private UnitOfWork _unitOfWork;

        public ImportSurveyViewModel(int selectedSurveyId, UnitOfWork unitOfWork)
        {
            _selectedSurveyId = selectedSurveyId;
            _unitOfWork = unitOfWork;

            BrowseFile = new RelayCommand(OnBrowseFile);
            SaveCommand = new RelayCommand(OnSaveCommand, CanSave);
        }


        public RelayCommand BrowseFile { get; private set; }
        public RelayCommand SaveCommand { get; private set; }

        public ObservableCollection<SurveyItem> ImportedSurveyItems
        {
            get => _importedSurveyItems;
            set => SetProperty(ref _importedSurveyItems, value);
        }
        public string FilePath
        {
            get => _filePath;
            set => SetProperty(ref _filePath, value);
        }
        public string FileText
        {
            get => _fileText;
            set => SetProperty(ref _fileText, value);
        }

        private void OnBrowseFile()
        {
            OpenFileDialog openFileDialog = new OpenFileDialog();
            openFileDialog.Filter = "CSV Files (*.csv)|*.csv";
            if (openFileDialog.ShowDialog() == true)
                FilePath = openFileDialog.FileName;
            FileText = File.ReadAllText(FilePath);
            ImportedSurveyItems = new ObservableCollection<SurveyItem>();

            foreach (var line in File.ReadAllLines(FilePath))
            {
                var text = line.Split(',');
                var importedSurveyItem = new SurveyItem();

                importedSurveyItem.MeasuredDepth = Double.Parse(text[0]);
                importedSurveyItem.Inclination = Double.Parse(text[1]);
                importedSurveyItem.Azimuth = Double.Parse(text[2]);

                ImportedSurveyItems.Add(importedSurveyItem);
            }
            SaveCommand.RaiseCanExecuteChanged();
        }

        private bool CanSave()
        {
            // TODO: Can Save function
            return (_selectedSurveyId != 0) && (FilePath != null) && (ImportedSurveyItems.Count > 0);
        }

        private void OnSaveCommand()
        {
            foreach (var importedSurveyItem in ImportedSurveyItems)
            {
                importedSurveyItem.SurveyId = _selectedSurveyId;
                _unitOfWork.SurveyItemService.Add(importedSurveyItem);
            }

        }

    }
}
