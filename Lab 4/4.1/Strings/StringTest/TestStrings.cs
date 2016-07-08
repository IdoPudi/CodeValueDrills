using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Strings;

namespace StringTest
{
    [TestClass]
    public class TestStrings
    {
        [TestMethod]
        public void CountWordsPass()
        {
            Program strings = new Program();
            string[] array = { "I", "AM", "Testing" };
            Assert.AreEqual(3, strings.CountWords(array));
        }

        [TestMethod]
        public void CountWordsFail()
        {
            Program strings = new Program();
            string[] array = { "I", "AM", "Testing" };
            Assert.AreNotEqual(2, strings.CountWords(array));
        }

        [TestMethod]
        public void SortWordsPass()
        {
            Program strings = new Program();
            string[] array1 = { "I", "AM", "Testing" };
            string[] array2 = { "Testing", "AM", "I" };
            array1 = strings.SortWords(array1);
            array2 = strings.SortWords(array2);
            Assert.AreEqual(array1[0], array2[0]);
        }

        [TestMethod]
        public void SortWordsFail()
        {
            Program strings = new Program();
            string[] array1 = { "I", "AM", "Testing" };
            string[] array2 = { "Testing", "AM", "I" };
            array1 = strings.SortWords(array1);
            array2 = strings.SortWords(array2);
            Assert.AreNotEqual(array1[0], array2[2]);
        }

        [TestMethod]
        public void ReverseWordsPass()
        {
            Program strings = new Program();
            string[] array1 = { "I", "AM", "Testing" };
            string[] array2 = { "Testing", "AM", "I" };
            array1 = strings.ReverseWords(array1);
            array2 = strings.ReverseWords(array2);
            Assert.AreEqual(array1[1], array2[1]);
        }

        [TestMethod]
        public void ReverseWordsFail()
        {
            Program strings = new Program();
            string[] array1 = { "I", "AM", "Testing" };
            string[] array2 = { "Testing", "AM", "I" };
            array1 = strings.ReverseWords(array1);
            array2 = strings.ReverseWords(array2);
            Assert.AreNotEqual(array1[0], array2[0]);
        }
    }
}
