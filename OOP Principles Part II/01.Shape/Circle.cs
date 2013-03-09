using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _01.Shape
{
    class Circle : Shape
    {
        public Circle(double width, double height)
            : base(width, height)
        {
            if (width != height)
            {
                throw new ArgumentException("Circle's width should be equal to it's height");
            }
        }

        public override double CalculateSurface()
        {
            return (this.Width / 2) * (this.Width / 2) * Math.PI; // radius * radius * PI    if  width = Diameter ==>   radius = width/2
        }
    }
}
