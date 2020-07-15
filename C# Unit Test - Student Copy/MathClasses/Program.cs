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


            Console.WriteLine("RotateY");
            Matrix3 m3b = new Matrix3();
            m3b.SetRotateY(1.76f);
            Console.WriteLine(m3b.ToString());
            Console.WriteLine();
            Matrix3 rotateY = new Matrix3(-0.188077f, 0, -0.982154f, 0, 1, 0, 0.982154f, 0, -0.188077f);
            Console.WriteLine(rotateY.ToString());
            Console.WriteLine();


            Console.WriteLine("RotateZ");
            Matrix3 m3e = new Matrix3();
            m3e.SetRotateZ(9.62f);
            Console.WriteLine(m3e.ToString());
            Console.WriteLine();
            Matrix3 yVal = new Matrix3(-0.981005f, -0.193984f, 0, 0.193984f, -0.981005f, 0, 0, 0, 1);
            Console.WriteLine(yVal.ToString());
            Console.WriteLine();


            Console.WriteLine("Matrix3Multiply");
            Matrix3 m3a = new Matrix3();
            m3a.SetRotateX(3.98f);
            Console.WriteLine(m3a.ToString());
            Console.WriteLine();
            Matrix3 m3c = new Matrix3();
            m3c.SetRotateZ(9.62f);
            Console.WriteLine(m3c.ToString());
            Console.WriteLine();


            Console.WriteLine("result");
            Matrix3 m3d = m3a * m3c;
            Console.WriteLine(m3d.ToString());
            Console.WriteLine();
            Console.WriteLine("expectes result");
            Matrix3 m3f = new Matrix3(-0.981004655361f, 0.129707172513f, 0.14424264431f, 0.193984255195f, 0.655946731567f, 0.729454636574f, 0, 0.743579149246f, -0.668647944927f);
            Console.WriteLine(m3f.ToString());
            Console.WriteLine();
            Console.ReadKey();


            Matrix4 m4a = new Matrix4();
            m4a.SetRotateX(4.5f);

            Matrix4 m4b =new Matrix4(1, 0, 0, 0, 0, -0.210796f, -0.97753f, 0, 0, 0.97753f, -0.210796f, 0, 0, 0, 0, 1);


            Console.WriteLine("Matrix4");
            Console.WriteLine("result");
            Console.WriteLine(m4a.ToString());
            Console.WriteLine();
            Console.WriteLine(m4b.ToString());
            Console.WriteLine();
            Console.WriteLine("expecte result");
            Console.WriteLine();
            Console.ReadKey();

            Matrix4 m4c = new Matrix4();
            m4c.SetRotateY(-2.6f);

            Matrix4 m4d = new Matrix4();
            m4d.SetRotateZ(0.72f);

            Matrix4 m4e = m4d * m4c;

            Matrix4 m4f =new Matrix4(-0.644213855267f, -0.565019249916f, 0.515501439571f, 0, -0.659384667873f, 0.751805722713f, 0, 0, -0.387556940317f, -0.339913755655f, -0.856888711452f, 0, 0, 0, 0, 1);
            Console.WriteLine("Matrix4 *");
            Console.WriteLine("result");
            Console.WriteLine(m4e.ToString());
            Console.WriteLine();
            Console.WriteLine(m4f.ToString());
            Console.WriteLine();
            Console.WriteLine("expecte result");
            Console.WriteLine();
            Console.ReadKey();


        }
    }
}
