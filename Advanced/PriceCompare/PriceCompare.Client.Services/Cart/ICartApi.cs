using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PriceCompare.Client.Services.Api;

namespace PriceCompare.Client.Services.Cart
{
    public interface ICartApi
    {
        /// <summary>
        /// 
        /// </summary>
        /// <remarks>
        /// 
        /// </remarks>
        /// <exception cref="IO.Swagger.Client.ApiException">Thrown when fails to make API call</exception>
        /// <param name="id"></param>
        /// <returns>Task of Dictionary&lt;string, List&lt;ChainProduct&gt;&gt;</returns>
        System.Threading.Tasks.Task<Dictionary<Guid, List<ChainProduct>>> CartGetProductPricesInChainsAsync(Guid? id);

        /// <summary>
        /// 
        /// </summary>
        /// <remarks>
        /// 
        /// </remarks>
        /// <exception cref="IO.Swagger.Client.ApiException">Thrown when fails to make API call</exception>
        /// <param name="id"></param>
        /// <returns>Task of ApiResponse (Dictionary&lt;string, List&lt;ChainProduct&gt;&gt;)</returns>
        System.Threading.Tasks.Task<ApiResponse<Dictionary<Guid, List<ChainProduct>>>> CartGetProductPricesInChainsAsyncWithHttpInfo(Guid? id);
    }
}
