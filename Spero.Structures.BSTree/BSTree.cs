using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Spero.Structures
{
    public class BSTree<T> : IBSTree<T> where T : IComparable<T>
    {
        #region Properties
        public Node<T> Root { get; private set; }
        public int Count{ get; private set; }
        #endregion

        #region Ctors
        public BSTree()
        {
            Count = 0;
            Root = null;
        }
        #endregion
        public void BuildBSTree(T[] values)
        {
            if (values == null)
                throw new ArgumentNullException("values");

            for (int i = 0; i < values.Length; i++)
            {
                Insert(values[i]);
            }
        }

        public void Delete(T value)
        {
            Root = Delete(Root, value);
        }

        public void Dispose()
        {
            throw new NotImplementedException();
        }

        public string InOrderTraversal()
        {
            throw new NotImplementedException();
        }

        public void Insert(T value)
        {
            if (Root == null)
            {
                Root = new Node<T>(value);
                Count++;
            }
            else
                Insert(Root, value);
        }

        public string PostOrderTraversal()
        {
            throw new NotImplementedException();
        }

        public string PreOrderTraversal()
        {
            throw new NotImplementedException();
        }

        #region Helper methods
        private void Insert(Node<T> root, T value)
        {
            // No more nodes
            if (root == null)
                return;

            // Value already exists
            if (root.Value.Equals(value))
                return;

            // value to insert less than the root
            if (root.Value.CompareTo(value) > 0)
            {
                if (root.Left == null)
                {
                    root.Left = new Node<T>(value);
                    Count++;
                }
                else
                    Insert(root.Left, value);
            }
            else
            {
                if (root.Right == null)
                {
                    root.Right = new Node<T>(value);
                    Count++;
                }
                else
                    Insert(root.Right, value);
            }
        }
        private Node<T> Delete(Node<T> root, T value)
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
        private Node<T> DeleteMin(Node<T> root)
        {
            if (root.Left != null)
            {
                if (root.Left.Left != null)
                    return DeleteMin(root.Left);
                else
                {
                    var left = root.Left;
                    root.Left = null;
                    return left;
                }
            }
            else
                return root; 
        }
        #endregion
    }
}
