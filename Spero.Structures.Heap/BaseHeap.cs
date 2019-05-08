using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Spero.Structures
{
    public abstract class BaseHeap<T> : IHeap<T> where T : IComparable<T>
    {
        #region Members
        protected T[] _heap;
        protected int? _max;
        #endregion

        #region Properties
        public int Size { get; private set; }
        public bool IsEmpty => Size == 0;
        public bool IsFull => Size == _heap.Length - 1;
        public bool HasMaxSize => _max.HasValue;
        public T[] Heap => _heap;

        // Private Properties
        protected int Length => _heap.Length;
        #endregion

        #region Ctors
        public BaseHeap(int max)
            :this()
        {
            _max = max;
        }
        public BaseHeap()
        {
            _heap = new T[2];
            Size = 0;
        }
        #endregion

        #region Heap interface
        public void Delete(T key)
        {
            for (int i = 1; i < Size; i++)
            {
                // first find the key
                if (key.CompareTo(_heap[i]) == 0)
                {
                    // Element to be eliminated at the root
                    PercolateUpAlways(i);

                    // Swap the last element with the root
                    _heap[1] = _heap[Size];
                    Size--;

                    PercolateDown(i);
                    return;
                }
            }
        }
        public void Insert(T key)
        {
            if (IsEmpty)
            {
                _heap[1] = key;
                Size++;
            }
            else
            {
                if (IsFull)
                    DoubleSize();

                // Insert new key at the end
                _heap[++Size] = key;

                PercolateUp(Size);
            }
            // Increment size of the Heap
        }
        public void BuildHeap(T[] values)
        {
            for (int i = 0; i < values.Length; i++)
            {
                Insert(values[i]);
            }
        }
        #endregion

        #region Abstract Methods
        public abstract void PercolateUp(int index);
        public abstract void PercolateDown(int index);
        #endregion

        #region Helper Methods
        protected void PercolateUpAlways(int index)
        {
            // Stop at the root
            if (index == 1)
                return;

            var parentIndex = GetParent(index);
            Swap(index, parentIndex);
            PercolateUpAlways(parentIndex);
        }
        protected int GetParent(int index) => index  / 2;
        protected int GetLeft(int index) => index * 2;
        protected int GetRight(int index) => (index * 2) + 1;

        protected void DoubleSize()
        {
            Array.Resize(ref _heap, Length * 2);
        }
        protected void Swap(int indexA, int indexB)
        {
            if (Math.Min(indexA, indexB) < 0)
                throw new IndexOutOfRangeException();

            if (Math.Max(indexA, indexB) > Length - 1)
                throw new IndexOutOfRangeException();

            var temp = _heap[indexA];
            _heap[indexA] = _heap[indexB];
            _heap[indexB] = temp;
        }
        #endregion

    }
}
