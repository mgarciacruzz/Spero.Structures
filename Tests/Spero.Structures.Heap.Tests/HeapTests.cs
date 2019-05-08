using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Spero.Structures;

namespace Spero.Structures.Tests
{
    [TestClass]
    public class HeapTests
    {
        [TestMethod]
        public void InsertTests()
        {
            int[] values = { 2,19,1,11,10,3,18 };
            var minHeap = new MinHeap<int>();

            minHeap.BuildHeap(values);
            var heap = minHeap.Heap;

            Assert.AreEqual(7, minHeap.Size);
            Assert.AreEqual(1, minHeap.GetMin());

            var expectedHeap = new int[] {0, 1, 10, 2, 19, 11, 3, 18 };
            for (int i = 0; i < heap.Length; i++)
            {
                Assert.AreEqual(expectedHeap[i], heap[i]);
            }


        }

        
    }
}
