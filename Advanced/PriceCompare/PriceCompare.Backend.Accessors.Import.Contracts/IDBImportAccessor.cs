using PriceCompare.Backend.Accessors.Import.Contracts.DataContracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PriceCompare.Backend.Accessors.Import.Contracts
{
    public interface IDBImportAccessor
    {
        List<ChainItem> GetListOfChains();

        void SaveProducts(Dictionary<Guid, IEnumerable<DataItem>> Items);
        void SaveProductsByChainAndPrice(Dictionary<Guid, IEnumerable<DataItem>> Items);
        bool IsDataBaseEmpty();

        void ClearDataBase();
    }
}
