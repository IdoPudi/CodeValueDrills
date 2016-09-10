using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PriceCompare.Client.Services.Api;

namespace PriceCompare.Client.Services.Catalog
{
    /// <summary>
    /// Represents a collection of functions to interact with the API endpoints
    /// </summary>
    public interface ICatalogApi : IApiAccessor
    {
        #region Synchronous Operations
        /// <summary>
        /// 
        /// </summary>
        /// <remarks>
        /// 
        /// </remarks>
        /// <exception cref="IO.Swagger.Client.ApiException">Thrown when fails to make API call</exception>
        /// <returns>List&lt;CatalogProduct&gt;</returns>
        List<CatalogProduct> CatalogGetCatalog();

        /// <summary>
        /// 
        /// </summary>
        /// <remarks>
        /// 
        /// </remarks>
        /// <exception cref="IO.Swagger.Client.ApiException">Thrown when fails to make API call</exception>
        /// <returns>ApiResponse of List&lt;CatalogProduct&gt;</returns>
        ApiResponse<List<CatalogProduct>> CatalogGetCatalogWithHttpInfo();
        #endregion Synchronous Operations
        #region Asynchronous Operations
        /// <summary>
        /// 
        /// </summary>
        /// <remarks>
        /// 
        /// </remarks>
        /// <exception cref="IO.Swagger.Client.ApiException">Thrown when fails to make API call</exception>
        /// <returns>Task of List&lt;CatalogProduct&gt;</returns>
        System.Threading.Tasks.Task<List<CatalogProduct>> CatalogGetCatalogAsync();

        /// <summary>
        /// 
        /// </summary>
        /// <remarks>
        /// 
        /// </remarks>
        /// <exception cref="IO.Swagger.Client.ApiException">Thrown when fails to make API call</exception>
        /// <returns>Task of ApiResponse (List&lt;CatalogProduct&gt;)</returns>
        System.Threading.Tasks.Task<ApiResponse<List<CatalogProduct>>> CatalogGetCatalogAsyncWithHttpInfo();
        #endregion Asynchronous Operations
    }
}
