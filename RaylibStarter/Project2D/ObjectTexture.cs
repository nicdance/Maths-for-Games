using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static Raylib.Raylib;
using Raylib;
using System.Runtime.CompilerServices;
using MathClasses;
using Vector3 = MathClasses.Vector3;
using Matrix3 = MathClasses.Matrix3;

namespace Project2D
{
    // ObjectTexture is a child of GameObject. 
    // This means it will inherite all its functionality
    class ObjectTexture : GameObject
    {
        Texture2D texture = new Texture2D();


        // Property to return the minimum of the Assigned Texture
        public Vector3 min
        {
            get { return new Vector3(globalTransform.m7, globalTransform.m8, globalTransform.m9 ); }
        }


        // Property to return the minimum of the Assigned Texture
        public Vector3 max
        {
            get { return new Vector3(globalTransform.m7+Width, globalTransform.m8+Height, globalTransform.m9); }
        }




        // Property to return the Width of the Assigned Texture
        public float Width
        {
            get { return texture.width; }
        }

        // Property to return the Height of the Assigned Texture
        public float Height
        {
            get { return texture.height; }
        }

        public ObjectTexture()
        {

        }

        // Takes in a string to a texture and loads in the to the Texture2D
        public void Load(string filename)
        {
            texture = LoadTexture(filename);
        }

        // This function overrides the GameObject.OnDraw. This results in the assigned texture been  drawn to the screen
        public override void OnDraw()
        {
            float rotation = (float)Math.Atan2(globalTransform.m2, globalTransform.m1);

            Raylib.Raylib.DrawTextureEx(texture, new Vector2(globalTransform.m7, globalTransform.m8), rotation * (float)(180.0f / Math.PI), 1, Color.WHITE);
        }
    }
}
