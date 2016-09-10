using PriceCompare.Backend.Accessors.Catalog.Contracts.DataContracts;
using PriceCompare.Backend.Managers.Catalog.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace PriceCompare.Backend.Services.WebApi.Controllers
{
    public class CatalogController : ApiController
    {
        private readonly ICatalogManager _catalogManager;

        public CatalogController(ICatalogManager _catalogManager)
        {
            this._catalogManager = _catalogManager;
        }
        public IEnumerable<CatalogProduct> GetCatalog()
        {
            return this._catalogManager.GetCatalog();
        }
    }
}
