using PriceCompare.Backend.Accessors.Catalog.Contracts.DataContracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PriceCompare.Backend.Accessors.Catalog.Contracts
{
    public interface ICatalogAccessor
    {
        IEnumerable<CatalogProduct> GetAllCatalogProducts();
    }
}
