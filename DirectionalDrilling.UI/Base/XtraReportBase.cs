using System;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using DevExpress.XtraReports.UI;
using DevExpress.XtraReports.UserDesigner;

namespace DirectionalDrilling.UI.Base
{
    public partial class XtraReportBase : DevExpress.XtraReports.UI.XtraReport
    {
        public XtraReportBase(string reportTitle)
        {
            InitializeComponent();
            this.ReportTitleLabel.Text = reportTitle;

        }

        public void UpdateHeaderData()
        {
            this.ReportTitleLabel.Text = ReportTitle;
        }

        public string ReportTitle { get; set; }
    }
}
