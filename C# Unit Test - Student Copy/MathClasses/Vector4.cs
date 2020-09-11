using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MathClasses
{
    public class Vector4
    {
        public float x, y, z, w;

        // Default Vector4 constructor
        public Vector4()
        {
            x = 0;
            y = 0;
            z = 0;
            w = 0;
        }

        // Vector 4 constructor passing values
        public Vector4(float _x, float _y, float _z, float _w)
        {
            x = _x;
            y = _y;
            z = _z;
            w = _w;
        }

        // Set up the operator to add 2 vectors
        public static Vector4 operator +(Vector4 lhs, Vector4 rhs)
        {
            return new Vector4(lhs.x + rhs.x, lhs.y + rhs.y, lhs.z + rhs.z, lhs.w + rhs.w);
        }
        // Set up the operator to subtract 2 vectors
        public static Vector4 operator -(Vector4 lhs, Vector4 rhs)
        {
            return new Vector4(lhs.x - rhs.x, lhs.y - rhs.y, lhs.z - rhs.z, lhs.w - rhs.w);
        }
        // Set up the operator to multiplu a vector by a float
        public static Vector4 operator *(Vector4 lhs, float rhs)
        {
            return new Vector4(lhs.x * rhs, lhs.y * rhs, lhs.z * rhs, lhs.w * rhs);
        }
        // Set up the operator to multiply a float by a vector
        public static Vector4 operator *(float lhs, Vector4 rhs)
        {
            return rhs * lhs;
        }

        // Set up the operator to divide a vector by a float
        public static Vector4 operator /(Vector4 lhs, float rhs)
        {
            if (rhs == 0 || lhs.x == 0)
            {
                throw new DivideByZeroException();
            }

            return new Vector4(lhs.x / rhs, lhs.y / rhs, lhs.z / rhs, lhs.w / rhs);
        }
        // Set up the operator to divide a float by a vector
        public static Vector4 operator /(float lhs, Vector4 rhs)
        {
            return rhs / lhs;
        }

        // Calculate the Magnitude of the Vector4
        public float Magnitude()
        {

            float result = 0f;
            float xValue = x * x;
            float yValue = y * y;
            float zValue = z * z;
            float wValue = w * w;

            result = (float)Math.Sqrt((double)(xValue + yValue + zValue + wValue));
            return result;
        }

        public float MagnitudeSqr()
        {
            return (x * x + y * y + z * z + w * w);
        }

        // Calculate the Cross
        public Vector4 Cross(Vector4 vectorToCross)
        {
            return new Vector4(
                                  y * vectorToCross.z - z * vectorToCross.y,
                                  z * vectorToCross.x - x * vectorToCross.z,
                                  x * vectorToCross.y - y * vectorToCross.x,
                                  w * vectorToCross.w - w * vectorToCross.w
                              );
        }

        // calculate the dotproduct
        public float Dot(Vector4 vectorToDot)
        {
            return x * vectorToDot.x +
                    y * vectorToDot.y +
                    z * vectorToDot.z +
                    w * vectorToDot.w;
        }

        //Normalises the values
        public void Normalize()
        {
            float m = Magnitude();
            this.x /= m;
            this.y /= m;
            this.z /= m;
            this.w /= m;
        }

    }
}
