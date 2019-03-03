using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DirectionalDrilling.DataAccess.Math
{
    public class MathService : IMathService
    {
        public static double CosDegree(double degrees)
        {
            return System.Math.Cos(DegreesToRadians(degrees));
        }

        public static double SinDegree(double degrees)
        {
            return System.Math.Sin(DegreesToRadians(degrees));
        }

        public static double DegreesToRadians(double degrees)
        {
            return degrees * System.Math.PI / 180.0;
        }

        public static double RadiansToDegrees(double radians)
        {
            return radians * 180 / System.Math.PI;
        }
    }
}
