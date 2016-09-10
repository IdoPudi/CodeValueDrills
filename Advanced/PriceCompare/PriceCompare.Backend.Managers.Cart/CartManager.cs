using PriceCompare.Backend.Accessors.Cart.Contracts;
using PriceCompare.Backend.Managers.Cart.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PriceCompare.Backend.Accessors.Cart.Contracts.DataContracts;

namespace PriceCompare.Backend.Managers.Cart
{
    public class CartManager : ICartManager
    {
        private readonly ICartAccessor _cartAccessor;

        public CartManager(ICartAccessor _cartAccessor)
        {
            this._cartAccessor = _cartAccessor;
        }

        public Dictionary<Guid, IEnumerable<ChainProduct>> GetProduct(Guid ProductId)
        {
            return _cartAccessor.GetProductPriceInEachChain(ProductId);
        }
    }
}
