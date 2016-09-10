using PriceCompare.Backend.Managers.Import.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web.Http;

namespace PriceCompare.Backend.Services.WebApi.Controllers
{
    public class ImportController : ApiController
    {
        private readonly IImportManager _importManager;

        public ImportController(IImportManager _importManager)
        {
            this._importManager = _importManager;
        }
        [HttpGet]
        public async Task Import()
        {
            await this._importManager.ImportDataAsync();
        }
    }
}
