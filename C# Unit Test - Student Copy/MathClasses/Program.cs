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
            byte red = 255;
            byte green = 200;
            byte blue = 150;
            byte alpha = 2;

            Colour colour = new Colour();
            colour.SetRed(red);
            colour.SetGreen(green);
            colour.SetBlue(blue);
            colour.SetAlpha(alpha);

            Console.WriteLine("Set Red too " + red + ". Retreived: " + colour.GetRed());
            Console.WriteLine("Set Green too " + green + ". Retreived: " + colour.GetGreen());
            Console.WriteLine("Set Blue too " + blue + ". Retreived: " + colour.GetBlue());
            Console.WriteLine("Set Alpha too " + alpha + ". Retreived: " + colour.GetAlpha());


            colour.SetBlue(red);
            Console.WriteLine("Set Red too " + red + ". Retreived: " + colour.GetRed());
            Console.WriteLine("Set Green too " + green + ". Retreived: " + colour.GetGreen());
            Console.WriteLine("Set Blue too " + blue + ". Retreived: " + colour.GetBlue());
            Console.WriteLine("Set Alpha too " + alpha + ". Retreived: " + colour.GetAlpha());
            Console.ReadKey();

            Console.ReadKey();
 
        }
    }
}
