using PriceCompare.Backend.Accessors.Catalog.Contracts;
using PriceCompare.Backend.Accessors.Catalog.Contracts.DataContracts;
using PriceCompare.Backend.Managers.Catalog.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PriceCompare.Backend.Managers.Catalog
{
    public class CatalogManager : ICatalogManager
    {
        private readonly ICatalogAccessor _catalogAccessor;

        public CatalogManager(ICatalogAccessor _catalogAccessor)
        {
            this._catalogAccessor = _catalogAccessor;
        }
        public IEnumerable<CatalogProduct> GetCatalog()
        {
            return this._catalogAccessor.GetAllCatalogProducts();
        }
    }
}
