using GenericLab;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GenericTests
{
    [TestClass]
    public class Testing
    {
        [TestMethod]
        public void AddTwoSameKeysPass()
        {
            MultiDictionary<int, string> dictionary = new MultiDictionary<int, string>
            {
                {2, "two" },
                {2, "nee" }
            };
            Assert.AreEqual(2, dictionary.Count);
        }

        [TestMethod]
        public void AddTwoSameValuesPass()
        {
            MultiDictionary<int, string> dictionary = new MultiDictionary<int, string>
            {
                {2, "three" },
                {1, "three" }
            };
            Assert.AreEqual(2, dictionary.Count);
        }

        [TestMethod]
        public void RemoveKeyPass()
        {
            MultiDictionary<int, string> dictionary = new MultiDictionary<int, string>
            {
                {2, "three" },
                {1, "three" }
            };
            dictionary.Remove(2);
            Assert.AreEqual(1, dictionary.Count);
        }

        [TestMethod]
        public void RemoveKeyValuePass()
        {
            MultiDictionary<int, string> dictionary = new MultiDictionary<int, string>
            {
                {2, "three" },
                {1, "three" }
            };
            dictionary.Remove(2,"three");
            Assert.AreEqual(1, dictionary.Count);
        }

        [TestMethod]
        public void ClearPass()
        {
            MultiDictionary<int, string> dictionary = new MultiDictionary<int, string>
            {
                {2, "three" },
                {1, "three" }
            };
            dictionary.Clear();
            Assert.AreEqual(0, dictionary.Count);
        }

        [TestMethod]
        public void ContainsKeyPass()
        {
            MultiDictionary<int, string> dictionary = new MultiDictionary<int, string>
            {
                {2, "three" },
                {1, "three" }
            };
            Assert.AreEqual(true, dictionary.ContainsKey(1));
        }

        [TestMethod]
        public void ContainsKeyFail()
        {
            MultiDictionary<int, string> dictionary = new MultiDictionary<int, string>
            {
                {2, "three" },
                {1, "three" }
            };
            Assert.AreEqual(false, dictionary.ContainsKey(3));
        }

        [TestMethod]
        public void ContainPass()
        {
            MultiDictionary<int, string> dictionary = new MultiDictionary<int, string>
            {
                {2, "three" },
                {1, "three" }
            };
            Assert.AreEqual(true, dictionary.Contains(1,"three"));
        }

        [TestMethod]
        public void ContainFail()
        {
            MultiDictionary<int, string> dictionary = new MultiDictionary<int, string>
            {
                {2, "three" },
                {1, "three" }
            };
            Assert.AreEqual(false, dictionary.Contains(3, "three"));
        }
    }
}
