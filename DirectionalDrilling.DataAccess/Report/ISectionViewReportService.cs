﻿using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DirectionalDrilling.DataAccess.Report.Models.SectionView;

namespace DirectionalDrilling.DataAccess.Report
{
    public interface ISectionViewReportService
    {
        ObservableCollection<SectionViewReportModel> GetSectionViewReportModels(int surveyId);
    }
}
