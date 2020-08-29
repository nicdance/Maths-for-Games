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
        GameObject bulletObject = new GameObject();
        GameObject wallObject = new GameObject();

        // Holds th e objects texture. This alows the texture to be positioned correctly
        ObjectTexture tankTexture = new ObjectTexture();
        ObjectTexture gunTexture = new ObjectTexture();
        ObjectTexture bulletTexture = new ObjectTexture();
        ObjectTexture wallTexture = new ObjectTexture();

        Stopwatch stopwatch = new Stopwatch();

        private long currentTime = 0;
        private long lastTime = 0;
        private float timer = 0;
        private int fps = 1;
        private int frames;

        private float bulletCooldown = 0;
        private float intialBulletCountdown = 1f;
        private float bulletSpeed = .1f;
        private Vector3 bulletDirection = new Vector3();

        private float deltaTime = 0.005f;

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

            // Sets up Tank
            tankTexture.Load("./Images/tankGreen.png");
            tankTexture.SetRotate(90 * (float)(Math.PI / 180.0f));
            tankTexture.SetPosition(tankTexture.Width / 2.0f, -tankTexture.Height / 2.0f);
            tankObject.AddChild(tankTexture);

            // sets up Gun
            gunTexture.Load("./Images/barrelGreen.png");
            gunTexture.SetRotate(90 * (float)(Math.PI / 180.0f));
            gunTexture.SetPosition(gunTexture.Height, -gunTexture.Width / 2);
            gunObject.AddChild(gunTexture);
            tankObject.AddChild(gunObject);

            //sets up Bullet
            bulletTexture.SetRotate(90 * (float)(Math.PI / 180.0f));
            bulletTexture.SetPosition(10 * bulletTexture.Height, -bulletTexture.Width);
            bulletTexture.Load("./Images/bulletGreenSilver_outline.png");
            bulletTexture.SetPosition(.1f, 0);
            bulletObject.AddChild(bulletTexture);


            // Once the Gun object and Texture is assigned and added as children of the correct objects then set the tanks position.
            // This ensures a flow on effect where all children objects are repositioned.
            tankObject.SetPosition(GetScreenWidth() / 2, GetScreenHeight() / 2);

            wallTexture.Load("./Images/tankRed.png");
            wallTexture.SetPosition(wallTexture.Width / 2.0f, -wallTexture.Height / 2.0f);
            wallObject.AddChild(wallTexture);
            wallObject.SetPosition(50, 150);
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
                Vector3 facing = tankObject.Forward * deltaTime * 100;
                tankObject.Translate(facing.x, facing.y);
            }
            if (IsKeyDown(KeyboardKey.KEY_S))
            {
                Vector3 facing = new Vector3(tankObject.localTransform.m1, tankObject.localTransform.m2, 1) * deltaTime * -100;
                tankObject.Translate(facing.x, facing.y);
            }
            if (IsKeyDown(KeyboardKey.KEY_SPACE) && bulletCooldown <= 0)
            {
                Console.WriteLine("Shoot");
                bulletObject.UpdateAllTransforms(gunObject.globalTransform);
                bulletObject.SetPosition(gunObject.globalTransform.m7, gunObject.globalTransform.m8);
                bulletDirection = new Vector3(gunObject.globalTransform.m1, gunObject.globalTransform.m2, bulletDirection.z);

                bulletCooldown = intialBulletCountdown;
            }
            if (bulletCooldown > 0)
            {
                bulletObject.Translate(bulletDirection.x * bulletSpeed, bulletDirection.y * bulletSpeed);
                bulletCooldown -= deltaTime;
                bulletTexture.Draw();

            }
        }



        public void Draw()
        {
            BeginDrawing();

            ClearBackground(Color.WHITE);

            DrawText(fps.ToString(), 10, 10, 14, Color.RED);

            tankObject.Draw();
            wallObject.Draw();
            // Console.WriteLine(tankObject.localTransform.ToString());
            DrawCircle((int)tankObject.localTransform.m7, (int)tankObject.localTransform.m8, 5, Color.RED);

            EndDrawing();
        }

    }
}
