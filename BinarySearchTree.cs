using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace DAAProject
{
    public class BinarySearchTree
    {
        public Node Root { get; set; }
        /// <summary>
        /// Inserting a new node
        /// </summary>
        /// <param name="value"></param>
        /// <returns></returns>
        public bool AddNode(long value)
        {
            Node parentnode = null, currentnode = this.Root;
            Node newnode = new Node();
            newnode.Data = value;
            while (currentnode != null)
            {
                parentnode = currentnode;
                if (newnode.Data < currentnode.Data)
                    currentnode = currentnode.left;
                else if (newnode.Data > currentnode.Data)
                    currentnode = currentnode.right;
                else // As the input is generated randomly it may have duplicates, which shouldn't be allowed to insert
                    return false;
            }
            if (this.Root == null)// if tree is empty new node is added as root
                this.Root = newnode;
            else
            {
                if (newnode.Data < parentnode.Data) // if new node value is less than parent node then it is stored in left else right
                    parentnode.left = newnode;
                else
                    parentnode.right = newnode;
            }
            return true;
        }
        /// <summary>
        /// Searching a node from tree
        /// </summary>
        /// <param name="value"></param>
        /// <param name="parent"></param>
        /// <returns></returns>
        public Node SearchKey(long value, Node parent)
        {
            if (parent != null)
            {
                if (value == parent.Data) 
                    return parent;
                if (value < parent.Data)
                    return SearchKey(value, parent.left);
                else
                    return SearchKey(value, parent.right);
            }

            return null;
        }

    }
}