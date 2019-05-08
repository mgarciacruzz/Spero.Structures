using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Spero.Structures
{
    public interface IMinHeap<T>:IHeap<T> where T:IComparable<T>
    {
        T GetMin();
        T ExtractMin();
    }
}
