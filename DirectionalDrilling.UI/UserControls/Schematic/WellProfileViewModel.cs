using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DirectionalDrilling.DataAccess;
using DirectionalDrilling.Model.Models;
using DirectionalDrilling.UI.Base;
using DirectionalDrilling.UI.Commands;
using DirectionalDrilling.UI.DataProviders;
using BindableBase = Prism.Mvvm.BindableBase;

namespace DirectionalDrilling.UI.UserControls.Schematic
{
    class WellProfileViewModel : UserControlViewModelBase
    {
        // TODO: CHANGE ALL BINDING LIST TO OBSERVABLECOLLECTION AND IMPLEMENT STH TO ADD CHANGE OF ITEM NOTIFICATION
        // https://stackoverflow.com/questions/1427471/observablecollection-not-noticing-when-item-in-it-changes-even-with-inotifyprop

        private BindingList<Formation> _formations = new BindingList<Formation>();
        private Formation _selectedFormation = new Formation();
        private ObservableCollection<SectionViewGraph> _surveyItems;
        private int _selectedSurveyId;
        private Wellbore _selectedWellbore;
        private IUnitOfWork _unitOfWork;

        public WellProfileViewModel(int selectedSurveyId, IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
            _selectedSurveyId = selectedSurveyId;
            AddFormation = new RelayCommand(OnAddFormation);
            DeleteFormation = new RelayCommand(OnDeleteFormation);
        }


        public RelayCommand AddFormation { get; set; }
        public RelayCommand DeleteFormation { get; set; }
        public BindingList<Formation> Formations
        {
            get => _formations;
            set => SetProperty(ref _formations, value);
        }
        public Formation SelectedFormation
        {
            get => _selectedFormation;
            set => SetProperty(ref _selectedFormation, value);
        }
        public ObservableCollection<SectionViewGraph> SurveyItems
        {
            get => _surveyItems;
            set => SetProperty(ref _surveyItems, value);
        }

        public void LoadData()
        {
            _selectedWellbore = _unitOfWork.WellboreService.GetWellboreBySurveyId(_selectedSurveyId);
            Formations = new BindingList<Formation>(
                _unitOfWork.FormationService.GetformationsByWellboreId(_selectedWellbore.Id));

            SurveyItems = new ObservableCollection<SectionViewGraph>();
            var surveyItems = _unitOfWork.SurveyItemService.GetSurveyItemsBySurveyId(_selectedSurveyId);
            var text = "";
            foreach (var surveyItem in surveyItems)
            {
                // TODO: ADD VERTICAL SECTION
                SurveyItems.Add(new SectionViewGraph(surveyItem.VerticalSection, surveyItem.TrueVerticalDepth));
                text += $"{surveyItem.VerticalSection}, {surveyItem.TrueVerticalDepth}{Environment.NewLine}";

            }
        }

        private void OnAddFormation()
        {
            var lastFormation = Formations.OrderByDescending(item => item.FormationBottomTrueVerticalDepth)
                .FirstOrDefault();
            Formations.Add(new Formation
            {
                Name = "New Formation",
                Description = "Formation"
            });
        }

        private void OnDeleteFormation()
        {
            Formations.Remove(SelectedFormation);

        }
        public void CellEditEndingMethod()
        {
            foreach (var formation in Formations)
            {
                if (formation.WellboreId == 0)
                {
                    formation.WellboreId = _selectedWellbore.Id;
                    _unitOfWork.FormationService.Add(formation);
                }
                else
                {
                    _unitOfWork.FormationService.Update(formation);
                }
            }
        }

    }
}
