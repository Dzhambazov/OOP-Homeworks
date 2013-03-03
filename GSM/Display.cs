using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GSM
{
    class Display
    {
        private double? size;
        private string colorsNum;

        public Display()
            : this(null, null)
        {
        }


        public Display(double size)
            : this(size, null)
        {
        }

        public Display(double? size, string colorsNum)
        {
            this.size = size;
            this.colorsNum = colorsNum;
        }


        public double? Size
        {
            get { return size; }
            set 
            {
                if (value >= 1)
                {
                    this.size = value;
                }
                else
                {
                    throw new ArgumentException("Display's size should be at least 1 inch!");
                }
            }
        }


        public string ColorsNum
        {
            get { return colorsNum; }
            set { this.colorsNum = value; }
        }


    }
}
