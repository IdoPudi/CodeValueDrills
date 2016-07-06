using Microsoft.VisualStudio.TestTools.UnitTesting;
using Quad;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestQuad
{
    [TestClass]
    public class Testing
    {
        public object QuedEquation { get; private set; }

        [TestMethod]
        public void NumberOfArgsPass()
        {
            QuadEquation quad = new QuadEquation();
            string[] stringArguments = { "0", "3", "3" };
            Assert.AreEqual(true, quad.CheckThreeArguments(stringArguments));
        }

        [TestMethod]
        public void NumberOfArgsFail()
        {
            QuadEquation quad = new QuadEquation();
            string[] stringArguments = { "3", "3" };
            Assert.AreEqual(false, quad.CheckThreeArguments(stringArguments));
        }

        [TestMethod]
        public void ParseArgsPass()
        {
            double a = 0;
            double b = 0;
            double c = 0;
            QuadEquation quad = new QuadEquation();
            string[] stringArguments = {"2", "3", "3" };
            Assert.AreEqual(true, quad.CheckParseToDouble(stringArguments,out a, out b,out c));
        }

        [TestMethod]
        public void ParseArgsFail()
        {
            double a = 0;
            double b = 0;
            double c = 0;
            QuadEquation quad = new QuadEquation();
            string[] stringArguments = {"a", "3", "3" };
            Assert.AreEqual(false, quad.CheckParseToDouble(stringArguments, out a, out b, out c));
        }

        [TestMethod]
        public void FirstSolutionPass()
        {
            QuadEquation quad = new QuadEquation();
            double b = 3;
            double c = 3;

            Assert.AreEqual(-1, quad.FirstSolution(b, c));
        }

        [TestMethod]
        public void SecondSolutionPass()
        {
            QuadEquation quad = new QuadEquation();
            double a = 10;
            double b = 32;
            double c = 10;

            Assert.AreEqual(-1, quad.FirstSolution(a, c));
        }

        [TestMethod]
        public void NoSolutionPass()
        {
            QuadEquation quad = new QuadEquation();
            double a = 3;
            double b = 10;
            double c = 3;
            double sqrt = 0;

            Assert.AreEqual(true, quad.NoSolution(a,b, c,out sqrt));
        }

        [TestMethod]
        public void NoSolutionFail()
        {
            QuadEquation quad = new QuadEquation();
            double a = 10;
            double b = 3;
            double c = 10;
            double sqrt = 0;

            Assert.AreEqual(false, quad.NoSolution(a, b, c, out sqrt));
        }
    }
}
