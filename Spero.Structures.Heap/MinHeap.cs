using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Spero.Structures
{
    public class MinHeap<T> : BaseHeap<T>, IMinHeap<T> where T : IComparable<T>
    {
        #region Ctors
        public MinHeap()
            : base()
        {
        }

        public MinHeap(int max)
            : base(max)
        {
        }
        #endregion

        #region IMinHeap interface
        public T ExtractMin()
        {
            if (IsEmpty)
                throw new InvalidOperationException("Empty heap");

            // copy of min
            var min = _heap[1];

            Delete(_heap[1]);

            return min;
        }
        public T GetMin()
        {
            if (IsEmpty)
                throw new InvalidOperationException("Empty heap");

            return _heap[1];
        }
        #endregion

        #region Abstracts overrides
        public override void PercolateUp(int index)
        {
            // no need to percolate if already the root
            if (index == 1)
                return;

            var parentIndex = GetParent(index);
            if (_heap[parentIndex].CompareTo(_heap[index]) > 0)
            {
                Swap(index, parentIndex);
                PercolateUp(parentIndex);
            }
        }
        public override void PercolateDown(int index)
        {
            var leftIndex = GetLeft(index);
            var rightIndex = GetRight(index);
            var smallest = index;

            if (leftIndex < Size && _heap[leftIndex].CompareTo(_heap[index]) < 0)
            {
                smallest = leftIndex;
            }

            if (rightIndex < Size && _heap[rightIndex].CompareTo(_heap[smallest]) < 0)
            {
                smallest = rightIndex;
            }

            if (smallest != index)
            {
                Swap(index, smallest);
                PercolateDown(smallest);
            }
        }
        #endregion
    }
}
