using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Raylib;
using static Raylib.Raylib;
using MathClasses;
using Vector3 = MathClasses.Vector3;
using Matrix3 = MathClasses.Matrix3;
using System.Threading.Tasks;

namespace Project2D
{
    class Gun
    {
        private Texture2D gunTexture;
        public Matrix3 transform = new Matrix3();
        public Matrix3 localTransform = new Matrix3();

        public Gun(string texture, float xPos, float yPos)
        {
            gunTexture = LoadTexture(texture);
            localTransform = new Matrix3();
            localTransform.m3 = xPos- gunTexture.width/2;
            localTransform.m6 = yPos;
        }
        public void UpdateTransform(Matrix3 _transform)
        {
            transform = _transform * localTransform;
        }
        public Texture2D GetTexture()
        {
            return gunTexture;
        }


        public float GetRotation()
        {
            float rotation = (float)Math.Atan2(
                     transform.m2, transform.m1);
            return rotation;
        }


    }
}
