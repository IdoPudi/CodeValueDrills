using PriceCompare.Backend.Accessors.Import.Contracts.DataContracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PriceCompare.Backend.Engiens.Import.Contracts
{
    public interface IImportEngien
    {
        Dictionary<string, DataItem> ReadXmlFile(string Path);
        Dictionary<Guid, IEnumerable<DataItem>> CompareLists(List<Dictionary<string, DataItem>> list);
        Dictionary<Guid, IEnumerable<DataItem>> CompareListsByWeight(List<Dictionary<string, DataItem>> list);
    }
}
