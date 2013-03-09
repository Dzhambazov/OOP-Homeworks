using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _01.Shape
{
    class Test
    {
        public static void Main()
        {
            Shape[] shapes = {
                               new Triangle(2.3,5.2),
                               new Rectangle(6.3,2.5),
                               new Circle(4,4)
                           };
            foreach (var shape in shapes)
            {
                Console.WriteLine(shape.CalculateSurface());
            }
        }
    }
}
