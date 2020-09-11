using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MathClasses
{
    class Program
    {
        static void Main(string[] args)
        {
            // Testingthe Red to geenShift

            Console.WriteLine("ShiftRedToGreen");
            Console.WriteLine("Result");
            Colour c = new Colour();
            c.SetRed(0x5E);
            c.SetBlue(0x88);
            Console.WriteLine(c.GetRed());
            Console.WriteLine(c.GetGreen());
            Console.WriteLine(c.GetBlue());
            Console.WriteLine(c.GetAlpha());
            Console.WriteLine(c.colour);
            c.ShiftRedToGreen();
            Console.WriteLine(c.GetRed());
            Console.WriteLine(c.GetGreen());
            Console.WriteLine(c.GetBlue());
            Console.WriteLine(c.GetAlpha());
            Console.WriteLine(c.colour);
            Console.WriteLine("Expected");
            uint newC = 0x005E0000;
            Console.WriteLine(newC);
            Console.ReadKey();


        }
    }
}
