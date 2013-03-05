using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _3DSpace
{
    static class DistanceBtwPoints
    {
         public static double Distance(Point3D firstPoint, Point3D secondPoint)
        {
            double result = 0d;
            result = Math.Sqrt(Math.Pow(secondPoint.XPoint - firstPoint.XPoint,2)+Math.Pow(secondPoint.YPoint - firstPoint.YPoint,2) + 
                     Math.Pow(secondPoint.ZPoint - firstPoint.ZPoint,2));
            return result;
        }

       
    }
}
