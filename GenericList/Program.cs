using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GenericList
{
    class Program
    {
        public static void Main()
        {
            GenericList<int> intList = new GenericList<int>(5);
            intList.AddElement(1);
            intList.AddElement(2);
            intList.AddElement(3);
            intList.AddElement(4);
            intList.AddElement(5);
            Console.WriteLine(intList);

            //Insert Element
            intList.InsertElement(3,8);
            Console.WriteLine(intList);

            //Max
            Console.WriteLine("Max");
            Console.WriteLine(intList.Max());
            //Min
            Console.WriteLine("Min");
            Console.WriteLine(intList.Min());

            //Remove Element
            Console.WriteLine();
            intList.RemoveElementByIndex(3);
            Console.WriteLine(intList);

            //Inser Element
            Console.WriteLine();
            intList.InsertElement(3, 10);
            Console.WriteLine(intList);


            //FInd Element
            Console.WriteLine("Find element index by value:");
            Console.WriteLine(intList.FindElement(3));


            Console.WriteLine("Clear");
            intList.ClearList();
            Console.WriteLine(intList);
            
        }
    }
}
