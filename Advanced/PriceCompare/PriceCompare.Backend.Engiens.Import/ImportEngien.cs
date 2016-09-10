using PriceCompare.Backend.Accessors.Import.Contracts;
using PriceCompare.Backend.Accessors.Import.Contracts.DataContracts;
using PriceCompare.Backend.Engiens.Import.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;
using System.Xml.Linq;

namespace PriceCompare.Backend.Engiens.Import
{
    public class ImportEngien : IImportEngien
    {
        private readonly IImportAccessor _importAccessor;

        public ImportEngien(IImportAccessor _importAccessor)
        {
            this._importAccessor = _importAccessor;
        }

        public Dictionary<Guid, IEnumerable<DataItem>> CompareLists(List<Dictionary<string, DataItem>> list)
        {
            int numberOfDic = list.Count;
            Dictionary<Guid, IEnumerable<DataItem>> combineList = new Dictionary<Guid, IEnumerable<DataItem>>();

            foreach (var item in list.First())
            {
                if (list.All(k => k.ContainsKey(item.Key)))
                {
                    combineList.Add(Guid.NewGuid(), list.Select(dic => dic[item.Key]));
                }
            }

            return combineList;

        }

        public Dictionary<Guid, IEnumerable<DataItem>> CompareListsByWeight(List<Dictionary<string, DataItem>> list)
        {
            Dictionary<Guid, IEnumerable<DataItem>> combineList = new Dictionary<Guid, IEnumerable<DataItem>>();

            foreach (var produceName in GetProductNameList())
            {
                var result = list.SelectMany(v => v.Values.Where(n => n.Name.Equals(produceName)))
                .GroupBy(i => i.ChainId)
                .Select(itemGroup => itemGroup.First());

                if (result.Count() == list.Count())
                {
                    foreach (var item in result)
                    {
                        item.ByWeight = true;
                    }
                    combineList.Add(Guid.NewGuid(), result);
                }
            }

            return combineList;
        }

        public Dictionary<string, DataItem> ReadXmlFile(string Path)
        {
            Dictionary<string, DataItem> list = new Dictionary<string, DataItem>();
            XDocument xml = this._importAccessor.ReadXmlFile(Path);
            var chainId = xml.Descendants("Root").Select(e => e.Element("ChainId").Value).First();
            var parse = from x in xml.Descendants("Item")
                        select new
                        {
                            Id = x.Element("ItemCode").Value,
                            Price = x.Element("ItemPrice").Value,
                            Name = x.Element("ItemName").Value,
                            UnitQty = x.Element("UnitQty").Value
                        };
            foreach (var line in parse)
            {
                if (!list.ContainsKey(line.Id))
                {
                    DataItem item = new DataItem();
                    item.ProductChainIdId = line.Id;
                    item.ProductPrice = Convert.ToDecimal(line.Price);
                    item.ChainId = chainId.ToString();
                    item.Name = ManyToSingle(line.Name);
                    item.ByWeight = false;
                    item.UnitQty = line.UnitQty;
                    list.Add(line.Id, item);
                }

            }

            return list;
        }

        private string ManyToSingle(string name)
        {
            string productName;
            Dictionary<string, string> names = GetProductsName();
            if (names.ContainsKey(name))
            {
                productName = names[name];
            }
            else
            {
                productName = name;
            }
            return productName;
        }

        private Dictionary<string,string> GetProductsName()
        {
            Dictionary<string, string> names = new Dictionary<string, string>();
            names.Add("מלפפונים", "מלפפון");
            names.Add("עגבניות", "עגבניה");
            names.Add("*מבצע* כרוב לבן", "כרוב לבן");
            names.Add("*מבצע* עגבניה", "עגבניה");
            names.Add("*מבצע* מלפפון", "מלפפון");

            return names;
        }
        private List<string> GetProductNameList()
        {
            List<string> products = new List<string>();
            products.Add("עגבניה");
            products.Add("מלפפון");
            products.Add("כרוב לבן");
            products.Add("בצל יבש");
            products.Add("מלון");
            products.Add("שומר");
            products.Add("בטטה");
            products.Add("אבוקדו");
            products.Add("לימון");
            products.Add("אבטיח");

            return products;
        }
    }
}

