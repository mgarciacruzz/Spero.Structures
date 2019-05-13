using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Spero.Structures
{
    public class BSTree<T> : BaseTree<T> where T : IComparable<T>
    {
        #region Ctors
        public BSTree()
        {
            Count = 0;
            Root = null;
        }
        #endregion

        #region Abstract methods implementation
        protected override INode<T> Insert(INode<T> root, T value)
        {
            // No more nodes
            if (root == null)
            {
                Count++;
                return new Node<T>(value);
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
        protected override INode<T> Delete(INode<T> root, T value)
        {
            // stop when the leave is reachedd
            if (root == null)
                return null;

            if (root.Value.Equals(value))
            {
                if (root.Right == null)
                    return root.Left;

                var min = DeleteMin(root.Right);
                min.Left = root.Left;

                if (root.Right != min)
                    min.Right = root.Right;
                else
                    min.Right = null;
                Count--;
                return min;
            }
            else
            {
                // value is less than root
                if (root.Value.CompareTo(value) > 0)
                    root.Left = Delete(root.Left, value);
                else
                    root.Right = Delete(root.Right, value);

                return root;
            }
        }
        #endregion
    }
}
