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
    class Game
    {
        // Objects These are th esecitons which get rotated
        GameObject tankObject = new GameObject();
        GameObject gunObject = new GameObject();

        // Holds th e objects texture. This alows the texture to be positioned correctly
        ObjectTexture tankTexture = new ObjectTexture();
        ObjectTexture gunTexture = new ObjectTexture();

        Stopwatch stopwatch = new Stopwatch();

        private long currentTime = 0;
        private long lastTime = 0;
        private float timer = 0;
        private int fps = 1;
        private int frames;

        private float deltaTime = 0.005f;


        Image logo;
        Texture2D texture;

        public Game()
        {
        }

        public void Init()
        {
            stopwatch.Start();
            lastTime = stopwatch.ElapsedMilliseconds;

            if (Stopwatch.IsHighResolution)
            {
                Console.WriteLine("Stopwatch high-resolution frequency: {0} ticks per second", Stopwatch.Frequency);
            }


            // string playerTexture = "../Images/tankGreen.png";
            // string gunTexture = "../Images/barrelGreen.png";


            tankTexture.Load("../Images/tankGreen.png");
            tankTexture.SetRotate(-90 * (float)(Math.PI / 180.0f));
            tankTexture.SetPosition(-tankTexture.Width / 2.0f, tankTexture.Height / 2.0f);
            tankObject.AddChild(tankTexture);




            gunTexture.Load("../Images/barrelGreen.png");
            gunTexture.SetRotate(-90 * (float)(Math.PI / 180.0f));
            // gunTexture.SetPosition(-gunTexture.Width / 2.0f, gunTexture.Height / 2.0f);
             gunTexture.SetPosition(-gunTexture.Width / 2.0f, gunTexture.Height/4.5f);
            gunObject.AddChild(gunTexture);
            tankObject.AddChild(gunObject);

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

            // insert game logic here    
            if (IsKeyDown(KeyboardKey.KEY_Q))
            {
                gunObject.Rotate(-deltaTime);
            }
            if (IsKeyDown(KeyboardKey.KEY_E))
            {
                gunObject.Rotate(deltaTime);
            }
            if (IsKeyDown(KeyboardKey.KEY_A))
            {
                tankObject.Rotate(-deltaTime);
            }
            if (IsKeyDown(KeyboardKey.KEY_D))
            {
                tankObject.Rotate(deltaTime);
            }
            if (IsKeyDown(KeyboardKey.KEY_W))
            {
                Vector3 facing = new Vector3(tankObject.localTransform.m1, tankObject.localTransform.m2, 1) * deltaTime * 100;
                tankObject.Translate(facing.x, facing.y);
            }
            if (IsKeyDown(KeyboardKey.KEY_S))
            {
                Vector3 facing = new Vector3(tankObject.localTransform.m1, tankObject.localTransform.m2, 1) * deltaTime * -100;
                tankObject.Translate(facing.x, facing.y);
            }
        }

        public void Draw()
        {
            BeginDrawing();

            ClearBackground(Color.WHITE);

            DrawText(fps.ToString(), 10, 10, 14, Color.RED);

            tankObject.Draw();  


            EndDrawing();
        }

    }
}
