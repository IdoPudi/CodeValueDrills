using PriceCompare.Backend.Accessors.Catalog.Contracts.DataContracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PriceCompare.Backend.Managers.Catalog.Contracts
{
    public interface ICatalogManager
    {
        IEnumerable<CatalogProduct> GetCatalog();
    }
}
