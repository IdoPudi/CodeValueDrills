using PriceCompare.Backend.Accessors.Import.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PriceCompare.Backend.Accessors.Import.Contracts.DataContracts;
using PriceCompare.Backend.Data.Data;

namespace PriceCompare.Backend.Accessors.Import
{
    public class DBImportAccessor : IDBImportAccessor
    {
        private PriceCompareDBEntities _db = new PriceCompareDBEntities();

        public void ClearDataBase()
        {
            if (!IsProductTableEmpty())
                ClearProductTable();

            if (!IsProductPriceByChainTableEmpty())
                ClearProductPriceByChainTable();
        }

        public List<ChainItem> GetListOfChains()
        {
            var result = (from chain in _db.Chains
                          select new ChainItem
                          {
                              ChainWebSiteLink = chain.ChainWebSiteLink,
                              ChainUserName = chain.ChainUserName,
                              ChainPassword = chain.ChainPassword
                          }).ToList();

            return result;
        }

        public bool IsDataBaseEmpty()
        {
            var valid = false;
            var productTable = IsProductTableEmpty();
            var productByChainTable = IsProductPriceByChainTableEmpty();
           
            if (productTable && productByChainTable)
                valid = true;

            return valid;
        }

        public void SaveProducts(Dictionary<Guid, IEnumerable<DataItem>> Items)
        {
            foreach (var item in Items)
            {
                Product product = new Product();
                product.ProductId = item.Key;
                product.ProductName = item.Value.First().Name;
                product.ByWeight = item.Value.First().ByWeight;
                _db.Products.Add(product);

            }
            _db.SaveChanges();
        }

        public void SaveProductsByChainAndPrice(Dictionary<Guid, IEnumerable<DataItem>> Items)
        {
            foreach (var item in Items)
            {
                foreach (var value in item.Value)
                {
                    ProductPriceByChain productByChain = new ProductPriceByChain();
                    productByChain.ChainID = value.ChainId;
                    productByChain.ProdductPrice = value.ProductPrice;
                    productByChain.ProducyChainId = value.ProductChainIdId;
                    productByChain.ProductID = item.Key;

                    _db.ProductPriceByChains.Add(productByChain);
                }
            }
            _db.SaveChanges();
        }

        private bool IsProductTableEmpty()
        {
            var valid = false;
            var Items = from item in _db.Products
                        select item;

            if (Items == null || Items.Count() == 0)
                valid = true;

            return valid;
        }

        private bool IsProductPriceByChainTableEmpty()
        {
            var valid = false;
            var Items = from item in _db.ProductPriceByChains
                        select item;

            if (Items == null || Items.Count() == 0)
                valid = true;

            return valid;
        }

        private void ClearProductTable()
        {
            _db.DeleteProductsTableRows();
            
            _db.SaveChanges();
        }

        private void ClearProductPriceByChainTable()
        {
            _db.DeleteProductPriceByChainsTableRows();
            
            _db.SaveChanges();
        }
    }
}
