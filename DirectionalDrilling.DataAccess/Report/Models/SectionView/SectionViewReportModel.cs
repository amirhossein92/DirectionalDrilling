using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DirectionalDrilling.DataAccess.Report.Models.SectionView
{
    public class SectionViewReportModel
    {
        public SectionViewReportModel()
        {
            
        }
        public string PlatformName { get; set; }
        public string WellName { get; set; }
        public string WellboreName { get; set; }
        public double VerticalSectionDirection { get; set; }
        public List<SectionViewReportModelChart> SectionViewReportModelCharts { get; set; }
    }
}
