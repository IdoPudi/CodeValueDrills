using Calculator;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CalcTest
{
    //You can add more UnitTests.
    [TestClass]
    public class TestCalc
    {
        [TestMethod]
        public void Calc_Add_BothPositive()
        {
            var calc = new Calc();

            double result = calc.Add(1, 1);

            Assert.AreEqual(2, result);
        }
        [TestMethod]
        public void Calc_Sub_EquelsZero()
        {
            var calc = new Calc();

            double result = calc.Subtract(1, -1);

            Assert.AreNotEqual(0, result);
        }
        [TestMethod]
        public void Calc_Sub_Commutative()
        {
            var calc = new Calc();

            var num1 = 20;
            var num2 = 30;

            Assert.AreNotEqual(calc.Subtract(num1, num2), calc.Subtract(num2, num1));
        }
        [TestMethod]
        public void Calc_Multipliy_SameNumbers()
        {
            var calc = new Calc();

            double result = calc.Multiply(1, 1);

            Assert.AreEqual(1, result);
        }
        [TestMethod]
        public void Calc_Multipliy_TwoZeros()
        {
            var calc = new Calc();

            double result = calc.Multiply(0, 0);

            Assert.AreEqual(0, result);
        }
        [TestMethod]
        public void Calc_Multipliy_OneZeros()
        {
            var calc = new Calc();

            double result = calc.Multiply(1, 0);

            Assert.AreEqual(0, result);
        }
        [TestMethod]
        public void Calc_Multipliy_Commutative()
        {
            var calc = new Calc();

            var num1 = 50;
            var num2 = 50;

            Assert.AreEqual(calc.Multiply(num1, num2), calc.Multiply(num2, num1));
        }
        [TestMethod]
        public void Calc_Divide_Commutative()
        {
            var calc = new Calc();

            var num1 = 10;
            var num2 = 50;

            Assert.AreNotEqual(calc.Divide(num1, num2), calc.Divide(num2, num1));
        }
        [TestMethod]
        public void Calc_Divide_EquelsOne()
        {
            var calc = new Calc();

            double result = calc.Divide(2, 2);

            Assert.AreEqual(1, result);
        }
    }
}
