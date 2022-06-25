using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace DAAProject
{
    public class Node
    {/// <summary>
    /// left node
    /// </summary>
        public Node left
        {
            get;
            set;
        }
        /// <summary>
        /// right node
        /// </summary>
        public Node right
        {
            get;
            set;
        }
        /// <summary>
        /// Data of the node
        /// </summary>
        public long Data
        {
            get;
            set;
        }
    }
}