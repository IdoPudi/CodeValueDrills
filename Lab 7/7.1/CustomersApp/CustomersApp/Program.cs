using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CustomersApp
{
    class Program
    {
        static void Main(string[] args)
        {
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
        }
    }
}
