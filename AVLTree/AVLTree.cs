using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Spero.Structures
{
    public class AVLTree<T> : BaseTree<T> where T : IComparable<T>
    {
        public AVLTree()
            : base()
        {
        }

        protected override INode<T> Delete(INode<T> root, T value)
        {
            throw new NotImplementedException();
        }

        protected override INode<T> Insert(INode<T> root, T value)
        {
            if (root == null)
            {
                Count++;
                return new Node<T>(value, 0);
            }

            // Value already exists
            if (root.Value.Equals(value))
                return root;

            // value to insert less than the root
            if (root.Value.CompareTo(value) > 0)
            {
                root.Left = Insert(root.Left, value);

            }
            else
            {
                root.Right = Insert(root.Right, value);
            }

            return root;
        }

        #region Helper Methods
        private INode<T> RotateLeft(INode<T> root)
        {
            return null;
        }
        private INode<T> RotateRight(INode<T> root)
        {
            return null;
        }
        #endregion
    }
}
