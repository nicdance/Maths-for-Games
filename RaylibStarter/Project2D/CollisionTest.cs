using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Raylib;
using static Raylib.Raylib;
using MathClasses;
using Vector3 = MathClasses.Vector3;
using Matrix3 = MathClasses.Matrix3;

namespace Project2D
{
    class CollisionTest
    {
        Stopwatch stopwatch = new Stopwatch();

        private long currentTime = 0;
        private long lastTime = 0;
        private float timer = 0;
        private int fps = 1;
        private int frames;

        private float deltaTime = 0.005f;

        private Vector3[] pointList;
        private List<Vector3> listOfPoints = new List<Vector3>();
        private AABB aabb = null;


        public void Init()
        {
            stopwatch.Start();
            lastTime = stopwatch.ElapsedMilliseconds;

            if (Stopwatch.IsHighResolution)
            {
                Console.WriteLine("Stopwatch high-resolution frequency: {0} ticks per second", Stopwatch.Frequency);
            }

            int n = 2;
          //  pointList = new Vector3[n];
            Random rd = new Random();
            //for (int i = 0; i < pointList.Length; i++)
            //{
            //    pointList[i] = new Vector3(rd.Next(100, 340), rd.Next(100, 380), 0);
            //}
            for (int i = 0; i < n; i++)
            {
                listOfPoints.Add(new Vector3(rd.Next(100, 340), rd.Next(100, 380), 0));
            }

            aabb = new AABB(listOfPoints);
        }

        public void Shutdown()
        {
        }

        public void Update()
        {
            lastTime = currentTime;
            currentTime = stopwatch.ElapsedMilliseconds;
            deltaTime = (currentTime - lastTime) / 1000.0f;
            timer += deltaTime;
            if (timer >= 1)
            {
                fps = frames;
                frames = 0;
                timer -= 1;
            }
            frames++;

            if (IsKeyPressed(KeyboardKey.KEY_SPACE))// && aabb == null)
            {
                // aabb = new AABB(pointList);
                Random rd = new Random();
                listOfPoints.Add(new Vector3(rd.Next(10, 630), rd.Next(10, 470), 0));
                aabb.AddPoint(listOfPoints[listOfPoints.Count-1]);
            }

            if (IsKeyPressed(KeyboardKey.KEY_D)&& listOfPoints.Count>2)// && aabb == null)
            {
                Random rd = new Random();
                listOfPoints.RemoveAt(rd.Next(0,listOfPoints.Count)) ;
                aabb.RecalculateBounds(listOfPoints);
            }
        }



        public void Draw()
         {
            BeginDrawing();

            ClearBackground(Color.WHITE);

            DrawText(fps.ToString(), 10, 10, 14, Color.RED);

            foreach (var point in listOfPoints)
            {
                DrawCircle((int)point.x , (int)point.y, 3,  Color.RED);

                if (aabb !=null)
                {
                    aabb.Draw();
                }
            }

            EndDrawing();
        }
}

}
