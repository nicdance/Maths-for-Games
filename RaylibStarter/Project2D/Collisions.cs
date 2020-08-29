using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Raylib;
using static Raylib.Raylib;

namespace Project2D
{
    class Collisions
    {
        public static bool CheckCollision(ObjectTexture obj1, ObjectTexture obj2) {

            //Returns if  not colliding
            return !(obj1.max.x < obj2.min.x || obj1.max.y < obj2.min.y ||
                     obj1.min.x > obj2.max.x || obj1.min.y > obj2.max.y);

        }


    }
}
