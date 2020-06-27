using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MathClasses
{
    public class Matrix3
    {
        public float m1, m2, m3, m4, m5, m6, m7, m8, m9;

        public Matrix3()
        {
            m1 = 1; m2 = 0; m3 = 0;
            m4 = 0; m5 = 1; m6 = 0;
            m7 = 0; m8 = 0; m9 = 1;
        }
        public Matrix3(float v1, float v4, float v7, float v2, float v5, float v8, float v3, float v6, float v9)
        {
            m1 = v1; m2 = v2; m3 = v3;
            m4 = v4; m5 = v5; m6 = v6;
            m7 = v7; m8 = v8; m9 = v9;
        }

        public static Matrix3 operator *(Matrix3 lhs, Matrix3 rhs)
        {

            /*
             *  m1 m2 m3	m1 m2 m3
             *  m4 m5 m6	m4 m5 m6
             *  m7 m8 m9	m7 m8 m9
             */

            float valueOne = lhs.m1 * rhs.m1 + lhs.m2 * rhs.m4 + lhs.m3 * rhs.m7;
            float valueTwo = lhs.m1 * rhs.m2 + lhs.m2 * rhs.m5 + lhs.m3 * rhs.m8;
            float valueThree = lhs.m1 * rhs.m3 + lhs.m2 * rhs.m6 + lhs.m3 * rhs.m9;
            float valueFour = lhs.m4 * rhs.m1 + lhs.m5 * rhs.m4 + lhs.m6 * rhs.m7;
            float valueFive = lhs.m4 * rhs.m2 + lhs.m5 * rhs.m5 + lhs.m6 * rhs.m8;
            float valueSix = lhs.m4 * rhs.m3 + lhs.m5 * rhs.m6 + lhs.m6 * rhs.m9;
            float valueSeven = lhs.m7 * rhs.m1 + lhs.m8 * rhs.m4 + lhs.m9 * rhs.m7;
            float valueEight = lhs.m7 * rhs.m2 + lhs.m8 * rhs.m5 + lhs.m9 * rhs.m8;
            float valueNine = lhs.m7 * rhs.m3 + lhs.m8 * rhs.m6 + lhs.m9 * rhs.m9;

            return new Matrix3(valueOne, valueTwo, valueThree,
                               valueFour, valueFive, valueSix,
                               valueSeven, valueEight, valueNine);
        }

        public static Matrix3 operator *(Matrix3 lhs, Vector3 rhs)
        {
            return new Matrix3();
        }


        public static Matrix3 operator *(Vector3 lhs, Matrix3 rhs)
        {
            return rhs * lhs;
        }

        public void SetRotateX(float value)
        {
            //m1 = 1; m2 = 0; m3 = 0;
            //m4 = 0; m5 = (float)Math.Cos(value); m6 = (float)Math.Sin(value);
            //m7 = 0; m8 = (float)-Math.Sin(value); m9 = (float)Math.Cos(value);
            m1 = 1; m2 = 0;                      m3 = 0;
            m4 = 0; m5 = (float)Math.Cos(value); m6 = (float)-Math.Sin(value);
            m7 = 0; m8 = (float)Math.Sin(value); m9 = (float)Math.Cos(value);

        }

        public void SetRotateY(float value)
        {
            //m1 = (float)Math.Cos(value); m2 = 0; m3 = (float)-Math.Sin(value);
            //m4 = 0; m5 = 1; m6 = 0;
            //m7 = (float)Math.Sin(value); m8 = 0; m9 = (float)Math.Cos(value);
            m1 = (float)Math.Cos(value);    m2 = 0;  m3 = (float)Math.Sin(value);
            m4 = 0;                         m5 = 1;  m6 = 0; 
            m7 = (float)-Math.Sin(value);   m8 = 0;  m9 = (float)Math.Cos(value);
        }

        public void SetRotateZ(float value)
        {
            //m1 = (float)Math.Cos(value); m2 = (float)Math.Sin(value); m3 = 0;
            //m4 = (float)-Math.Sin(value); m5 = (float)Math.Cos(value); m6 = 0;
            //m7 = 0; m8 = 0; m9 = 1;
            m1 = (float)Math.Cos(value); m2 = (float)-Math.Sin(value);  m3 = 0; 
            m4 = (float)Math.Sin(value); m5 = (float)Math.Cos(value);   m6 = 0;
            m7 = 0;                      m8 = 0;                        m9 = 1;
        }

        public override string ToString() {

            return  m1 + "," + m2 + "," + m3 + "\n" +
                    m4 + "," + m5 + "," + m6 + "\n" +
                    m7 + "," + m8 + "," + m9;
        }
    }
}