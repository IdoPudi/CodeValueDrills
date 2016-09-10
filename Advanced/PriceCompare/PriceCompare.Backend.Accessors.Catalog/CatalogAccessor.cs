using PriceCompare.Backend.Accessors.Catalog.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PriceCompare.Backend.Accessors.Catalog.Contracts.DataContracts;
using PriceCompare.Backend.Data.Data;

namespace PriceCompare.Backend.Accessors.Catalog
{
    public class CatalogAccessor : ICatalogAccessor
    {
        private PriceCompareDBEntities _db = new PriceCompareDBEntities();

        public IEnumerable<CatalogProduct> GetAllCatalogProducts()
        {
            var result = from p in _db.Products
                         select new CatalogProduct
                         {
                             ProductName = p.ProductName,
                             Id = p.ProductId,
                             ByWeight = p.ByWeight
                         };

            return result;
        }
    }
}
