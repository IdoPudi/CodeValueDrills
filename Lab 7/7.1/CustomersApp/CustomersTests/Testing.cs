using CustomersApp;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CustomersTests
{
    [TestClass]
    public class Testing
    {
        [TestMethod]
        public void CompareNamePass()
        {
            Customer customer1 = new Customer { Name = "ido", ID = 21 };
            Customer customer2 = new Customer { Name = "Ido", ID = 20 };

            Assert.AreEqual(0, customer1.CompareTo(customer2));
        }

        [TestMethod]
        public void DiffrentNamePass()
        {
            Customer customer1 = new Customer { Name = "idop", ID = 20 };
            Customer customer2 = new Customer { Name = "Ido", ID = 20 };

            Assert.AreEqual(false, customer1.Equals(customer2));
        }

        [TestMethod]
        public void SameNamePass()
        {
            Customer customer1 = new Customer { Name = "ido", ID = 20 };
            Customer customer2 = new Customer { Name = "ido", ID = 20 };

            Assert.AreEqual(true, customer1.Equals(customer2));
        }

        [TestMethod]
        public void FirstIsBiggerPass()
        {
            Customer customer1 = new Customer { Name = "ido1", ID = 20 };
            Customer customer2 = new Customer { Name = "ido0", ID = 20 };

            Assert.AreEqual(-1, customer1.CompareTo(customer2));
        }

        [TestMethod]
        public void secendIsBiggerPass()
        {
            Customer customer1 = new Customer { Name = "ido0", ID = 20 };
            Customer customer2 = new Customer { Name = "ido1", ID = 20 };

            Assert.AreEqual(1, customer1.CompareTo(customer2));
        }
    }


}
