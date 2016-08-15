using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BinaryDisplay;

namespace TestBinary
{
    //Not enough tests.
    [TestClass]
    public class Test
    {
        [TestMethod]
        public void TestZero()
        {
            int num = 0;
            Program binary = new Program();
            Assert.AreEqual("", binary.ConvertNumber(num));
        }
        [TestMethod]
        public void TestMinValue()
        {
            int num = int.MinValue;
            Program binary = new Program();
            Assert.AreEqual("", binary.ConvertNumber(num));
        }
        [TestMethod]
        public void TestRegularNumber()
        {
            int num = 8;
            Program binary = new Program();
            Assert.AreEqual("1000", binary.ConvertNumber(num));
        }
    }
}
