using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DevExpress.XtraPrinting;

namespace DirectionalDrilling.UI.Base.Report
{
    public class DDLabelValue : DevExpress.XtraReports.UI.XRLabel
    {
        public DDLabelValue()
        {
            this.TextAlignment = TextAlignment.MiddleCenter;
            this.Font = new Font(FontFamily.GenericSansSerif, 10, FontStyle.Bold);

        }
    }
}
