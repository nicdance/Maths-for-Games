using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Raylib;
using static Raylib.Raylib;
using MathClasses;
using Vector3 = MathClasses.Vector3;
using Matrix3 = MathClasses.Matrix3;
using System.Xml.Schema;

namespace Project2D
{
    class AABB
    {
        Vector3 position;
        Vector3 halfExtent;

        public Vector3 Min() {
            return position - halfExtent;
        }
        public Vector3 Max()
        {
            return position + halfExtent;
        }

        public bool ABBBOverLaps(AABB other) {
            if (!(Min().x > other.Max().x || Min().y > other.Max().y ||
                Max().x < other.Min().x || Max().y < other.Min().y))
            {
                return true;
            }
            return false;
        }

        public bool PointOverlaps(Vector3 p)
        {
            Vector3 np = p - position;
            np.x = Math.Abs(np.x);
            np.y = Math.Abs(np.y);

            return np.x < halfExtent.x && np.y < halfExtent.y;
        }

        public bool PointOverlapsMethod2(Vector3 p)
        {
            var mn = Min();
            var mx = Max();
           
            return p.x < mx.x && p.x > mn.x && p.y < mx.y && p.y > mn.y;
        }

        public void AddPoint(Vector3 p) { 
            Vector3 min = Min();
            Vector3 max = Max();

            if (p.x < min.x){
                    min.x = p.x;
                }
                if (p.y < min.y){
                    min.y = p.y;
                }

                if (p.x > max.x){
                    max.x = p.x;
                }
                if (p.y > max.y){
                    max.y = p.y;
                }

            // movePosition and recalculate halfExtent
            position = (max + min) * 0.5f;
            halfExtent = (max - min) * 0.5f;
        }

        public AABB() { }
        public AABB(Vector3[] listOfPoints)
        {
            Vector3 min = new Vector3(float.MaxValue, float.MaxValue,0);
            Vector3 max = new Vector3(float.MinValue, float.MinValue, 0);
            foreach (var p in listOfPoints)
            {
                if (p.x < min.x){
                    min.x = p.x;
                }
                if (p.y < min.y){
                    min.y = p.y;
                }

                if (p.x > max.x){
                    max.x = p.x;
                }
                if (p.y > max.y){
                    max.y = p.y;
                }
            }

            // movePosition and recalculate halfExtent
            position = (max + min) * 0.5f;
            halfExtent = (max - min) * 0.5f;
        }


        public AABB(List<Vector3> listOfPoints)
        {
            Vector3 min = new Vector3(float.MaxValue, float.MaxValue, 0);
            Vector3 max = new Vector3(float.MinValue, float.MinValue, 0);
            foreach (var p in listOfPoints)
            {
                if (p.x < min.x)
                {
                    min.x = p.x;
                }
                if (p.y < min.y)
                {
                    min.y = p.y;
                }

                if (p.x > max.x)
                {
                    max.x = p.x;
                }
                if (p.y > max.y)
                {
                    max.y = p.y;
                }
            }

            // movePosition and recalculate halfExtent
            position = (max + min) * 0.5f;
            halfExtent = (max - min) * 0.5f;
        }

        public void RecalculateBounds(List<Vector3> listOfPoints)
        {
            Vector3 min = new Vector3(float.MaxValue, float.MaxValue, 0);
            Vector3 max = new Vector3(float.MinValue, float.MinValue, 0);
            foreach (var p in listOfPoints)
            {
                if (p.x < min.x)
                {
                    min.x = p.x;
                }
                if (p.y < min.y)
                {
                    min.y = p.y;
                }

                if (p.x > max.x)
                {
                    max.x = p.x;
                }
                if (p.y > max.y)
                {
                    max.y = p.y;
                }
            }

            // movePosition and recalculate halfExtent
            position = (max + min) * 0.5f;
            halfExtent = (max - min) * 0.5f;
        }


        public void Draw() {
            var x = (int)Min().x;
            var y = (int)Min().y;
            var w = (int)halfExtent.x * 2;
            var h = (int)halfExtent.y * 2;
            //Color c = new Color(255,0,0,255);
            DrawRectangleLines(x, y, w, h, Color.BLACK);
        }
    }
}
