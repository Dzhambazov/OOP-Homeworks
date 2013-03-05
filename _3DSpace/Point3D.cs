using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _3DSpace
{
    struct Point3D
    {
        public double XPoint { get; set; }
        public double YPoint { get; set; }
        public double ZPoint { get; set; }

        public Point3D(double XPoint, double YPoint, double ZPoint) :this()
        {
            this.XPoint = XPoint;
            this.YPoint = YPoint;
            this.ZPoint = ZPoint;
        }

        static readonly Point3D startPoint = new Point3D(0,0,0);

        public override string ToString()
        {
 	        StringBuilder result = new StringBuilder();
            result.AppendLine("X: " + this.XPoint);
            result.AppendLine("Y: " + this.YPoint);
            result.AppendLine("Z: " + this.ZPoint);
            return result.ToString();
        }
    }
}
