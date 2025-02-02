﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DevExpress.Data.Filtering.Helpers;
using DirectionalDrilling.DataAccess;
using DirectionalDrilling.Model.Models;
using DirectionalDrilling.UI.Base;
using DirectionalDrilling.UI.Commands;
using DirectionalDrilling.UI.Events;
using DirectionalDrilling.UI.UserControls.NewProjects.View;
using Prism.Events;
using BindableBase = Prism.Mvvm.BindableBase;

namespace DirectionalDrilling.UI.UserControls.NewProjects.ViewModel
{
    class AddPlatfromViewModel : UserControlViewModelBase
    {
        private IUnitOfWork _unitOfWork;
        private Platform _platform;
        private IEventAggregator _eventAggregator;

        public AddPlatfromViewModel(AddPlatfromView addPlatfromView,
            IUnitOfWork unitOfWork,
            IEventAggregator eventAggregator)
        {
            _eventAggregator = eventAggregator;
            UserControlView = addPlatfromView;
            _unitOfWork = unitOfWork;
            GetPlatform();

            SaveCommand = new RelayCommand(OnSaveCommand, CanSave);
            CancelCommand = new RelayCommand(OnCancelCommand);
        }



        public RelayCommand SaveCommand { get; private set; }
        public RelayCommand CancelCommand { get; private set; }

        public Platform Platform
        {
            get => _platform;
            set => SetProperty(ref _platform, value);
        }

        private void GetPlatform()
        {
            Platform = new Platform{Name = "Platform Jadid"};
        }

        private void CloseTab()
        {
            _eventAggregator.GetEvent<CloseTabEvent>().Publish();
        }

        private void OnCancelCommand()
        {
            CloseTab();
        }

        private bool CanSave()
        {
            return Platform.Name != null;
        }

        private void OnSaveCommand()
        {
            if (Platform.Id == 0)
            {
                _unitOfWork.PlatformService.Add(Platform);
            }

            CloseTab();
            RefreshTreeListData();
        }

    }
}