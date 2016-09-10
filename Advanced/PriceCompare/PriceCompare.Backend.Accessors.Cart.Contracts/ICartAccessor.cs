using PriceCompare.Backend.Accessors.Cart.Contracts.DataContracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PriceCompare.Backend.Accessors.Cart.Contracts
{
    public interface ICartAccessor
    {
        Dictionary<Guid, IEnumerable<ChainProduct>> GetProductPriceInEachChain(Guid ProductId);
    }
}
