using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GSM
{
    class GSMTest
    {
        public static void PrintCalls(GSM obj)
        {
            foreach (var call in obj.CallHistory)
            {
                Console.WriteLine("------------------------------------------");
                Console.WriteLine("Call date: {0}", call.Date);
                Console.WriteLine("Call time: {0}", call.Time);
                Console.WriteLine("Dialed number: {0}", call.DialedNumber);
                Console.WriteLine("Duration: {0} seconds", call.Duration);
            }
        }

        public static void DelLongestCall(GSM obj)
        {
            int longestCallIndex = 0;
            if (obj.CallHistory.Count > 1)
            {
                for (int i = 1; i < obj.CallHistory.Count(); i++)
                {
                    if (obj.CallHistory[i].Duration > obj.CallHistory[longestCallIndex].Duration)
                    {
                        longestCallIndex = i;
                    }
                }
                obj.DeleteCall(longestCallIndex);
                Console.WriteLine("Longest has been call successfuly deleted!");
            }
        }


        public static void Main()
        {
            Battery galaxy3Battery = new Battery(BatteryType.LiIon, "SomeBrand", 120, 242);
            Display galaxy3Display = new Display(4.7, "16M");
            GSM galaxy3 = new GSM("Galaxy III", "Samsung", 1099.99, "Pesho", galaxy3Battery, galaxy3Display);

            Battery nokia92Battery = new Battery(BatteryType.NiMH,"SomeBrand",90,123);
            Display nokia92Display = new Display(2.9,"256K");
            GSM nokia92 = new GSM("N92","Nokia",499.99,"Gosho",nokia92Battery,nokia92Display);

            GSM[] allGSMs = new GSM[] { galaxy3, nokia92 };

            foreach (var gsm in allGSMs)
            {
                Console.WriteLine(gsm);
            }

            //  Test CllHistyory


            galaxy3.AddCall(DateTime.Now.ToShortDateString(),DateTime.Now.ToShortTimeString(),"+359898728327",362);
            galaxy3.AddCall(DateTime.Now.ToShortDateString(), DateTime.Now.ToShortTimeString(), "+359898474727", 291);
            galaxy3.AddCall(DateTime.Now.ToShortDateString(), DateTime.Now.ToShortTimeString(), "+359878272727", 87);

            PrintCalls(galaxy3);

            Console.WriteLine();
            Console.WriteLine("Total price: {0} lv.",galaxy3.TotalPrice(0.37));

            DelLongestCall(galaxy3);
            galaxy3.ClearAllCalls();
            Console.WriteLine("Call histyory has been successfully deleted!");
        }
     
    }
}
