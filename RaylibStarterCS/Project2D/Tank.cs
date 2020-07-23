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
using System.Runtime.InteropServices;

namespace Project2D
{
    class Tank
    {
        private Texture2D tankTexture;
        private Texture2D tankGunTexture;
        private Texture2D bulletTexture;
        private Vector3 centerOfTank;
        private Vector3 position;
        private Vector3 gunPosition;
        public float rotation = 0;
        public float rotationSpeed = 1;
        public float moveSpeed = 100;
        private Matrix3 tankTranslation;
        private Matrix3 tankRotation;
        private Matrix3 tankMatrix;

        private Matrix3 gunMatrix;

        private Vector3 gunPositionOffset;

        private int moveValue;

        private float screenHeight;
        private float screenWidth;

        public Tank(string tank, string gun, string bullet, float xPos, float yPos) {
            screenHeight = yPos * 2;
            screenWidth = xPos * 2;
            tankTexture = LoadTexture(tank);
            tankGunTexture = LoadTexture(gun);
            bulletTexture = LoadTexture(bullet);
            centerOfTank = new Vector3(tankTexture.width / 2, tankTexture.height / 2, 0);
            
            position = new Vector3(xPos - tankTexture.width / 2, yPos - tankTexture.height / 2, 0);
            
            gunPosition = new Vector3();
            gunPositionOffset = centerOfTank + new Vector3 (-tankGunTexture.width/2, 0, 0);
            Console.WriteLine("Gun offset: " + gunPositionOffset.ToString());
            gunPosition = position + gunPositionOffset;

            tankTranslation = new Matrix3();
            tankRotation = new Matrix3();
            tankMatrix = new Matrix3();
            //new Matrix3(1,0,position.x,
            //                     0,1,position.y,
            //                     0,0,1);
            gunMatrix = new Matrix3();
            Console.WriteLine("Matrix");
            Console.WriteLine(tankMatrix.ToString());
            Console.WriteLine("position");
            Console.WriteLine(position.ToString());


            Console.WriteLine("Value " + 10);
            Console.WriteLine("Degrees " + 10*RAD2DEG);
            Console.WriteLine("Radiens " + 10*DEG2RAD);

        }
        // MatrixMultiply childs local by parents global
        public Texture2D GetTankTexture()
        {
            return tankTexture;
        }

        public Texture2D GetGunTexture()
        {
            return tankGunTexture;
        }
        public Texture2D GetBulletTexture()
        {
            return bulletTexture;
        }

        public Vector3 GetPosition() {
            return position ;
        }

        public Vector3 GetGunPosition()
        {
            return gunPosition;//gunPositionOffset + position;
        }
        public void Move(Vector3 movement, float speed, float deltaTime)
        {

            tankTranslation = new Matrix3(1.0f, 0.0f, position.x,
                                         0.0f, 1.0f, position.y,
                                         0.0f, 0.0f, position.z);
            tankRotation = new Matrix3();
            tankRotation.SetRotateZ(rotation * DEG2RAD);
           // tankMatrix= tankMatrix 
            Console.WriteLine("tankRotation");
            Console.WriteLine(tankRotation.ToString());

            Matrix3 mat = tankTranslation * tankRotation;
            Vector3 newPos = mat * new Vector3(0, movement.y , 1) * speed * deltaTime;
            position = position + newPos;
   

            Vector3 newPosGun = mat * new Vector3(0, movement.y, 1) * speed * deltaTime;
            gunPosition = gunPosition+ newPosGun;

            ContrainToScreen();

            /*
             *  tankTranslation = new Matrix3(1.0f, 0.0f, position.x,
                                         0.0f, 1.0f, position.y,
                                         0.0f, 0.0f, position.z);
            tankRotation = new Matrix3();
            tankRotation.SetRotateZ(rotation * DEG2RAD);
            Console.WriteLine("tankRotation");
            Console.WriteLine(tankRotation.ToString());

            Matrix3 mat = tankTranslation * tankRotation;
            Vector3 newPos = mat * new Vector3(0, movement.y , 1) * speed * deltaTime;
            position = position + newPos;


            gunTranslation = new Matrix3(1.0f, 0.0f, gunPositionOffset.x,
                                        0.0f, 1.0f, gunPositionOffset.y,
                                        0.0f, 0.0f, gunPositionOffset.z);
            gunRotation = new Matrix3();
            gunRotation.SetRotateZ(rotation * DEG2RAD);

            Matrix3 gunMat = gunTranslation * gunRotation;

            gunMatrix = mat * gunMat;

            Vector3 newPosGun = gunMatrix * new Vector3(0, movement.y, 1) * speed * deltaTime;
            gunPosition = gunPosition+ newPosGun;
             */
        }

        private void ContrainToScreen() {
            if (position.x<0)
            {
                position.x = 0;
            }
            if (position.x>screenWidth)
            {
                position.x = screenWidth;
            }
            if (position.y < 0)
            {
                position.y = 0;
            }
            if (position.y > screenHeight)
            {
                position.y = screenHeight;
            }
        }


        public void Rotate(float rotate, float speed, float deltaTime)
        {
           rotation += (rotate * DEG2RAD);

            tankTranslation = new Matrix3(1.0f, 0.0f, position.x,
                                        0.0f, 1.0f, position.y,
                                        0.0f, 0.0f, 1.0f);
            tankRotation = new Matrix3();
            tankRotation.SetRotateZ(rotation * DEG2RAD);

            Console.WriteLine("tankRotation");
            Console.WriteLine(tankRotation.ToString());

            Matrix3 mat = tankTranslation * tankRotation;
            Vector3 newPos = mat * new Vector3(0, 0, 1) * speed * deltaTime;
           
            Console.WriteLine("Old Tank Pos: " + position.ToString());
            position = position + newPos;
           
            Console.WriteLine("New Tank Pos: " + position.ToString());

            Vector3 newPosGun = mat * new Vector3(0, 0, 1) * speed * deltaTime;

            Console.WriteLine("Old Gun Pos: " + gunPosition.ToString());
            Console.WriteLine("gunPositionOffset Pos: " + gunPositionOffset.ToString());
            
            gunPosition = gunPosition + newPosGun;
           
            Console.WriteLine("New Gun Pos: " + gunPosition.ToString());
           // gunPosition = gunPosition + gunPositionOffset;
            Console.WriteLine("gun + gunPositionOffset: " + gunPosition.ToString());
            //Console.WriteLine("Rotation: " + rotation);
            //tankTranslation = new Matrix3(1.0f, 0.0f, position.x,
            //                             0.0f, 1.0f, position.x,
            //                             0.0f, 0.0f, position.z);
            //tankRotation = new Matrix3();
            //tankRotation.SetRotateZ(rotation*DEG2RAD);

            // tankMatrix = tankTranslation * tankRotation;
            //position = position + movement * speed * deltaTime;
            //Matrix3 rotateMatrix = new Matrix3();
            //rotateMatrix.SetRotateZ(rotate*speed*deltaTime);
            //tankMatrix = tankMatrix * rotateMatrix;
            //Vector3 newVec = new Vector3(tankMatrix.m3, tankMatrix.m6, tankMatrix.m9);
            //position = position.Cross(newVec);//* tankMatrix ;
            //Console.WriteLine("Matrix");
            //Console.WriteLine(tankMatrix.ToString());
            //Console.WriteLine("position");
            //Console.WriteLine(position.ToString());
            //gunPositionOffset = gunPositionOffset + movement * speed * deltaTime;
        }

        public float GetRotation() {
            //Vector3 start = new Vector3(0, 0, 0);
            return rotation;// start.Dot(position);
        }
    }
}
