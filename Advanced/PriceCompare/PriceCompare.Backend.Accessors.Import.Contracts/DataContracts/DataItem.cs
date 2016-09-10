using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PriceCompare.Backend.Accessors.Import.Contracts.DataContracts
{
    public class DataItem
    {
        public string ProductChainIdId { get; set; }
        public decimal ProductPrice { get; set; }
        public string ChainId { get; set; }
        public string Name { get; set; }
        public bool ByWeight { get; set; }
        public string UnitQty { get; set; }
    }
}
