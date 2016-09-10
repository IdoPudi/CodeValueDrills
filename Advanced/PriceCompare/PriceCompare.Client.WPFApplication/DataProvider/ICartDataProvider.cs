using PriceCompare.Client.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PriceCompare.Client.WPFApplication.DataProvider
{
    public interface ICartDataProvider
    {
        Task<CartItem> GetCartItemFromDataBase(CatalogItem catalogItem);
        List<OrderedPrices> GetHighPricesInChainOne(List<CartItem> Cart);
        List<OrderedPrices> GetHighPricesInChainTwo(List<CartItem> Cart);
        List<OrderedPrices> GetHighPricesInChainThree(List<CartItem> Cart);
        List<OrderedPrices> GetLowPricesInChainOne(List<CartItem> Cart);
        List<OrderedPrices> GetLowPricesInChainTwo(List<CartItem> Cart);
        List<OrderedPrices> GetLowPricesInChainThree(List<CartItem> Cart);
    }
}
