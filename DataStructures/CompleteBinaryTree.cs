using System;
using System.Collections;

namespace DataStructures
{
    /// <summary>
    /// Implemented using an Array.
    /// </summary>
    /// <typeparam name="T">Type of Generic Data</typeparam>
    public abstract class CompleteBinaryTree<T>
    {
        // Fields
        protected ArrayList array = new ArrayList();


        // Constructors
        public CompleteBinaryTree() { }


        // Public Methods
        protected T GetData(int index)
        {
            return (T)array[index];
        }

        protected void SetData(int index, T data)
        {
            array[index] = data;
        }


        // Private Methods
        protected static int CalcParentIndex(int i)
        {
            return (i - 1) / 2;
        }
        protected static int CalcLeftChildIndex(int i)
        {
            return i * 2 + 1;
        }
        protected static int CalcRightChildIndex(int i)
        {
            return CalcLeftChildIndex(i) + 1;
        }
    }
}
