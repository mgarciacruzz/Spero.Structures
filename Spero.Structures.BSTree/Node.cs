using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Spero.Structures
{
    public class Node<T>:INode<T> where T:IComparable<T>
    {
        #region Ctors
        public Node(T value)
        {
            Value = value;
        }

        public Node(T value, int height)
            : this(value)
        {
            Height = height;
        }
        #endregion

        public int Height { get; set; }

        /// <summary>
        /// Value of the node
        /// </summary>
        public T Value { get; set; }

        /// <summary>
        /// Reference to left node
        /// </summary>
        public INode<T> Left { get; set; }

        /// <summary>
        /// Reference to right node
        /// </summary>
        public INode<T> Right { get; set; }


        /// <summary>
        /// Free references to the nodes
        /// </summary>
        public void Dispose()
        {
            Left = null;
            Right = null;
        }

        #region Overrides
        public override string ToString()
        {
            return string.Format("{0}|{1}|{2}", 
                Left != null? Left.Value.ToString(): "", 
                Value, 
                Right != null ? Right.Value.ToString():"");
        }
        #endregion
    }
}
