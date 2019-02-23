using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DevExpress.XtraPrinting;

namespace DirectionalDrilling.UI.Base.Report
{
    public class DDLabel : DevExpress.XtraReports.UI.XRLabel
    {
        public DDLabel()
        {
            this.TextAlignment = TextAlignment.MiddleLeft;
            this.Font = new Font(FontFamily.GenericSansSerif, 10);
        }

    }
}