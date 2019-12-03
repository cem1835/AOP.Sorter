using System;
using AOP.Homework.Aspects;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace AOP.Sorter.Tests
{
    [TestClass]
    public class StringSorter
    {
        [TestMethod]
        public void string_sorter()
        {
            var testStr = "zycba";

            var result = SortString(testStr);

            Assert.AreEqual("abcyz",result);
        }

        [OnValueSorterAspect]
        public string SortString(string str)
            => str;
    }
}
