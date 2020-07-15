using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MathClasses
{
    public class Matrix4
    {
        public float m1, m2, m3, m4, m5, m6, m7, m8, m9, m10, m11, m12, m13, m14, m15, m16;

        public Matrix4()
        {
            m1 = 1; m2 = 0; m3 = 0; m4 = 0;
            m5 = 0; m6 = 1; m7 = 0; m8 = 0;
            m9 = 0; m10= 0; m11= 1; m12= 0;
            m13= 0; m14= 0; m15= 0; m16= 1;
        }

        //public Matrix3(float v1, float v4, float v7, float v2, float v5, float v8, float v3, float v6, float v9)
        public Matrix4( float v1, float v2, float v3, float v4, float v5, float v6, float v7, float v8, 
                        float v9, float v10, float v11, float v12, float v13, float v14, float v15, float v16)
        {
            m1 = v1; m2 = v2; m3 = v3; m4 = v4;
            m5 = v5; m6 = v6; m7 = v7; m8 = v8;
            m9 = v9; m10 = v10; m11 = v11; m12 = v12;
            m13 = v13; m14 = v14; m15 = v15; m16 = v16;

        }

        public static Matrix4 operator *(Matrix4 lhs, Matrix4 rhs)
        {

            /* 
             *     L                    R
             *     m1  m2  m3  m4       m1  m2  m3  m4
             *     m5  m6  m7  m8       m5  m6  m7  m8   
             *     m9  m10 m11 m12      m9  m10 m11 m12 
             *     m13 m14 m15 m16      m13 m14 m15 m16
             */

            float valueOne = rhs.m1 * lhs.m1 + rhs.m2 * lhs.m5 + rhs.m3 * lhs.m9 + rhs.m4 * lhs.m13;
            float valueTwo = rhs.m1 * lhs.m2 + rhs.m2 * lhs.m6 + rhs.m3 * lhs.m10 + rhs.m4 * lhs.m14;
            float valueThree = rhs.m1 * lhs.m3 + rhs.m2 * lhs.m7 + rhs.m3 * lhs.m11 + rhs.m4 * lhs.m15;
            float valueFour = rhs.m1 * lhs.m4 + rhs.m2 * lhs.m8 + rhs.m3 * lhs.m12 + rhs.m4 * lhs.m16;

            float valueFive = rhs.m5 * lhs.m1 + rhs.m6 * lhs.m5 + rhs.m7 * lhs.m9 + rhs.m8 * lhs.m13;
            float valueSix = rhs.m5 * lhs.m2 + rhs.m6 * lhs.m6 + rhs.m7 * lhs.m10 + rhs.m8 * lhs.m14;
            float valueSeven  = rhs.m5 * lhs.m3 + rhs.m6 * lhs.m7 + rhs.m7 * lhs.m11 + rhs.m8 * lhs.m15;
            float valueEight = rhs.m5 * lhs.m4 + rhs.m6 * lhs.m8 + rhs.m7 * lhs.m12 + rhs.m8 * lhs.m16;

            float valueNine = rhs.m9 * lhs.m1 + rhs.m10 * lhs.m5 + rhs.m11 * lhs.m9 + rhs.m12 * lhs.m13;
            float valueTen = rhs.m9 * lhs.m2 + rhs.m10 * lhs.m6 + rhs.m11 * lhs.m10 + rhs.m12 * lhs.m14;
            float valueEleven = rhs.m9 * lhs.m3 + rhs.m10 * lhs.m7 + rhs.m11 * lhs.m11 + rhs.m12 * lhs.m15;
            float valueTwelve = rhs.m9 * lhs.m4 + rhs.m10 * lhs.m8 + rhs.m11 * lhs.m12 + rhs.m12 * lhs.m16;

            float valueThirteen = rhs.m13 * lhs.m1 + rhs.m14 * lhs.m5 + rhs.m15 * lhs.m9 + rhs.m16 * lhs.m13;
            float valueFourteen = rhs.m13 * lhs.m2 + rhs.m14 * lhs.m6 + rhs.m15 * lhs.m10 + rhs.m16 * lhs.m14;
            float valueFifteen = rhs.m13 * lhs.m3 + rhs.m14 * lhs.m7 + rhs.m15 * lhs.m11 + rhs.m16 * lhs.m15;
            float valueSixteen = rhs.m13 * lhs.m4 + rhs.m14 * lhs.m8 + rhs.m15 * lhs.m12 + rhs.m16 * lhs.m16;

            return new Matrix4(valueOne, valueTwo, valueThree, valueFour,
                                valueFive, valueSix, valueSeven, valueEight,
                                valueNine, valueTen, valueEleven, valueTwelve,
                                valueThirteen, valueFourteen, valueFifteen, valueSixteen);
        }

        /*
         *  1  2  3  4  x
         *  5  6  7  8  y
         *  9  10 11 12 z
         *  13 14 15 16 w
         */
        public static Vector4 operator *(Matrix4 lhs, Vector4 rhs)
        {
            float valueOne = (lhs.m1 * rhs.x) + (lhs.m5 * rhs.y) + (lhs.m9 * rhs.z) + (lhs.m13 * rhs.w);
            float valueTwo = (lhs.m2 * rhs.x) + (lhs.m6 * rhs.y) + (lhs.m10 * rhs.z) + (lhs.m14 * rhs.w);
            float valueThree = (lhs.m3 * rhs.x) + (lhs.m7 * rhs.y) + (lhs.m11 * rhs.z) + (lhs.m15 * rhs.w);
            float valueFour = (lhs.m4 * rhs.x) + (lhs.m8 * rhs.y) + (lhs.m12 * rhs.z) + (lhs.m16 * rhs.w);
            return new Vector4(valueOne, valueTwo, valueThree, valueFour);
        }


        public static Vector4 operator *(Vector4 lhs, Matrix4 rhs)
        {
            return rhs * lhs;
        }

        public void SetRotateX(float value)
        {
            m1  = 1;  m2 =  0;                       m3 = 0;                        m4 = 0;
            m5  = 0;  m6 =  (float)Math.Cos(value);  m7 = (float)Math.Sin(value);   m8 = 0;
            m9  = 0;  m10 = (float)-Math.Sin(value); m11 = (float)Math.Cos(value);  m12 = 0;
            m13 = 0;  m14 = 0;                       m15 = 0;                       m16 = 1;
        }
        //soh 
        //cah 
        //toa

        public void SetRotateY(float value)
        {
            m1 = (float)Math.Cos(value);  m2 = 0; m3 = (float)-Math.Sin(value); m4 = 0;
            m5 = 0;                       m6 = 1; m7 = 0;                       m8 = 0;
            m9 = (float)Math.Sin(value); m10= 0; m11= (float)Math.Cos(value);  m12= 0;
            m13 = 0;                      m14= 0; m15= 0;                       m16= 1;
        }

        public void SetRotateZ(float value)
        {
            m1 = (float)Math.Cos(value); m2 = (float)Math.Sin(value); m3 = 0; m4 = 0;
            m5 = (float)-Math.Sin(value); m6 = (float)Math.Cos(value); m7 = 0; m8 = 0;
            m9 = 0; m10 = 0; m11 = 1; m12 = 0;
            m13 = 0; m14 = 0; m15 = 0; m16 = 1;

        }

        public override string ToString()
        {

            return m1 + ", " + m2 + ", " + m3 + ", " + m4 + ", " + "\n" +
                    m5 + ", " + m6 + ", " + m7 + ", " + m8 + ", " + "\n" +
                    m9 + ", " + m10 + ", " + m11 + ", " + m12 + ", " + "\n" +
                    m13 + ", " + m14 + ", " + m15 + ", " + m16 + ", ";
        }


    }
}
