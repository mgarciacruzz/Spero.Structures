using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Spero.Structures
{
    public interface INode<T>:IDisposable where T:IComparable<T>
    {
        /// <summary>
        /// Value of the node
        /// </summary>
        T Value { get; set; }

        /// <summary>
        /// Height of the node
        /// </summary>
        int Height { get; }

        /// <summary>
        /// Reference to left node
        /// </summary>
        INode<T> Left { get; set; }

        /// <summary>
        /// Reference to right node
        /// </summary>
        INode<T> Right { get; set; }


    }
}
