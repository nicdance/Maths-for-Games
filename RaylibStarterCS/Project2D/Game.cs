using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Raylib;
using static Raylib.Raylib;

namespace Project2D
{
    class Game
    {
        Stopwatch stopwatch = new Stopwatch();

        private long currentTime = 0;
        private long lastTime = 0;
        private float timer = 0;
        private int fps = 1;
        private float mag = 0;
        private int frames;

        private float deltaTime = 0.005f;
        private float speed = 100f;
        private float followSpeed = 75f;

        Vector3 point;
        Vector3 followPoint;

        Image logo;
        Texture2D texture;

        public Game()
        {
        }

        public void Init()
        {
            point = new Vector3(50, 50, 50);
            followPoint = new Vector3(250, 250, 250);
            stopwatch.Start();
            lastTime = stopwatch.ElapsedMilliseconds;

            if (Stopwatch.IsHighResolution)
            {
                Console.WriteLine("Stopwatch high-resolution frequency: {0} ticks per second", Stopwatch.Frequency);
            }

            
        }

        public void Shutdown()
        {
        }
        int count = 1000;
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
            if (IsKeyDown(KeyboardKey.KEY_A))
            {
                point = point + new Vector3(-1, 0, 0)*speed * deltaTime;
            }
            if (IsKeyDown(KeyboardKey.KEY_D))
            {
                point = point + new Vector3(1, 0, 0) * speed * deltaTime;
            }
            if (IsKeyDown(KeyboardKey.KEY_W))
            {
                point = point + new Vector3(0, -1, 0) * speed * deltaTime;
            }
            if (IsKeyDown(KeyboardKey.KEY_S))
            {
                point = point + new Vector3(0, 1, 0) * speed * deltaTime;
            }
            Vector3 direction = followPoint - point; 
            mag = direction.Magnitude(); 
            if (direction.Magnitude() >=100)
            {
                direction.Normalize();
                followPoint = followPoint - direction * followSpeed * deltaTime;

            } else if (direction.Magnitude() <=75)
            {
                direction.Normalize();
                followPoint = followPoint + direction * followSpeed * deltaTime;

            }
        }

        public void Draw()
        {
            BeginDrawing();

            ClearBackground(Color.WHITE);

            DrawText(fps.ToString(), 10, 10, 14, Color.RED);
            DrawText(mag.ToString(), 10, 30, 14, Color.GREEN);

            DrawTexture(texture, 
                GetScreenWidth() / 2 - texture.width / 2, GetScreenHeight() / 2 - texture.height / 2, Color.WHITE);
            DrawCircle((int)point.x, (int)point.y, 10, Color.GREEN); // Draw ring
            DrawCircle((int)followPoint.x, (int)followPoint.y, 10, Color.RED); // Draw ring

            EndDrawing();
        }

    }
}
