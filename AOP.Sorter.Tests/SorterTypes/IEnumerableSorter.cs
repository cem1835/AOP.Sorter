using System;
using System.Text;
using System.Collections.Generic;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Linq;
using AOP.Homework.Aspects;

namespace AOP.Sorter.Tests
{
    /// <summary>
    /// Summary description for IEnumerableSorter
    /// </summary>
    [TestClass]
    public class IEnumerableSorter
    {

        [TestMethod]
        public void ienumerable_sort_with_integer()
        {
            var testEnumerable = new List<int>() { 4, 3, 2, 1 }.AsEnumerable();

            var result = SortEnumerableInt(testEnumerable);

            var isEqual = Enumerable.SequenceEqual(result, new List<int>() { 1, 2, 3, 4 }.AsEnumerable());

            Assert.IsTrue(isEqual);

        }
        [OnValueSorterAspect]
        public IEnumerable<int> SortEnumerableInt(IEnumerable<int> source)
                => source;
        
        
        

        [TestMethod]
        public void ienumerable_sort_with_float()
        {
            var testEnumerable = new List<float>() { 4.2f, 4.1f, 4.0f, 2f }.AsEnumerable();

            var result = SortEnumerableFloat(testEnumerable);

            var isEqual = Enumerable.SequenceEqual(result, new List<float>() { 2f,4.0f,4.1f,4.2f}.AsEnumerable());

            Assert.IsTrue(isEqual);
        }
        
        [OnValueSorterAspect]
        public IEnumerable<float> SortEnumerableFloat(IEnumerable<float> source)
                => source;
    }
}
