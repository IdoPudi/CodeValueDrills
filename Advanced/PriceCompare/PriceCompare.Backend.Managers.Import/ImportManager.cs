using PriceCompare.Backend.Accessors.Import.Contracts;
using PriceCompare.Backend.Accessors.Import.Contracts.DataContracts;
using PriceCompare.Backend.Engiens.Import.Contracts;
using PriceCompare.Backend.Managers.Import.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PriceCompare.Backend.Managers.Import
{
    public class ImportManager : IImportManager
    {
        private readonly IImportEngien _importEngien;
        private readonly IImportAccessor _importAccessor;
        private readonly IDownloadAccessor _downloadAccessor;
        private readonly IDBImportAccessor _DBImportAccessor;

        public ImportManager(IImportEngien _importEngien, IImportAccessor _importAccessor,
            IDownloadAccessor _downloadAccessor, IDBImportAccessor _DBImportAccessor)
        {
            this._importEngien = _importEngien;
            this._importAccessor = _importAccessor;
            this._downloadAccessor = _downloadAccessor;
            this._DBImportAccessor = _DBImportAccessor;
        }

        public async Task ImportDataAsync()
        {
            var chains = this._DBImportAccessor.GetListOfChains();
            List<Task> downloadTasks = new List<Task>();
            foreach (var item in chains)
            {
                downloadTasks.Add(Task.Run(() => DownloadFilesFromWebsite(item)));

            }
            await Task.WhenAll(downloadTasks);

            this._downloadAccessor.UnZipFiles();

            var xmlFilesPaths = this._importAccessor.GetAllXmlFiles();
            List<Task<Dictionary<string, DataItem>>> importTasks = new List<Task<Dictionary<string, DataItem>>>();
            foreach (string item in xmlFilesPaths)
            {
                importTasks.Add(Task.Run(() => this._importEngien.ReadXmlFile(item)));
            }
            await Task.WhenAll(importTasks);

            List<Dictionary<string, DataItem>> list = new List<Dictionary<string, DataItem>>();
            foreach (var task in importTasks)
            {
                list.Add(task.Result);
            }

            var allItemsWithTheSameId = this._importEngien.CompareLists(list);
            var ItemsByWeight = this._importEngien.CompareListsByWeight(list);

            Dictionary<Guid, IEnumerable<DataItem>> listForDB = new Dictionary<Guid, IEnumerable<DataItem>>();
            listForDB = ItemsByWeight.Concat(allItemsWithTheSameId.Take(10)).ToDictionary(x => x.Key, x => x.Value);
            //listForDB = ItemsByWeight.Concat(allItemsWithTheSameId).ToDictionary(x => x.Key, x => x.Value);
            UpdateDB(listForDB);
            _importAccessor.DeleteAllFiles();
        }

        private void UpdateDB(Dictionary<Guid, IEnumerable<DataItem>> allItems)
        {
            if (this._DBImportAccessor.IsDataBaseEmpty())
            {
                this._DBImportAccessor.SaveProducts(allItems);
                this._DBImportAccessor.SaveProductsByChainAndPrice(allItems);
            }
            else
            {
                this._DBImportAccessor.ClearDataBase();
                this._DBImportAccessor.SaveProducts(allItems);
                this._DBImportAccessor.SaveProductsByChainAndPrice(allItems);
            }
        }

        private void DownloadFilesFromWebsite(ChainItem item)
        {
            var listOfFilesNames = this._downloadAccessor.GetAllFilesNamesInChainFromSite(item);
            this._downloadAccessor.DownloadFileFromSite(listOfFilesNames.First(), item);
        }
    }
}
