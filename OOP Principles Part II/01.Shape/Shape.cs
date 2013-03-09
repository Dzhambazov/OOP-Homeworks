using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _01.Shape
{
    abstract class Shape
    {

        private double width;
        private double height;
        public Shape(double width, double height)
        {
            this.Width = width;
            this.Height = height;
        }
        public abstract double CalculateSurface();

        public double Width
        {
            get { return width; }
            set
            {
                if (value <= 0)
                {
                    throw new ArgumentException("Width should be more than 0!");
                }
                else
                {
                    this.width = value;
                }
            }
        }

        public double Height
        {
            get { return height; }
            set
            {
                if (value <= 0)
                {
                    throw new ArgumentException("Height should be more than 0!");
                }
                else
                {
                    this.height = value;
                }
            }
        }
    }
}
