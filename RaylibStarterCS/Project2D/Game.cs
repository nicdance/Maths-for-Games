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

        private float deltaTime = 0.1f;
        private float speed = 200f;
        private float degrees = 2f;
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
           // point = new Vector3(GetScreenWidth() / 2 - playerTexture.width / 2, GetScreenHeight() / 2 - playerTexture.height / 2, 0);
          //  followPoint = new Vector3(250, 250, 250);
            stopwatch.Start();
            lastTime = stopwatch.ElapsedMilliseconds;

            string playerTexture = "../Images/tankGreen.png";
            string gunTexture = "../Images/barrelGreen.png";
            
            tankTexture = LoadTexture(playerTexture);
            tankRotation = new Matrix3();
            tankPosition = new Vector3(200, 200, 1);

            gunTextureObj = LoadTexture(gunTexture);
            gunRotation = new Matrix3();
            gunPosition = new Vector3(tankTexture.width/2, 0, 1);

            string bulletTexture = "";
            
            player = new Tank(playerTexture, gunTexture, bulletTexture, GetScreenWidth() / 2 , GetScreenHeight() / 2);

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
                tankRotation = new Matrix3(1.0f, 0.0f, tankPosition.x,
                                        0.0f, 1.0f, tankPosition.y,
                                        0.0f, 0.0f, 1.0f);
                rotation += (-1 * DEG2RAD);
                Matrix3 newRotation = new Matrix3();
                newRotation.SetRotateZ(rotation * DEG2RAD);

                tankRotation = tankRotation * newRotation;

            }
            if (IsKeyDown(KeyboardKey.KEY_D))
            {
                tankRotation = new Matrix3(1.0f, 0.0f, tankPosition.x,
                                        0.0f, 1.0f, tankPosition.y,
                                        0.0f, 0.0f, 1.0f);
                rotation += (1 * DEG2RAD);
                Matrix3 newRotation = new Matrix3();
                newRotation.SetRotateZ(rotation * DEG2RAD);

                tankRotation = tankRotation * newRotation;
                // player.Rotate(degrees, speed, deltaTime);
            }
            if (IsKeyDown(KeyboardKey.KEY_W))
            {
                Vector3 newPos = tankRotation * new Vector3(0, 1, 1) * speed * deltaTime;
                tankPosition = tankPosition + newPos;
                // player.Move(new Vector3(0, 1, 0), speed, deltaTime);
            }
            if (IsKeyDown(KeyboardKey.KEY_S))
            {
                Vector3 newPos = tankRotation * new Vector3(0, -1, 1) * speed * deltaTime;
                tankPosition = tankPosition + newPos;


                Vector3 newGunPos = gunRotation * new Vector3(0, -1, 1) * speed * deltaTime;
                gunPosition = gunPosition + newGunPos;
                //  player.Move(new Vector3(0, -1, 0), speed, deltaTime);
            }

            //Vector3 direction = followPoint - point; 
            //mag = direction.Magnitude(); 
            //if (direction.Magnitude() >=100)
            //{
            //    direction.Normalize();
            //    followPoint = followPoint - direction * followSpeed * deltaTime;

            //} else if (direction.Magnitude() <=75)
            //{
            //    direction.Normalize();
            //    followPoint = followPoint + direction * followSpeed * deltaTime;

            //}
        }

        public void Draw()
        {
            BeginDrawing();

            ClearBackground(Color.LIGHTGRAY);

            DrawText(fps.ToString(), 10, 10, 14, Color.RED);
            DrawText(mag.ToString(), 10, 30, 14, Color.GREEN);

            //DrawTexture(texture, GetScreenWidth() / 2 - texture.width / 2, GetScreenHeight() / 2 - texture.height / 2, Color.WHITE);
            //DrawTexture(player, (int)point.x - (playerTexture.width / 2), (int)point.y - (playerTexture.height / 2), Color.WHITE);
            //DrawTexture(playerGunTexture, (int)point.x - (playerGunTexture.width / 2), (int)point.y, Color.WHITE);
            //DrawTexture(player.GetTankTexture(), (int)player.GetPosition().x, (int)player.GetPosition().y, Color.WHITE);
            //DrawTexture(player.GetGunTexture(), (int)player.GetGunPosition().x, (int)player.GetGunPosition().y, Color.WHITE);   

            // Current
            //DrawTextureEx(player.GetTankTexture(), new Vector2(player.GetPosition().x, player.GetPosition().y),player.GetRotation(), 1f, Color.WHITE);
            //DrawTextureEx(player.GetGunTexture(), new Vector2(player.GetGunPosition().x, player.GetGunPosition().y), player.GetRotation(), 1f, Color.WHITE);


            DrawTextureEx(tankTexture, new Vector2(tankPosition.x, tankPosition.y), rotation, 1f, Color.WHITE);

            Vector3 newPos = gunRotation * tankPosition - new Vector3(10,10,1);   //  tankRotation * gunPosition;

            Console.Write("\ngunRotation\n" + gunRotation.ToString());
            Console.Write("\ntankPosition\n" + tankPosition.ToString());
            Console.Write("\nnewPos\n" + newPos.ToString());


            DrawTextureEx(gunTextureObj, new Vector2(newPos.x, newPos.y), gunRotate + rotation, 1f, Color.WHITE);

            // Matrix3 newMat = gunRotation * tankRotation;

            //Console.Write("\ngunRotation\n" + gunRotation.ToString());
            //Console.Write("\ntankRotation\n" + tankRotation.ToString());
            //Console.Write("\nnewMat\n" + newMat.ToString());


           // DrawTextureEx(gunTextureObj, new Vector2(newMat.m3, newMat.m6),gunRotate+rotation, 1f, Color.WHITE);

            

            //  DrawCircle((int)point.x, (int)point.y, 10, Color.GREEN); // Draw ring
            //  DrawCircle((int)followPoint.x, (int)followPoint.y, 10, Color.RED); // Draw ring

            EndDrawing();
        }

    }
}
