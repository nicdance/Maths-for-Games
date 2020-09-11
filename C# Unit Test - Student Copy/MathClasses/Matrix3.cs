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
            m1 = 1; m4 = 0; m7 = 0;
            m2 = 0; m5 = 1; m8 = 0;
            m3 = 0; m6 = 0; m9 = 1;
        }

        // Matrix 3 constructor
        public Matrix3(float v1, float v2, float v3, float v4, float v5, float v6, float v7, float v8, float v9)
        {
            m1 = v1; m4 = v4; m7 = v7;
            m2 = v2; m5 = v5; m8 = v8;
            m3 = v3; m6 = v6; m9 = v9;
        }

        // Override * operator between 2 Matrix3
        public static Matrix3 operator *(Matrix3 lhs, Matrix3 rhs)
        {
            /* L            R
           *  m1 m2 m3	m1 m2 m3
           *  m4 m5 m6	m4 m5 m6
           *  m7 m8 m9	m7 m8 m9
           */

            float valueOne = rhs.m1 * lhs.m1 + rhs.m2 * lhs.m4 + rhs.m3 * lhs.m7;
            float valueTwo = rhs.m1 * lhs.m2 + rhs.m2 * lhs.m5 + rhs.m3 * lhs.m8;
            float valueThree = rhs.m1 * lhs.m3 + rhs.m2 * lhs.m6 + rhs.m3 * lhs.m9;
            float valueFour = rhs.m4 * lhs.m1 + rhs.m5 * lhs.m4 + rhs.m6 * lhs.m7;
            float valueFive = rhs.m4 * lhs.m2 + rhs.m5 * lhs.m5 + rhs.m6 * lhs.m8;
            float valueSix = rhs.m4 * lhs.m3 + rhs.m5 * lhs.m6 + rhs.m6 * lhs.m9;
            float valueSeven = rhs.m7 * lhs.m1 + rhs.m8 * lhs.m4 + rhs.m9 * lhs.m7;
            float valueEight = rhs.m7 * lhs.m2 + rhs.m8 * lhs.m5 + rhs.m9 * lhs.m8;
            float valueNine = rhs.m7 * lhs.m3 + rhs.m8 * lhs.m6 + rhs.m9 * lhs.m9;

            return new Matrix3(valueOne, valueTwo, valueThree,
                               valueFour, valueFive, valueSix,
                               valueSeven, valueEight, valueNine);
        }


        // Override * operator Between aMatrix3 and Vector
        public static Vector3 operator *(Matrix3 lhs, Vector3 rhs)
        {
            float valueOne = (lhs.m1 * rhs.x) + (lhs.m4 * rhs.y) + (lhs.m7 * rhs.z);
            float valueTwo = (lhs.m2 * rhs.x) + (lhs.m5 * rhs.y) + (lhs.m8 * rhs.z);
            float valueThree = (lhs.m3 * rhs.x) + (lhs.m6 * rhs.y) + (lhs.m9 * rhs.z);
            return new Vector3(valueOne, valueTwo, valueThree);
        }


        // Override * operator Between aMatrix3 and Vector where Vecotr comes first
        public static Vector3 operator *(Vector3 lhs, Matrix3 rhs)
        {
            return rhs * lhs;
        }

        // Sets the X rotation of the Matrix
        public void SetRotateX(float value)
        {
            m1 = 1; m3 = 0;                         m7 = 0;
            m2 = 0; m5 = (float)Math.Cos(value);    m8 = (float)-Math.Sin(value);
            m3 = 0; m6 = (float)Math.Sin(value);    m9 = (float)Math.Cos(value);

        }

        // Sets the Y rotation of the Matrix
        public void SetRotateY(float value)
        {
            m1 = (float)Math.Cos(value);    m4 = 0;     m7 = (float)Math.Sin(value);
            m2 = 0;                         m5 = 1;     m8 = 0;
            m3 = (float)-Math.Sin(value);   m6 = 0;     m9 = (float)Math.Cos(value);
        }


        // Sets the Z rotation of the Matrix
        public void SetRotateZ(float value)
        {
            m1 = (float)Math.Cos(value);    m4 = (float)-Math.Sin(value);   m7 = 0;
            m2 = (float)Math.Sin(value);    m5 = (float)Math.Cos(value);    m8 = 0;
            m3 = 0;                         m6 = 0;                         m9 = 1;
        }

        // Takes in a matric2 and assigns hte values to this matrix
        public void Set(Matrix3 m)
        {
            m1 = m.m1; m4 = m.m4; m7 = m.m7;
            m2 = m.m2; m5 = m.m5; m8 = m.m8;
            m3 = m.m3; m6 = m.m6; m9 = m.m9;
        }

        // sets the scal fo the matrix
        public void SetScaled(float x, float y, float z)
        {
            m1 = x; m4 = 0; m7 = 0;
            m2 = 0; m5 = y; m8 = 0;
            m3 = 0; m6 = 0; m9 = z;
        }


        // sets the x and Y translation of the matrix
        public void SetTranslation(float x, float y)
        {
            m7 = x; m8 = y; m9 = 1;
        }

        // Translatesa the matrix int eh x y direction
        public void Translate(float x, float y)
        { 
            m7 += x; m8 += y;
        }


        // Override toString for testing purposes.
        public override string ToString() {

            return  m1 + "," + m4 + "," + m7 + "\n" +
                    m2 + "," + m5 + "," + m8 + "\n" +
                    m3 + "," + m6 + "," + m9;
        }
    }
}