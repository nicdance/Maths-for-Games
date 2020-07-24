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
    class GameObject
    {
        protected GameObject parent = null;
        protected List<GameObject> children = new List<GameObject>();

        public Matrix3 localTransform = new Matrix3();
        public Matrix3 globalTransform = new Matrix3();
        void UpdateTransform()
        {
            if (parent != null)
                globalTransform = parent.globalTransform * localTransform;
            else
                globalTransform = localTransform;

            foreach (GameObject child in children)
                child.UpdateTransform();
        }

        public GameObject Parent
        {
            get { return parent; }
        }

        public GameObject()
        {
            if (parent != null)
            {
                parent.RemoveChild(this);
            }

            foreach (GameObject so in children)
            {
                so.parent = null;
            }
        }
        public int GetChildCount()
        {
            return children.Count;
        }
        public GameObject GetChild(int index)
        {
            return children[index];
        }

        public void AddChild(GameObject child)
        {

            child.parent = this;
            children.Add(child);
        }

        public void RemoveChild(GameObject child)
        {
            if (children.Remove(child) == true)
            {
                child.parent = null;
            }
        }

        public void Update(float deltaTime)
        {
            OnUpdate(deltaTime);

            foreach (GameObject child in children)
            {
                child.Update(deltaTime);
            }
        }
        public void Draw()
        {
            OnDraw();

            foreach (GameObject child in children)
            {
                child.Draw();
            }
        }
        public virtual void OnUpdate(float deltaTime)
        {

        }

        public virtual void OnDraw()
        {

        }

        public void SetPosition(float x, float y)
        {
            localTransform.SetTranslation(x, y);
            UpdateTransform();
        }
        public void SetRotate(float radians)
        {
            localTransform.SetRotateZ(radians);
            UpdateTransform();
        }
        public void SetScale(float width, float height)
        {
            localTransform.SetScaled(width, height, 1);
            UpdateTransform();
        }
        public void Translate(float x, float y)
        {
            localTransform.Translate(x, y);
            UpdateTransform();
        }
        public void Rotate(float radians)
        {
            Matrix3 m = new Matrix3();
            m.SetRotateZ(radians);

            SetRotation(localTransform*m);

            UpdateTransform();
        }

        public void SetRotation(Matrix3 m)
        {
            localTransform.m1 = m.m1;
            localTransform.m2 = m.m2;
            localTransform.m3 = m.m3;
            localTransform.m4 = m.m4; 
            localTransform.m5 = m.m5;
            localTransform.m6 = m.m6;
            localTransform.m7 = m.m7;
            localTransform.m8 = m.m8;
            localTransform.m9 = m.m9;
        }
    }
}
