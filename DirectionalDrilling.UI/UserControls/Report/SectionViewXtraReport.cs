using System;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using DevExpress.XtraCharts;
using DevExpress.XtraReports.UI;

namespace DirectionalDrilling.UI.UserControls.Report
{
    public partial class SectionViewXtraReport : DirectionalDrilling.UI.Base.XtraReportBase
    {
        public SectionViewXtraReport(string reportHeaderTitle) : base(reportHeaderTitle)
        {
            InitializeComponent();
            this.Parameters["paramPaymentDate"].Value = DateTime.Now;

        }

    }
}
