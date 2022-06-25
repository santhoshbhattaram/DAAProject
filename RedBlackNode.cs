using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace DAAProject
{
    class RedBlackNode
    {
        public long data;
        RedBlackNode root;
        RedBlackNode left;
        RedBlackNode right;
        RedBlackNode parent;
        bool color;
        bool RED = false;
        bool BLACK = true;
        /// <summary>
        /// Constructor
        /// </summary>
        public RedBlackNode()
        {
        }
        /// <summary>
        /// Creating a new node with Data
        /// </summary>
        /// <param name="data"></param>
        public RedBlackNode(long data)
        {
            this.data = data;
        }
        /// <summary>
        /// Right rotation of Red black tree
        /// </summary>
        /// <param name="node"></param>
        private void rotateRight(RedBlackNode node)
        {
            RedBlackNode parent = node.parent;
            RedBlackNode leftChild = node.left;

            node.left = leftChild.right;
            if (leftChild.right != null)
            {
                leftChild.right.parent = node;
            }

            leftChild.right = node;
            node.parent = leftChild;
            rotatingchildrens(parent, node, leftChild);
        }
        /// <summary>
        /// rotating the children nodes
        /// </summary>
        /// <param name="parent"></param>
        /// <param name="oldchildnode"></param>
        /// <param name="newchildnode"></param>
        private void rotatingchildrens(RedBlackNode parent, RedBlackNode oldchildnode, RedBlackNode newchildnode)
        {
            if (parent == null)
            {
                root = newchildnode;
            }
            else if (parent.left == oldchildnode)
            {
                parent.left = newchildnode;
            }
            else if (parent.right == oldchildnode)
            {
                parent.right = newchildnode;
            }

            if (newchildnode != null)
            {
                newchildnode.parent = parent;
            }
        }
        /// <summary>
        /// left rotation of tree
        /// </summary>
        /// <param name="node"></param>
        private void rotateLeft(RedBlackNode node)
        {
            RedBlackNode parent = node.parent;
            RedBlackNode rightChild = node.right;

            node.right = rightChild.left;
            if (rightChild.left != null)
            {
                rightChild.left.parent = node;
            }
            rightChild.left = node;
            node.parent = rightChild;
            rotatingchildrens(parent, node, rightChild);
        }
        /// <summary>
        /// Searching a node in tree
        /// </summary>
        /// <param name="key"></param>
        /// <returns></returns>
        public RedBlackNode searchNode(long key)
        {
            RedBlackNode node = this.root;
            while (node != null)
            {
                if (key == node.data)
                {
                    return node;
                }
                else if (key < node.data)
                {
                    node = node.left;
                }
                else
                {
                    node = node.right;
                }
            }

            return null;
        }
        /// <summary>
        /// Inserting new node
        /// </summary>
        /// <param name="key"></param>
        /// <returns></returns>
        public bool AddNode(long key)
        {
            RedBlackNode node = root;
            RedBlackNode parent = null;
            //Traversing to find the place to insert new node
            while (node != null)
            {
                parent = node;
                if (key < node.data)
                {
                    node = node.left;
                }
                else if (key > node.data)
                {
                    node = node.right;
                }
                else
                {
                    return false;
                }
            }

            // Insert new node create as red new node
            RedBlackNode newNode = new RedBlackNode(key);
            newNode.color = RED;
            if (parent == null)
            {
                root = newNode;
            }
            else if (key < parent.data)
            {
                parent.left = newNode;
            }
            else
            {
                parent.right = newNode;
            }
            newNode.parent = parent;

            Recoloring(newNode);
            return true;
        }
        /// <summary>
        /// Recoloring the nodes to red or black
        /// </summary>
        /// <param name="node"></param>
        private void Recoloring(RedBlackNode node)
        {
            RedBlackNode parent = node.parent;

            // Reached root node which should always be black
            if (parent == null)
            {
                node.color = BLACK;
                return;
            }

            // Parent is black  no change exit
            if (parent.color == BLACK)
            {
                return;
            }

            RedBlackNode grandparent = parent.parent;
            if (grandparent == null)
            {
                parent.color = BLACK;
                return;
            }

            RedBlackNode uncle = getUncle(parent);

            if (uncle != null && uncle.color == RED)
            {
                parent.color = BLACK;
                grandparent.color = RED;
                uncle.color = BLACK;
                Recoloring(grandparent);
            }
            else if (parent == grandparent.left)
            {
                if (node == parent.right)
                {
                    rotateLeft(parent);
                    parent = node;
                }
                rotateRight(grandparent);
                parent.color = BLACK;
                grandparent.color = RED;
            }

            // Parent is right child of grandparent
            else
            {
                if (node == parent.left)
                {
                    rotateRight(parent);
                    parent = node;
                }
                rotateLeft(grandparent);
                parent.color = BLACK;
                grandparent.color = RED;
            }
        }
        /// <summary>
        /// Getting Uncle node 
        /// </summary>
        /// <param name="parent"></param>
        /// <returns></returns>
        private RedBlackNode getUncle(RedBlackNode parent)
        {
            RedBlackNode grandparent = parent.parent;
            if (grandparent.left == parent)
            {
                return grandparent.right;
            }
            else if (grandparent.right == parent)
            {
                return grandparent.left;
            }
            else
            {
                return null;
            }
        }

    }
}