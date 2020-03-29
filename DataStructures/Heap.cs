using System;
using System.Collections;

namespace DataStructures
{
    /// <summary>
    /// Abstract Heap is the Base for MaxHeap & MinHeap, which only need to override NeedToSwap().
    /// It is implemented as a Complete Binary Tree using an Array.
    /// </summary>
    /// <typeparam name="T">Type of Generic Data</typeparam>
    public abstract class Heap<T> : CompleteBinaryTree<T>
    {
        // Fields
        protected IComparer comparer;


        // Constructors
        public Heap(IComparer comparer)
        {
            this.comparer = comparer;
        }


        // Public Methods
        public void Insert(T data)
        {
            // Add new node to end
            int i = array.Count;
            array.Add(data);
            bubbleUp(i);
        }

        public T Extract()
        {
            // get data at root
            T root = GetData(0);

            // replace root with last element
            int lastIndex = array.Count - 1;
            T last = GetData(lastIndex);
            array.RemoveAt(lastIndex);

            return root;
        }


        // Private Methods
        private void bubbleUp(int childIndex)
        {
            int parentIndex = CalcParentIndex(childIndex);
            T parentData = GetData(parentIndex);
            T childData = GetData(childIndex);
            if (FirstShouldBeCloserToRoot(childData, parentData))
            {
                // swap & recurse
                SetData(parentIndex, childData);
                SetData(childIndex, parentData);
                if (parentIndex < 0)
                    bubbleUp(parentIndex);
            }
        }

        private void trikleDown(int parentIndex)
        {
            T parentData = GetData(parentIndex);
            int leftChildIndex = CalcLeftChildIndex(parentIndex);
            T leftData = GetData(leftChildIndex);
            int rightChildIndex = CalcRightChildIndex(parentIndex);
            T rightData = GetData(rightChildIndex);

            if (FirstShouldBeCloserToRoot(leftData, rightData))
            {
                if (FirstShouldBeCloserToRoot(leftData, parentData))
                {
                    // swap & recurse
                    SetData(parentIndex, leftData);
                    SetData(leftChildIndex, parentData);
                    trikleDown(leftChildIndex);
                }
            }
            else
            {
                if (FirstShouldBeCloserToRoot(rightData, parentData))
                {
                    // swap & recurse
                    SetData(parentIndex, rightData);
                    SetData(rightChildIndex, parentData);
                    trikleDown(rightChildIndex);
                }
            }

        }


        // Abstract Methods
        protected abstract bool FirstShouldBeCloserToRoot(T a, T b);
    }

    public class MaxHeap<T> : Heap<T>
    {
        public MaxHeap(IComparer comparer) : base(comparer) { }

        protected override bool FirstShouldBeCloserToRoot(T a, T b)
        {
            return comparer.Compare(a, b) > 0;
        }
    }


    public class MinHeap<T> : Heap<T>
    {
        public MinHeap(IComparer comparer) : base(comparer) { }

        protected override bool FirstShouldBeCloserToRoot(T a, T b)
        {
            return comparer.Compare(a, b) < 0;
        }
    }
}
