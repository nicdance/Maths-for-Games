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
    // Anything placed in the scene is an object
    class GameObject
    {
        protected GameObject parent = null;                             // Reference To the parent of this object
        protected List<GameObject> children = new List<GameObject>();   // A list of all Children objects. Used to keep all objectes goruped

        public Matrix3 localTransform = new Matrix3();                  // Objects local position. Used for offsetting child objects
        public Matrix3 globalTransform = new Matrix3();                 // Objects position in world space

        public Vector3 Forward
        {
            get { return new Vector3(localTransform.m1, localTransform.m2, 1); }
        }

        // If the child has a parent  this funciton will offset their global Position to that of the parent. 
        // Then it calls this function on each child to  ensure all objects move as a group in correct positions
        public void UpdateAllTransforms()
        {
            if (parent != null)
            {
                globalTransform = parent.globalTransform * localTransform;
            }
            else {
                globalTransform = localTransform;
            }
            foreach (GameObject child in children)
            {
                child.UpdateAllTransforms();
            }
        }

        public void UpdateAllTransforms(Matrix3 _globalTransform)
        {
         //   globalTransform = _globalTransform * localTransform;
            SetRotation(_globalTransform);
            foreach (GameObject child in children)
            {
                child.UpdateAllTransforms();
            }
        }

        // Property to make retreviging the Protected parent class from outside the class.
        public GameObject Parent
        {
            get { return parent; }
        }

        // destructor to clean up and make sure there is no memory leaks.
        ~ GameObject()
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

        //  Retreive the number of Children
        public int GetChildCount()
        {
            return children.Count;
        }

        // Retreive a set child object
        public GameObject GetChild(int index)
        {
            return children[index];
        }

        // Add a new child
        public void AddChild(GameObject child)
        {

            child.parent = this;
            children.Add(child);
        }

        // Remove a given child
        public void RemoveChild(GameObject child)
        {
            if (children.Remove(child) == true)
            {
                child.parent = null;
            }
        }

        // Called to make ensure all onDraw functions are called.
        public void Draw()
        {
            OnDraw();

            foreach (GameObject child in children)
            {
                child.Draw();
            }
        }

        // A virtual ondraw function which in any derived class is ovveridden.
        public virtual void OnDraw()
        {
        }

        // Sets the objects new position and then called up UpdateAllTransforms for this and all child objects,
        public void SetPosition(float x, float y)
        {
            localTransform.SetTranslation(x, y);
            UpdateAllTransforms();
        }

        // Sets the objects new rotation and then called up UpdateAllTransforms for this and all child objects,
        public void SetRotate(float radians)
        {
            localTransform.SetRotateZ(radians);
            UpdateAllTransforms();
        }


        // translates an object and then called up UpdateAllTransforms for this and all child objects,
        public void Translate(float x, float y)
        {
            localTransform.Translate(x, y);
            UpdateAllTransforms();
        }

        // works out the objects rotation Matrix and then sets the rotation.
        // finally it calls UpdateAllTransforms for this and all child objects,
        public void Rotate(float radians)
        {
            Matrix3 m = new Matrix3();
            m.SetRotateZ(radians);

            SetRotation(localTransform * m);

            UpdateAllTransforms();
        }

        // Sets rotation by ensuring vales are correct in the objects local transform
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
        public float GetRotation()
        {

            return (float)Math.Atan2(globalTransform.m2, globalTransform.m1);
        }
    }
}
