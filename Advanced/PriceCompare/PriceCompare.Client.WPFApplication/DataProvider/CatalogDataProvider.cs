using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PriceCompare.Client.Model;
using PriceCompare.Client.Services.Catalog;
using PriceCompare.Client.Services.Import;

namespace PriceCompare.Client.WPFApplication.DataProvider
{
    class CatalogDataProvider : ICatalogDataProvider
    {
        private ICatalogApi _catalogApi;
        private IImportApi _importApi;

        public CatalogDataProvider(ICatalogApi _catalogApi, IImportApi _importApi)
        {
            this._catalogApi = _catalogApi;
            this._importApi = _importApi;
        }

        public async Task<List<CatalogItem>> GetAllCatalogItems()
        {
            var result = await this._catalogApi.CatalogGetCatalogAsync();

            var listOfCatalogItems = (from item in result
                                      select new CatalogItem
                                      {
                                          Name = item.ProductName,
                                          ByWeight = (bool)item.ByWeight,
                                          Id = (Guid)item.Id,
                                      }).ToList();

            return listOfCatalogItems;
        }

        public bool IsValidQuantity(CatalogItem Item, double Quantity)
        {
            if (Quantity <= 0)
            {
                return false;
            }
            if (Item.ByWeight == false)
            {
                if (Quantity == Math.Truncate(Quantity))
                {
                    return true;
                }
                return false;
            }
            return true;
        }

        public async Task UpdateDataBase()
        {
            await this._importApi.ImportImportAsync();
        }
    }
}
