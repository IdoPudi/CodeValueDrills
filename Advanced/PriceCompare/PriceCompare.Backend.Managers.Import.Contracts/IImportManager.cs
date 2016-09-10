using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PriceCompare.Backend.Managers.Import.Contracts
{
    public interface IImportManager
    {
        Task ImportDataAsync();
    }
}
