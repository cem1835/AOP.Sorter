using System;
using System.Collections.Generic;
using System.Linq;
using AOP.Homework.Aspects;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace AOP.Sorter.Tests
{
    [TestClass]
    public class ListSorter
    {
        [TestMethod]
        public void list_sorter_with_integer()
        {
            var testArray = new List<int>() { 4, 3, 2, 1 };

            var result = SortListInt(testArray);

            var isEqual = Enumerable.SequenceEqual(result, new List<int>() { 1, 2, 3, 4 });

            Assert.IsTrue(isEqual);

        }

        [OnValueSorterAspect]
        public List<int> SortListInt(List<int> list)
            => list;
    }
}
