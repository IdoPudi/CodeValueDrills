using PriceCompare.Client.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PriceCompare.Client.WPFApplication.DataProvider
{
    public interface ICatalogDataProvider
    {
        Task<List<CatalogItem>> GetAllCatalogItems();
        Task UpdateDataBase();
        bool IsValidQuantity(CatalogItem Item,double Quantity);
    }
}
