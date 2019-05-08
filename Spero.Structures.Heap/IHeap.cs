using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Spero.Structures
{
    public interface IHeap<T> where T:IComparable<T>
    {
        void Delete(T key);
        void Insert(T key);
        T[] Heap { get; }
        void BuildHeap(T[] values);
    }
}
