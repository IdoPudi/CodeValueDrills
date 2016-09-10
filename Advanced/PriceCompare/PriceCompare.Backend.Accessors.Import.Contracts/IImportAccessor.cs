using PriceCompare.Backend.Accessors.Import.Contracts.DataContracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;
using System.Xml.Linq;

namespace PriceCompare.Backend.Accessors.Import.Contracts
{
    public interface IImportAccessor
    {
        string[] GetAllXmlFiles();
        XDocument ReadXmlFile(string Path);

        void DeleteAllFiles();
    }
}
