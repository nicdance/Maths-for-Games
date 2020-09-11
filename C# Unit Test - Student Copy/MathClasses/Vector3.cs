using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using System.Xml;
using System.Xml.Schema;

namespace MathClasses
{
    public class Vector3
    {
        public float x, y, z;

        public Vector3()
        {
            x = 0;
            y = 0;
            z = 0;
        }

        public Vector3(float _x, float _y, float _z) {
            x = _x;
            y = _y;
            z = _z;
        }

        // Set up the operator to add 2 vectors
        public static Vector3 operator +(Vector3 lhs, Vector3 rhs)
        {
            return new Vector3(lhs.x + rhs.x, lhs.y + rhs.y, lhs.z + rhs.z);
        }

        // Set up the operator to subtract 2 vectors
        public static Vector3 operator -(Vector3 lhs, Vector3 rhs)
        {
            return new Vector3(lhs.x - rhs.x, lhs.y - rhs.y, lhs.z - rhs.z);
        }
        
        // Set up the operator to multiplu a vector by a float
        public static Vector3 operator *(Vector3 lhs, float rhs)
        {
            return new Vector3(lhs.x * rhs, lhs.y * rhs, lhs.z * rhs);
        }
        
        // Set up the operator to multiply a float by a vector
        public static Vector3 operator *(float lhs, Vector3 rhs)
        {
            return rhs*lhs;
        }

        // Set up the operator to divide a vector by a float
        public static Vector3 operator /(Vector3 lhs, float rhs)
        {
            if (rhs== 0 || lhs.x == 0)
            {
                throw new DivideByZeroException();
            }

            return new Vector3(lhs.x / rhs, lhs.y / rhs, lhs.z / rhs);
        }
        // Set up the operator to divide a float by a vector
        public static Vector3 operator /(float lhs, Vector3 rhs)
        {
            return rhs/lhs;
        }

        // Calculate the Magnitude of the Vector3
        public float Magnitude() {

            float result = 0f;
            float xValue = x * x;
            float yValue = y * y;
            float zValue = z * z;

            result = (float)Math.Sqrt((double)(xValue+yValue+zValue));
            return result;
        }

        public float MagnitudeSqr()
        {
            return (x * x + y * y + z * z);
        }

        // Cross 2 this vector with another
        public Vector3 Cross(Vector3 vectorToCross)
        {
            return new Vector3(
                                  y * vectorToCross.z - z * vectorToCross.y,
                                  z * vectorToCross.x - x * vectorToCross.z,
                                  x * vectorToCross.y - y * vectorToCross.x
                              );
        }

        // Get the Dot  of the Vectoria
        public float Dot(Vector3 vectorToDot)
        {
            return  x*vectorToDot.x + 
                    y*vectorToDot.y +
                    z*vectorToDot.z;
        }

        // Normalise the vectora
        public void Normalize() {
            float m = Magnitude();
            this.x /= m;
            this.y /= m;
            this.z /= m;
        }
        // to String override for testing
        public override string ToString()
        {

            return x + "," + y + "," + z;
        }
    }

}
