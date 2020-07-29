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
        public Gun topGun;
        private Texture2D tankTexture;
        Image image = new Image();

        //protected Matrix3 transform = new Matrix3();

        //public Matrix3 Transform
        //{
        //    get { return transform; }
        //}


        public Matrix3 localTransform = new Matrix3();
        public Matrix3 globalTransform = new Matrix3();

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

        public Tank(string tank, string gun, string bullet, float xPos, float yPos)
        {
          //  transform = new Matrix3();


        screenHeight = yPos * 2;
            screenWidth = xPos * 2;
            //tankTexture = LoadTexture(tank);


            Image image = LoadImage(tank);
            tankTexture = LoadTextureFromImage(image);

            Rotate(-90 * (float)(Math.PI / 180.0f));

            //position = new Vector3(xPos - tankTexture.width / 2, yPos - tankTexture.height / 2, 0);
            SetPosition(xPos, yPos);
            // transform.m3 = position.x;
            // transform.m6 = position.y;
            // transform.m9 = position.z;

           // topGun = new Gun(gun, tankTexture.width/2, tankTexture.height/2);
           // UpdateGunTransform();

         //   tankTranslation = new Matrix3();
         //   tankRotation = new Matrix3();
         //   tankMatrix = new Matrix3();

            //gunPosition = new Vector3();
            //gunPositionOffset = centerOfTank + new Vector3(-tankGunTexture.width / 2, 0, 0);
            //Console.WriteLine("Gun offset: " + gunPositionOffset.ToString());
            //gunPosition = position + gunPositionOffset;

            //new Matrix3(1,0,position.x,
            //                     0,1,position.y,
            //                     0,0,1);
            //gunMatrix = new Matrix3();
            //Console.WriteLine("Matrix");
            //Console.WriteLine(tankMatrix.ToString());
            //Console.WriteLine("position");
            //Console.WriteLine(position.ToString());


            //Console.WriteLine("Value " + 10);
            //Console.WriteLine("Degrees " + 10 * RAD2DEG);
            //Console.WriteLine("Radiens " + 10 * DEG2RAD);

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

        //public Vector3 GetPosition()
        //{
        //    return new Vector3(transform.m3, transform.m6, transform.m9);
        //}

       // public void UpdateGunTransform()
       public void UpdateTransform()
        {
            globalTransform = localTransform;
            //topGun.UpdateTransform(globalTransform);
        }

        public void Move(Vector3 movement, float speed, float deltaTime)
        {
            //Vector3 newPos = transform * movement * speed * deltaTime;
            //transform.m3 += newPos.x;
            //transform.m6 += newPos.y;
            //transform.m9 = 1;

            //UpdateGunTransform();


            //tankTranslation = new Matrix3(1.0f, 0.0f, transform.m3,
            //                             0.0f, 1.0f, transform.m6,
            //                             0.0f, 0.0f, transform.m9);
            //tankRotation = new Matrix3();
            //tankRotation.SetRotateZ(rotation * DEG2RAD);

            //Matrix3 mat = tankTranslation * tankRotation;
            //transform = tankRotation * transform;
            // Vector3 newPos = mat * new Vector3(0, movement.y, 1) * speed * deltaTime;

            /*  tankTranslation = new Matrix3(1.0f, 0.0f, position.x,
                                         0.0f, 1.0f, position.y,
                                         0.0f, 0.0f, position.z);
            tankRotation = new Matrix3();
            tankRotation.SetRotateZ(rotation * DEG2RAD);
            // tankMatrix= tankMatrix 
            Console.WriteLine("tankRotation");
            Console.WriteLine(tankRotation.ToString());

            Matrix3 mat = tankTranslation * tankRotation;
            transform = tankRotation * transform;
            Vector3 newPos = mat * new Vector3(0, movement.y, 1) * speed * deltaTime;
            position = position + newPos;*/



            //  topGun.UpdateGunTransform(mat);
            //  ContrainToScreen();


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


        public void setRotation(Matrix3 m)
        {
            localTransform.m1 = m.m1;
            localTransform.m2 = m.m2;
            localTransform.m2 = m.m3;
            localTransform.m4 = m.m4;
            localTransform.m5 = m.m5;
            localTransform.m6 = m.m6;
            localTransform.m7 = m.m7;
            localTransform.m8 = m.m8;
            localTransform.m9 = m.m9;
            UpdateTransform();
        }
       // public void Rotate(float rotate, float speed, float deltaTime)
        public void Rotate( float radians)
        {
            Matrix3 m = new Matrix3();
            m.SetRotateZ(radians);
            setRotation( localTransform * m);
           
            /*  float rotate = GetRotation();

              tankTranslation = new Matrix3(1.0f, 0.0f, transform.m3,
                                          0.0f, 1.0f, transform.m6,
                                          0.0f, 0.0f, 1.0f);
              tankRotation = new Matrix3();
              Console.WriteLine("delta \n" + deltaTime + "\nrotate\n" + rotate);
              tankRotation.SetRotateZ(deltaTime);


             Matrix3 tankRotationTwo = new Matrix3();
              Console.WriteLine("delta \n" + deltaTime + "\nrotate\n" + rotate);
              tankRotationTwo.SetRotateZ(rotate);
              tankRotation = tankRotationTwo * tankRotation;

              Matrix3 mat = transform * tankRotation;
              mat.m3 = transform.m3;
              mat.m6 = transform.m6;
              mat.m9 = 1;
               transform = mat;

              UpdateGunTransform();*/

            /*rotation += (rotate * DEG2RAD);

            tankTranslation = new Matrix3(1.0f, 0.0f, position.x,
                                        0.0f, 1.0f, position.y,
                                        0.0f, 0.0f, 1.0f);
            tankRotation = new Matrix3();
            tankRotation.SetRotateZ(rotation * DEG2RAD);

            Console.WriteLine("tankRotation");
            Console.WriteLine(tankRotation.ToString());

            Matrix3 mat = tankTranslation * tankRotation;
            Vector3 newPos = mat * new Vector3(0, 0, 1) * speed * deltaTime;
            
            position = position + newPos;
            */


            //            Vector3 newPosGun = mat * new Vector3(0, 0, 1) * speed * deltaTime;


            //  gunPosition = gunPosition + newPosGun;


            // gunPosition = gunPosition + gunPositionOffset;
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

        //public float GetRotation()
        //{
        //    float rotation = (float)Math.Atan2(
        //             transform.m2, transform.m1);
        //    return rotation;
        //}

        private void ContrainToScreen()
        {
            if (position.x < 0)
            {
                position.x = 0;
            }
            if (position.x > screenWidth)
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

        public void Translate(float x, float y)
        {
            //Transform.m7 += x; 
            //Transform.m8 += y;
            //Transform.Translate(x,y);
            //UpdateGunTransform();
            localTransform.Translate(x, y);
            UpdateTransform();
        }
        public void SetPosition(float x, float y)
        {
            localTransform.SetTranslation(x, y);
            UpdateTransform();
        }
    }
}