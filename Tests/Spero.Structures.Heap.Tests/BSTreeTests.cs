using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Spero.Structures;

namespace Spero.Structures.Tests
{
    [TestClass]
    public class BSTreeTests
    {
        [TestMethod]
        public void InsertTest()
        {
            var values = new int[] {8,2,1,9,2,5 };
            var bstree = new BSTree<int>();

            bstree.BuildBSTree(values);

            bstree.Delete(5);
        }
    }
}
