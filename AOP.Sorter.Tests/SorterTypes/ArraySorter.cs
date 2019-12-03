using System;
using System.Linq;
using AOP.Homework.Aspects;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace AOP.Sorter.Tests.SorterTypes
{
    [TestClass]
    public class ArraySorter
    {
        [TestMethod]
        public void array_sorter_with_double()
        {
            var testArray = new int[] { 4, 3, 2, 1 };

            var result = SortListInt(testArray);

            var isEqual = Enumerable.SequenceEqual(result, new int[] { 1, 2, 3, 4 });

            Assert.IsTrue(isEqual);

        }



        [OnValueSorterAspect]
        public int[] SortListInt(int[] array)
            => array;
    }
}
