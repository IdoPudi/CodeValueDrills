using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PriceCompare.Backend.Accessors.Cart.Contracts.DataContracts
{
    public class ChainProduct
    {
        public string ProductChainId { get; set; }
        public Guid ProductId { get; set; }
        public decimal ProductPrice { get; set; }
        public string ChainId { get; set; }
    }
}
