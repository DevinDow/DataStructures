using System;
using System.Collections;

namespace DataStructures
{
    public class BinarySearchTree<T>
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


        // Fields
        private IComparer comparer;


        // Constructors
        public BinarySearchTree(IComparer comparer)
        {
            this.comparer = comparer;
        }


        // Methods
        public bool Contains(T data)
        {
            return ContainsRecursive(Root, data);
        }
        private bool ContainsRecursive(BinaryTreeNode node, T data)
        {
            if (node == null)
                return false;

            int comparison = comparer.Compare(data, node.Data);
            if (comparison == 0)
                return true;

            if (comparison < 0)
                return ContainsRecursive(node.Left, data);
            return ContainsRecursive(node.Right, data);
        }

        public void Insert(T data)
        {
            var node = new BinaryTreeNode(data);

            if (Root == null) // if the tree is empty, newNode is root
            {
                Root = node;
            }
            else // otherwise, recurse down the tree
            {
                InsertRecursively(Root, new BinaryTreeNode(data));
            }
        }

        private void InsertRecursively(BinaryTreeNode parent, BinaryTreeNode newNode)
        {
            int comparison = comparer.Compare(newNode.Data, parent.Data);
            if (comparison == 0)
                return; // data already in tree

            if (comparison < 0)
            {
                if (parent.Left == null)
                    parent.Left = newNode;
                else
                    InsertRecursively(parent.Left, newNode);
            }
            else
            {
                if (parent.Right == null)
                    parent.Right = newNode;
                else
                    InsertRecursively(parent.Right, newNode);
            }
        }

        public void DisplayTree()
        {
            DisplaySubTreeRecursively(Root);
        }

        private void DisplaySubTreeRecursively(BinaryTreeNode node)
        {
            if (node == null)
                return;

            // Depth-First
            DisplaySubTreeRecursively(node.Left);
            Console.Write(node.Data + " ");
            DisplaySubTreeRecursively(node.Right);
        }
    }
}
