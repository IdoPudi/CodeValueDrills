using PriceCompare.Backend.Accessors.Cart.Contracts.DataContracts;
using PriceCompare.Backend.Managers.Cart.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace PriceCompare.Backend.Services.WebApi.Controllers
{
    public class CartController : ApiController
    {
        private readonly ICartManager _cartManager;

        public CartController(ICartManager _cartManager)
        {
            this._cartManager = _cartManager;
        }

        public Dictionary<Guid, IEnumerable<ChainProduct>> GetProductPricesInChains(Guid Id)
        {
            return this._cartManager.GetProduct(Id);
        }
    }
}
