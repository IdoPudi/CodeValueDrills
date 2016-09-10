using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PriceCompare.Client.Model;
using PriceCompare.Client.Services.Cart;

namespace PriceCompare.Client.WPFApplication.DataProvider
{
    class CartDataProvider : ICartDataProvider
    {
        private ICartApi _cartApi;

        public CartDataProvider(ICartApi _cartApi)
        {
            this._cartApi = _cartApi;
        }

        public async Task<CartItem> GetCartItemFromDataBase(CatalogItem catalogItem)
        {
            var apiResult = await this._cartApi.CartGetProductPricesInChainsAsync(catalogItem.Id);
            var carItem = (from item in apiResult
                           select new CartItem
                           {
                               Id = (Guid)item.Key,
                               ChainOneItemPrice = (double)item.Value[0].ProductPrice,
                               ChainTwoItemPrice = (double)item.Value[1].ProductPrice,
                               ChainThreeItemPrice = (double)item.Value[2].ProductPrice,
                               Quantity = catalogItem.Quantity,
                               Name = catalogItem.Name,
                               ByWeight = catalogItem.ByWeight,
                           }).SingleOrDefault();
            carItem.ByWeightInString = GetByWeightInString(carItem.ByWeight);
            return carItem;

        }

        public List<OrderedPrices> GetHighPricesInChainOne(List<CartItem> Cart)
        {
            var result = (from c in Cart
                          orderby c.ChainOneItemPrice descending
                          select new OrderedPrices
                          {
                              Name = c.Name,
                              Price = c.ChainOneItemPrice
                          }).Take(3);

            return result.ToList();
        }

        public List<OrderedPrices> GetHighPricesInChainTwo(List<CartItem> Cart)
        {
            var result = (from c in Cart
                          orderby c.ChainTwoItemPrice descending
                          select new OrderedPrices
                          {
                              Name = c.Name,
                              Price = c.ChainTwoItemPrice
                          }).Take(3);

            return result.ToList();
        }

        public List<OrderedPrices> GetHighPricesInChainThree(List<CartItem> Cart)
        {
            var result = (from c in Cart
                          orderby c.ChainThreeItemPrice descending
                          select new OrderedPrices
                          {
                              Name = c.Name,
                              Price = c.ChainThreeItemPrice
                          }).Take(3);

            return result.ToList();
        }

        private string GetByWeightInString(bool byWeight)
        {
            string result;
            if (byWeight)
            {
                result = "במשקל";
            }
            else
            {
                result = "יח'";
            }
            return result;
        }

        public List<OrderedPrices> GetLowPricesInChainOne(List<CartItem> Cart)
        {
            var result = (from c in Cart
                          orderby c.ChainOneItemPrice
                          select new OrderedPrices
                          {
                              Name = c.Name,
                              Price = c.ChainOneItemPrice
                          }).Take(3);

            return result.ToList();
        }

        public List<OrderedPrices> GetLowPricesInChainTwo(List<CartItem> Cart)
        {
            var result = (from c in Cart
                          orderby c.ChainTwoItemPrice
                          select new OrderedPrices
                          {
                              Name = c.Name,
                              Price = c.ChainTwoItemPrice
                          }).Take(3);

            return result.ToList();
        }

        public List<OrderedPrices> GetLowPricesInChainThree(List<CartItem> Cart)
        {
            var result = (from c in Cart
                          orderby c.ChainThreeItemPrice
                          select new OrderedPrices
                          {
                              Name = c.Name,
                              Price = c.ChainThreeItemPrice
                          }).Take(3);

            return result.ToList();
        }
    }
}
