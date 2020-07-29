using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Raylib;
using static Raylib.Raylib;
using MathClasses;
using Vector3 = MathClasses.Vector3;
using Matrix3 = MathClasses.Matrix3;
using System.Net.Http.Headers;

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

        //private float deltaTime = 0.1f;

        private float deltaTime = 0.005f;
        private float speed = 200f;
        private float degrees = 5f;
        //private float followSpeed = 75f;

        //Vector3 point;
        //Vector3 followPoint;

       // Image logo;
        // Texture2D playerTexture;
        // Texture2D playerGunTexture;
        Tank player;

        Matrix3 tankRotation;
        Vector3 tankPosition;
        Texture2D tankTexture;
        float rotation;


        Matrix3 gunRotation;
        Vector3 gunPosition;
        Texture2D gunTextureObj;
        float gunRotate;


        public Game()
        {
        }

        public void Init()
        {
            stopwatch.Start();
            lastTime = stopwatch.ElapsedMilliseconds;

            string playerTexture = "../Images/tankGreen.png";
            string gunTexture = "../Images/barrelGreen.png";
            
            //tankTexture = LoadTexture(playerTexture);
            //tankRotation = new Matrix3();
            //tankPosition = new Vector3(200, 200, 1);

            //gunTextureObj = LoadTexture(gunTexture);
            //gunRotation = new Matrix3();
            //gunPosition = new Vector3(tankTexture.width/2, 0, 1);

            string bulletTexture = "";

            player = new Tank(playerTexture, gunTexture, bulletTexture, 200,200);//GetScreenWidth() / 2 , GetScreenHeight() / 2);

            if (Stopwatch.IsHighResolution)
            {
                Console.WriteLine("Stopwatch high-resolution frequency: {0} ticks per second", Stopwatch.Frequency);
            }

            
        }

        public void Shutdown()
        {
        }
       // int count = 1000;
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
                player.Rotate(-deltaTime);
                //tankRotation = new Matrix3(1.0f, 0.0f, tankPosition.x,
                //                        0.0f, 1.0f, tankPosition.y,
                //                        0.0f, 0.0f, 1.0f);
                //rotation += (-1 * DEG2RAD);
                //Matrix3 newRotation = new Matrix3();
                //newRotation.SetRotateZ(rotation * DEG2RAD);

                //   tankRotation = tankRotation * newRotation;

                // player.Rotate(-degrees, speed, deltaTime);
                //  player.RotateTank(-90 * (float)(Math.PI / 180.0f)); //deltaTime
            }
            if (IsKeyDown(KeyboardKey.KEY_D))
            {
                player.Rotate(deltaTime);
                //  player.RotateTank(90 * (float)(Math.PI / 180.0f));
                //tankRotation = new Matrix3(1.0f, 0.0f, tankPosition.x,
                //                        0.0f, 1.0f, tankPosition.y,
                //                        0.0f, 0.0f, 1.0f);
                //rotation += (1 * DEG2RAD);
                //Matrix3 newRotation = new Matrix3();
                //newRotation.SetRotateZ(rotation * DEG2RAD);

                //tankRotation = tankRotation * newRotation;
                // player.Rotate(degrees, speed, deltaTime);
            }
            if (IsKeyDown(KeyboardKey.KEY_W))
            {
                Vector3 facing = new Vector3(player.localTransform.m1, player.localTransform.m2, 1) * deltaTime * 100;
                player.Translate(facing.x, facing.y);

                //player.Move(new Vector3(0, 1, 1), speed, deltaTime);
                //Vector3 newPos = tankRotation * new Vector3(0, 1, 1) * speed * deltaTime;
                //tankPosition = tankPosition + newPos;
            }
            if (IsKeyDown(KeyboardKey.KEY_S))
            {

                Vector3 facing = new Vector3(player.localTransform.m1, player.localTransform.m2, 1) * deltaTime * -100;
                player.Translate(facing.x, facing.y);
                // player.Move(new Vector3(0, -1, 1), speed, deltaTime);
                //Vector3 newPos = tankRotation * new Vector3(0, -1, 1) * speed * deltaTime;
                //tankPosition = tankPosition + newPos;
                //Vector3 newGunPos = gunRotation * new Vector3(0, -1, 1) * speed * deltaTime;
                //gunPosition = gunPosition + newGunPos;
            }
        }

        public void Draw()
        {
            BeginDrawing();

            ClearBackground(Color.LIGHTGRAY);

            DrawText(fps.ToString(), 10, 10, 14, Color.RED);
            DrawText(mag.ToString(), 10, 30, 14, Color.GREEN);

            //float tankRotation = player.GetRotation();// * (float)(180.0f / Math.PI)
            //float gunRotation = player.topGun.GetRotation(); // * (float)(180.0f / Math.PI)

            // Console.WriteLine("Rotation\n" + tankRotation * RAD2DEG);

            // DrawTextureEx(player.GetTankTexture(), new Vector2(player.GetPosition().x, player.GetPosition().y), tankRotation , 1f, Color.WHITE); 
            // DrawTextureEx(player.topGun.GetTexture(), new Vector2(player.topGun.transform.m3, player.topGun.transform.m6), gunRotation , 1f, Color.WHITE);

            float rotation = (float)Math.Atan2(player.globalTransform.m2, player.globalTransform.m1);

            DrawTextureEx(player.GetTankTexture(), new Vector2(player.globalTransform.m7, player.globalTransform.m8), rotation * (float)(180.0f / Math.PI), 1, Color.WHITE);


            EndDrawing();
        }

    }
}
