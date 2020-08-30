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



            Console.WriteLine("Matrix3Multiply");
            Matrix3 m3aa = new Matrix3();
            m3aa.SetRotateX(3.98f);

            Matrix3 m3c = new Matrix3();
            m3c.SetRotateZ(9.62f);

            Matrix3 m3d = m3aa * m3c;

            Console.WriteLine("Result");
            Console.WriteLine(m3d.ToString());
            Matrix3 ma3 = new Matrix3(-0.981004655361f, 0.129707172513f, 0.14424264431f, 0.193984255195f, 0.655946731567f, 0.729454636574f, 0, 0.743579149246f, -0.668647944927f);
            Console.WriteLine("Expected");
            Console.WriteLine(ma3.ToString());
            Console.ReadKey();


            Console.WriteLine("Matrix3SetRotateZ");
            Matrix3 m3 = new Matrix3();
            m3.SetRotateZ(9.62f);
            Console.WriteLine("Result");
            Console.WriteLine(m3.ToString());
            Matrix3 m = new Matrix3(-0.981005f, -0.193984f, 0, 0.193984f, -0.981005f, 0, 0, 0, 1);
            Console.WriteLine("Expected");
            Console.WriteLine(m.ToString());
            Console.ReadKey();


            Console.WriteLine("Matrix3SetRotateX");
            Matrix3 m3a = new Matrix3();

            m3a.SetRotateX(3.98f);

            Console.WriteLine("Result");
            Console.WriteLine(m3a.ToString());
            Matrix3 ma = new Matrix3(1, 0, 0, 0, -0.668648f, -0.743579f, 0, 0.743579f, -0.668648f);
            Console.WriteLine("Expected");
            Console.WriteLine(ma.ToString());
            Console.ReadKey();






            Console.WriteLine("Vector3MatrixTransform");
            Matrix3 m3b = new Matrix3();

            m3b.SetRotateY(1.76f);
            Vector3 v3a = new Vector3(13.5f, -48.23f, 862);
            Vector3 v3b = m3b * v3a;
            Console.WriteLine("Result");
            Console.WriteLine(v3b.ToString());
            Vector3 v = new Vector3(844.077941895f, -48.2299995422f, -175.38130188f);
            Console.WriteLine("Expected");
            Console.WriteLine(v.ToString());
            Console.ReadKey();


            Console.WriteLine("ShiftRedToGreen");
            Console.WriteLine("Result");
            Colour c = new Colour();
            c.SetRed(0x5E);
            Console.WriteLine(c.GetGreen());
            Console.WriteLine(c.GetRed());
            Console.WriteLine(c.colour);
            c.ShiftRedToGreen();
            Console.WriteLine(c.GetGreen());
            Console.WriteLine(c.GetRed());
            Console.WriteLine(c.colour);
            Console.WriteLine("Expected");
            uint newC = 0x005E0000;
            Console.WriteLine(newC);
            Console.ReadKey();


        }
    }
}
