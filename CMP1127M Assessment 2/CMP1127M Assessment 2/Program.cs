using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CMP1127M_Assessment_2
{

    //Scott Brown 16653221
    class Program
    {
        

        static void Main(string[] args)
        {
            string HexVal;
            string ColorVal;
            bool valid = false;
            string rhex = "";
            string ghex = "";
            string bhex = "";
            int rdec = 0;
            int gdec = 0;
            int bdec = 0;
            int rdecInv = 0;
            int gdecInv = 0;
            int bdecInv = 0;
            string rhexInv = "";
            string ghexInv = "";
            string bhexInv = "";


            while (!valid)
            {
                Console.WriteLine("Enter Hex Value");
                HexVal = Console.ReadLine();
                valid = check();
            }
            Invert();
            Mono();

            bool check()
            {
                if (HexVal[0] == '#')
                {
                    HexVal = HexVal.Substring(1,HexVal.Length-1);
                }

                if(HexVal.Length == 6)
                {
                    rhex = HexVal.Substring(0, 2);
                    ghex = HexVal.Substring(2, 2);
                    bhex = HexVal.Substring(4, 2);
                }
                else
                {
                    return false;
                }

                var builder = new StringBuilder();

                foreach (char c in HexVal)
                {
                    try
                    {
                        builder.Append(char.ToUpper(c));
                    }
                    catch (Exception)
                    {

                        builder.Append(c);
                    }
                    
                }
                HexVal = builder.ToString();

                try
                {
                    rdec = Convert.ToInt32(rhex, 16);
                    gdec = Convert.ToInt32(ghex, 16);
                    bdec = Convert.ToInt32(bhex, 16);

                    Console.WriteLine("#" + HexVal + " : (" + rdec.ToString() + "," + gdec.ToString() + "," + bdec.ToString() + ")");
                    return true;
                }
                catch (Exception)
                {

                    Console.WriteLine("Invalid Input");
                    return false;
                }
                

            }


            void Invert()
            {
                rdecInv = 255 - rdec;
                gdecInv = 255 - gdec;
                bdecInv = 255 - bdec;
                rhexInv = rdecInv.ToString("X2");
                ghexInv = gdecInv.ToString("X2");
                bhexInv = bdecInv.ToString("X2");
                Console.WriteLine("#" + rhexInv + ghexInv + bhexInv + " : (" + rdecInv.ToString() + "," + gdecInv.ToString() + "," + bdecInv.ToString() + ")");
            }


            void Mono()
            {
                int avg = (rdec + gdec + bdec) / 3;
                Console.WriteLine("Average: " + avg);
                int threshold = -1;
                while ((threshold > 256) || (threshold <= 0)) {
                    Console.WriteLine("Enter Threshold value between 0 and 255");
                    while (!Int32.TryParse(Console.ReadLine(), out threshold)) {
                        Console.WriteLine("Enter Threshold value between 0 and 255");
                    } ;
                }

                if (avg > threshold)
                {
                    Console.WriteLine("(" + rdec.ToString() + "," + gdec.ToString() + "," + bdec.ToString() + ") ---> White");
                }
                else
                {
                    Console.WriteLine("(" + rdec.ToString() + "," + gdec.ToString() + "," + bdec.ToString() + ") ---> Black");
                }
                
            }


            Console.ReadLine();



        }
    }
}
