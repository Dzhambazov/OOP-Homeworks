using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Animal
{
    class Program
    {
        static void Main(string[] args)
        {


            Dog[] dogs = {
                             new Dog("Sharo",5,Sex.male),
                             new Dog("Rex",3,Sex.male)
                         };
            Frogs[] frogs = {
                                new Frogs("Jabcho",2,Sex.male),
                                new Frogs("Jabinka",3,Sex.female)
                            };
            Cat[] cats = {
                             new TomCat("Tom",6),
                             new Kitten("Kotarana",4)
                         };

            Console.WriteLine(AverageAge(dogs));
            Console.WriteLine(AverageAge(frogs));
            Console.WriteLine(AverageAge(cats));

            Kitten kitten = new Kitten("kitty", 2);
            Console.WriteLine(kitten.ProduceSound());
            TomCat thomas = new TomCat("Tom",4);
            Console.WriteLine(thomas.ProduceSound());
        }
        public static double AverageAge(Animal[] arr)
        {
            double result = 0;
            foreach (var animal in arr)
            {
                result += animal.Age;
            }
            return result / arr.Length;
        }
    }
}
