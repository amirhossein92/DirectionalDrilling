using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DirectionalDrilling.UI.DataProviders
{
    public class SectionViewGraph
    {
        public double X { get; set; }
        public string XString => X.ToString();
        public double Y { get; set; }

        public SectionViewGraph(double x, double y)
        {
            X = x;
            Y = y;
        }
    }
}
