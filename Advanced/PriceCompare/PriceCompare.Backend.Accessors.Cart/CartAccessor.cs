using PriceCompare.Backend.Accessors.Cart.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PriceCompare.Backend.Accessors.Cart.Contracts.DataContracts;
using PriceCompare.Backend.Data.Data;

namespace PriceCompare.Backend.Accessors.Cart
{
    public class CartAccessor : ICartAccessor
    {
        private PriceCompareDBEntities _db = new PriceCompareDBEntities();

        public Dictionary<Guid, IEnumerable<ChainProduct>> GetProductPriceInEachChain(Guid ProductId)
        {
            Dictionary<Guid, IEnumerable<ChainProduct>> product = new Dictionary<Guid, IEnumerable<ChainProduct>>();

            var result = (from p in _db.ProductPriceByChains
                          where p.ProductID == ProductId
                          select new ChainProduct
                          {
                              ChainId = p.ChainID,
                              ProductPrice = p.ProdductPrice,
                              ProductId = ProductId,
                              ProductChainId = p.ProducyChainId
                          }).AsEnumerable();

            product.Add(ProductId, result);

            return product;
        }
    }
}
