﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DirectionalDrilling.DataAccess.Company;
using DirectionalDrilling.DataAccess.Platform;
using DirectionalDrilling.DataAccess.PlatformRig;
using DirectionalDrilling.DataAccess.Rig;
using DirectionalDrilling.DataAccess.Survey;
using DirectionalDrilling.DataAccess.SurveyItem;
using DirectionalDrilling.DataAccess.SurveyTieIn;
using DirectionalDrilling.DataAccess.Well;
using DirectionalDrilling.DataAccess.Wellbore;
using DirectionalDrilling.Model.Database;

namespace DirectionalDrilling.DataAccess
{
    public class UnitOfWork : IDisposable
    {
        private DirectionalDrillingContext _context;

        private ICompanyService _companyService;
        public ICompanyService CompanyService {
            get
            {
                if (CompanyService == null)
                {
                    _companyService = new CompanyService(_context);
                }
                return _companyService;
            }
        }

        private IPlatformService _platformService;
        public IPlatformService PlatformService
        {
            get
            {
                if (PlatformService == null)
                {
                    _platformService = new PlatformService(_context);
                }
                return _platformService;
            }
        }

        private IPlatformRigService _platformRigService;
        public IPlatformRigService PlatformRigService
        {
            get
            {
                if (PlatformRigService == null)
                {
                    _platformRigService = new PlatformRigService(_context);
                }
                return _platformRigService;
            }
        }

        private IRigService _rigService;
        public IRigService RigService
        {
            get
            {
                if (RigService == null)
                {
                    _rigService = new RigService(_context);
                }
                return _rigService;
            }
        }

        private ISurveyService _surveyService;
        public ISurveyService SurveyService
        {
            get
            {
                if (SurveyService == null)
                {
                    _surveyService = new SurveyService(_context);
                }
                return _surveyService;
            }
        }

        private ISurveyItemService _surveyItemService;
        public ISurveyItemService SurveyItemService
        {
            get
            {
                if (SurveyItemService == null)
                {
                    _surveyItemService = new SurveyItemService(_context);
                }
                return _surveyItemService;
            }
        }

        private ISurveyTieInService _surveyTieInService;
        public ISurveyTieInService SurveyTieInService
        {
            get
            {
                if (SurveyTieInService == null)
                {
                    _surveyTieInService = new SurveyTieInService(_context);
                }
                return _surveyTieInService;
            }
        }

        private IWellService _wellService;
        public IWellService WellService
        {
            get
            {
                if (WellService == null)
                {
                    _wellService = new WellService(_context);
                }
                return _wellService;
            }
        }

        private IWellboreService _wellboreService;
        public IWellboreService WellboreService
        {
            get
            {
                if (WellboreService == null)
                {
                    _wellboreService = new WellboreService(_context);
                }
                return _wellboreService;
            }
        }

        public UnitOfWork()
        {
            _context = new DirectionalDrillingContext();
        }

        public void Dispose()
        {
            _context.Dispose();
        }
    }
}