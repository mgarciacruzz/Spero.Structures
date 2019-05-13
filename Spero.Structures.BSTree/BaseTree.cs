using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Spero.Structures
{
    public abstract class BaseTree<T> : IBSTree<T> where T : IComparable<T>
    {
        #region Properties
        public INode<T> Root { get; protected set; }
        public int Count { get; protected set; }
        #endregion

        #region Ctors
        public BaseTree()
        {
            Count = 0;
            Root = null;
        }
        #endregion

        #region Interface methods
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
        public void Insert(T value)
        {
            Root = Insert(Root, value);
        }

        public string InOrderTraversal()
        {
            throw new NotImplementedException();
        }
        public string PostOrderTraversal()
        {
            throw new NotImplementedException();
        }
        public string PreOrderTraversal()
        {
            throw new NotImplementedException();
        }
        public void Dispose()
        {
            throw new NotImplementedException();
        }
        #endregion

        #region Abstract metho signatures
        protected abstract INode<T> Insert(INode<T> root, T value);
        protected abstract INode<T> Delete(INode<T> root, T value);
        #endregion

        #region Helper Methods
        protected INode<T> DeleteMin(INode<T> root)
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
