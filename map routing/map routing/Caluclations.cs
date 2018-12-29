using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace map_routing
{
    class Caluclations
    {

        public static double distance(double x, double y, double x1, double y1)
        {
            double d = 0;
            d = (Math.Sqrt(Math.Pow((x - x1), 2) + Math.Pow((y - y1), 2)));
            return d;
        }


        public static Dictionary<int, double> calcDistance(double X, double Y, List<double> XPoints,List<double> YPoints, double R)
        {
            Dictionary<int, double> Validpoints = new Dictionary<int, double>();
            for (int i = 0; i < XPoints.Count; i++)
            {
                double X1 = XPoints[i];
                double Y1 = YPoints[i];
                double D = distance(X, Y, X1, Y1);
                if (D <= R)
                {
                    Validpoints.Add(i, D);
                }
            }
            return Validpoints;
        }
    }
}
