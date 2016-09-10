using PriceCompare.Backend.Accessors.Cart.Contracts.DataContracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PriceCompare.Backend.Managers.Cart.Contracts
{
    public interface ICartManager
    {
        Dictionary<Guid, IEnumerable<ChainProduct>> GetProduct(Guid ProductId);
    }
}
