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
        public GameObject parent = null;
        protected List<GameObject> children = new List<GameObject>();


        public Matrix3 localTransform = new Matrix3();
        public Matrix3 globalTransform = new Matrix3();
        public void UpdateTransform()
        {
            if (parent != null)
                globalTransform = parent.globalTransform * localTransform;
            else
                globalTransform = localTransform;

            foreach (GameObject child in children)
                child.UpdateTransform();
        }

        public GameObject()
        {
        }
        public int GetChildCount()
        {
            return children.Count;
        }
        public GameObject GetChild(int index)
        {
            return children[index];
        }

        public void SetPosition(float x, float y)
        {
            localTransform.m7 = x;
            localTransform.m8 = y;
            //localTransform.SetTranslation(x, y);
            UpdateTransform();
        }
        public void SetRotate(float radians)
        {
            localTransform.SetRotateZ(radians);
            UpdateTransform();
        }
        public void Translate(float x, float y)
        {
            // localTransform.Translate(x, y);
            localTransform.m7 += x;
            localTransform.m8 += y;


            UpdateTransform();
        }
        public void Rotate(float radians)
        {
            localTransform.SetRotateZ(radians);
            UpdateTransform();
        }

        public void AddChild(GameObject child)
        {
            if (child.parent == null) {
                return;
            }
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

        ~GameObject()
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

        public virtual void OnUpdate(float deltaTime)
        {
        }
        public virtual void OnDraw()
        {
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

    }
}
