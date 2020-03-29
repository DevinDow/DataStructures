using System;

namespace DataStructures
{
    public abstract class BinaryTree<T>
    {
        // BinaryTreeNode class
        public class BinaryTreeNode
        {
            public T Data;
            public BinaryTreeNode Left, Right;

            public BinaryTreeNode(T data)
            {
                Data = data;
            }
        }


        // Properties
        public BinaryTreeNode Root = null;


        // Constructors
        public BinaryTree() { }


        // Methods
        public BinaryTreeNode Insert(T data)
        {
            var node = new BinaryTreeNode(data);

            return node;
        }

        public BinaryTreeNode Extract()
        {

            return Root;
        }
    }
}
