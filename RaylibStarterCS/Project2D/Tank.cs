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

namespace Project2D
{
    class Tank
    {
        private Texture2D tankTexture;
        private Texture2D tankGunTexture;
        private Texture2D bulletTexture;

        private Vector3 position;
        public float rotation = 1;
        public float rotationSpeed = 1;
        public float moveSpeed = 100;
        private Matrix3 tankTranslation;
        private Matrix3 tankRotation;
        private Matrix3 tankMatrix;



        private Vector3 gunPositionOffset;
        private Matrix3 gunMatrix;

        private int moveValue;

        public Tank(string tank, string gun, string bullet, float xPos, float yPos) {
            tankTexture = LoadTexture(tank);
            tankGunTexture = LoadTexture(gun);
            bulletTexture = LoadTexture(bullet);
            position = new Vector3(xPos - tankTexture.width / 2, yPos - tankTexture.height / 2, 0);
            gunPositionOffset = new Vector3((tankTexture.width- tankGunTexture.width)/2, tankTexture.height / 2, 0);
            //gunPositionOffset = new Vector3(position.x, position.y, 0);
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

        //public Vector3 GetPosition(float speed, float deltaTime() {
        //    if (moveValue<0 || moveValue>0)
        //    {
        //        Move(speed, deltaTime);
        //    }
        //    return position;
        //}

        public Vector3 GetPosition() {
            return position;
        }

        //public Vector3 GetGunPosition() {
        //    return gunPositionOffset+position;
        //}

        //public void SetMoving(int value) {
        //    moveValue = value;
        //}

        public void Move(Vector3 movement, float speed, float deltaTime)
        {
            // Console.WriteLine("movement");
            // Console.WriteLine(movement.ToString());

            //  Console.WriteLine("positionBefore");
            //  Console.WriteLine(position.ToString());
            // position = position + movement;

            //   Console.WriteLine("positionAfter");
            //    Console.WriteLine(position.ToString());
           // tankTranslation.m3 = position.x;
           // tankTranslation.m6 = position.y;

            tankTranslation = new Matrix3(1.0f, 0.0f, position.x,
                                         0.0f, 1.0f, position.y,
                                         0.0f, 0.0f,1.0f);

            Console.WriteLine("tankTranslation");
            Console.WriteLine(tankTranslation.ToString());

            tankRotation = new Matrix3();
            tankRotation.SetRotateY(rotation);
            Console.WriteLine("tankRotation");
            Console.WriteLine(tankRotation.ToString());

            Matrix3 mat = tankTranslation * tankRotation;


            //    Console.WriteLine("tankMatrix");
            //  Console.WriteLine(tankRotation.ToString());

            Console.WriteLine("deltaTime");
            Console.WriteLine(deltaTime);
            Vector3 newPos = mat * new Vector3(0,movement.y*100*deltaTime,1);
            position = position + newPos;
          //  position.x = newPos.x;
          //  position.y = newPos.y;

            Console.WriteLine("newPos");
            Console.WriteLine(newPos.ToString());
            //position = position + movement * speed * deltaTime;

            //Console.WriteLine("Matrix");
            //Console.WriteLine(tankMatrix.ToString());
            //Console.WriteLine("position");
            //Console.WriteLine(position.ToString());
            //gunPositionOffset = gunPositionOffset + movement * speed * deltaTime;
        }



        public void Rotate(float rotate, float speed, float deltaTime)
        {
           rotation += (rotate * DEG2RAD);
            tankTranslation = new Matrix3(1.0f, 0.0f, position.x,
                                         0.0f, 1.0f, position.x,
                                         0.0f, 0.0f, 1.0f);
            tankRotation = new Matrix3();
            tankRotation.SetRotateY(rotation);


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
