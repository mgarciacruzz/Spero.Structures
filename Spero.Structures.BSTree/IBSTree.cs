using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Spero.Structures
{
    public interface IBSTree<T> : IDisposable where T : IComparable<T>
    {
        /// <summary>
        /// Number of elements in the tree
        /// </summary>
        int Count{ get; }

        /// <summary>
        /// Root of the tree
        /// </summary>
        INode<T> Root { get; }

        /// <summary>
        /// Inserts a value into the tree
        /// </summary>
        /// <param name="value"></param>
        void Insert(T value);

        /// <summary>
        /// Deletes a value from the tree
        /// </summary>
        /// <param name="value"></param>
        void Delete(T value);

        /// <summary>
        /// Builds a BSTree from an array
        /// </summary>
        /// <param name="values"></param>
        void BuildBSTree(T[] values);
    
        /// <summary>
        /// Traversal of the tree printing root, left child and right child in that order
        /// </summary>
        /// <returns></returns>
        string PreOrderTraversal();

        /// <summary>
        /// Traversal of the tree printing left child ,root and right child in that order
        /// </summary>
        /// <returns></returns>
        string InOrderTraversal();

        /// <summary>
        /// Traversal of the tree printing left child , right child and root in that order
        /// </summary>
        /// <returns></returns>
        string PostOrderTraversal();
    }
}
