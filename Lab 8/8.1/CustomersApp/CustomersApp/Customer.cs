using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CustomersApp
{
    public class Customer : IComparable<Customer>, IEquatable<Customer>
    {
        public string Name { get; set; }
        public int ID { get; set; }
        public string Address { get; set; }

        public int CompareTo(Customer other) => string.Compare(other.Name, Name, true);

        public bool Equals(Customer other) => other.ID.Equals(ID) && other.Name.Equals(Name);

    }
}
