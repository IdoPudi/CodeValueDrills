using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CustomersApp
{
    class Program
    {
        public delegate bool CustomerFilter(Customer customer);

        static void Main(string[] args)
        {
            Collection<Customer> list = new Collection<Customer>
            {
                new Customer { Name="ido",ID=190, Address="Tel aviv"},
                new Customer { Name = "itay", ID = 191, Address = "israel" },
                new Customer { Name = "avi", ID = 192, Address = "Eilat" },
                new Customer { Name = "shai", ID = 193, Address = "Yafo" },
                new Customer { Name = "tal", ID = 99, Address = "Beer Sheva" },
                new Customer { Name = "haim", ID = 195, Address = "Batyam" },
                new Customer { Name = "moshe", ID = 196, Address = "Holon" },
                new Customer { Name = "cohen", ID = 197, Address = "Hadera" }
            };

            //Why are creating a new instances of these? The GetCustomer method returns new objects...
            Collection<Customer> filteredListAToK = new Collection<Customer>();
            Collection<Customer> filteredListLToZ = new Collection<Customer>();
            Collection<Customer> filteredListID = new Collection<Customer>();

            #region old lab
            Customer[] customers = new Customer[]{
                new Customer { Name="ido",ID=190, Address="Tel aviv"},
                new Customer { Name = "itay", ID = 191, Address = "israel" },
                new Customer { Name = "avi", ID = 192, Address = "Eilat" },
                new Customer { Name = "shai", ID = 193, Address = "Yafo" },
                new Customer { Name = "tal", ID = 194, Address = "Beer Sheva" },
                new Customer { Name = "haim", ID = 195, Address = "Batyam" },
                new Customer { Name = "moshe", ID = 196, Address = "Holon" },
                new Customer { Name = "cohen", ID = 197, Address = "Hadera" }
            };

            AnotherCustomerComparer anotherCustomer = new AnotherCustomerComparer();

            Array.Sort(customers);

            for (int i = 0; i < customers.Length; i++)
            {
                Console.WriteLine($"Name : {customers[i].Name}, id : {customers[i].ID}, Address : {customers[i].Address}");
            }

            Array.Sort(customers, anotherCustomer);
            Console.WriteLine($"*****Sort by ID*****");
            for (int i = 0; i < customers.Length; i++)
            {

                Console.WriteLine($"Name : {customers[i].Name}, id : {customers[i].ID}, Address : {customers[i].Address}");
            }
            #endregion

            CustomerFilter fillter = FilterCustomer;
            filteredListAToK = GetCustomers(list, fillter);
            filteredListLToZ = GetCustomers(list, delegate (Customer customer)
            {
                if (customer.Name[0] >= 'l')
                {
                    return true;
                }
                return false;
            });

            //The type is redundate
            filteredListID = GetCustomers(list, (Customer customer) =>
            {
                return customer.ID < 100;
            });
            Console.WriteLine("Customer name start with a letter from a to k");

            //You should have extracted this to another method.
            //This is a duplicated code
            foreach (var item in filteredListAToK)
            {
                Console.WriteLine(item.Name);
            }
            Console.WriteLine("Customer name start with l letter from a to z");
            foreach (var item in filteredListLToZ)
            {
                Console.WriteLine(item.Name);
            }
            Console.WriteLine("Customer id is less then 100");
            foreach (var item in filteredListID)
            {
                Console.WriteLine(item.Name);
            }
        }

        //You should have used IEnumerable with yield
        private static Collection<Customer> GetCustomers(Collection<Customer> customers, CustomerFilter filter)
        {
            //foreach (var customer in customers)
            //{
            //    if (filter(customer))
            //    {
            //        yield return customer;
            //    }
            //}
            Collection<Customer> collection = new Collection<Customer>();

            foreach (var item in customers)
            {
                if (filter(item))
                {
                    collection.Add(item);
                }
            }

            return collection;
        }

        private static bool FilterCustomer(Customer customer)
        {
            //You didn't check whether it is 'a' or bigger.
            if (customer.Name[0] <= 'k')
            {
                return true;
            }
            return false;
        }
    }
}
