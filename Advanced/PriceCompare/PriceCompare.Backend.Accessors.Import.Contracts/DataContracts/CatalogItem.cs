using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PriceCompare.Backend.Accessors.Import.Contracts.DataContracts
{
    public class CatalogItem
    {
        public Guid Id { get; set; }
        public string ProductName { get; set; }
        public bool ByWeight { get; set; }
    }
}
