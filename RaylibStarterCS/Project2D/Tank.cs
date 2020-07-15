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
        private Vector3 gunPositionOffset;
        private Matrix3 tankMatrix;
        private Matrix3 gunMatrix;
        
        public Tank(string tank, string gun, string bullet, float xPos, float yPos) {
            tankTexture = LoadTexture(tank);
            tankGunTexture = LoadTexture(gun);
            bulletTexture = LoadTexture(bullet);
            position = new Vector3(xPos - tankTexture.width / 2, yPos - tankTexture.height / 2, 0);
            gunPositionOffset = new Vector3((tankTexture.width- tankGunTexture.width)/2, tankTexture.height / 2, 0);
            //gunPositionOffset = new Vector3(position.x, position.y, 0);
            tankMatrix = new Matrix3();
            gunMatrix = new Matrix3();
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
            return position;
        }

        public Vector3 GetGunPosition() {
            return gunPositionOffset+position;
        }

        public void Move(Vector3 movement, float speed, float deltaTime)
        {
            position = position + movement * speed * deltaTime;
            //gunPositionOffset = gunPositionOffset + movement * speed * deltaTime;
        }


        public void Rotate(Vector3 movement, float speed, float deltaTime)
        {
            position = position + movement * speed * deltaTime;
            //gunPositionOffset = gunPositionOffset + movement * speed * deltaTime;
        }
    }
}
