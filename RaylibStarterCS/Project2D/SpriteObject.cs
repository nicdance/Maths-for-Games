﻿using System;
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
    class SpriteObject : SceneObject
    {
        Texture2D texture = new Texture2D();
        Image image = new Image();
        public float Width
        {
            get { return texture.width; }
        }
        public float Height
        {
            get { return texture.height; }
        }
        public SpriteObject()
        {
        }
        public void Load(string filename)
        {
            Image img = LoadImage(filename);
            texture = LoadTexture(filename);
        }
        public override void OnDraw()
        {
            float rotation = (float)Math.Atan2(
            globalTransform.m2, globalTransform.m1);
            Raylib.Raylib.DrawTextureEx(
            texture,
            new Vector2(globalTransform.m3, globalTransform.m6),
            rotation * (float)(180.0f / Math.PI),
            1, Color.WHITE);
        }

        public override void OnUpdate(float deltaTime)
        {
            UpdateTransform();
        }

    }
}
