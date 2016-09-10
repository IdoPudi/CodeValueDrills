using PriceCompare.Backend.Accessors.Import.Contracts.DataContracts;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PriceCompare.Backend.Accessors.Import.Contracts
{
    public interface IDownloadAccessor
    {
        List<string> GetAllFilesNamesInChainFromSite(ChainItem ChainToDownload);
        void DownloadFileFromSite(string FilePathOnSite , ChainItem ChainToDownload);
        void UnZipFiles();
    }
}
