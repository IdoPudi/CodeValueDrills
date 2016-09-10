using Microsoft.Practices.Unity;
using PriceCompare.Backend.Accessors.Cart;
using PriceCompare.Backend.Accessors.Cart.Contracts;
using PriceCompare.Backend.Accessors.Catalog;
using PriceCompare.Backend.Accessors.Catalog.Contracts;
using PriceCompare.Backend.Accessors.Import;
using PriceCompare.Backend.Accessors.Import.Contracts;
using PriceCompare.Backend.Engiens.Import;
using PriceCompare.Backend.Engiens.Import.Contracts;
using PriceCompare.Backend.Managers.Cart;
using PriceCompare.Backend.Managers.Cart.Contracts;
using PriceCompare.Backend.Managers.Catalog;
using PriceCompare.Backend.Managers.Catalog.Contracts;
using PriceCompare.Backend.Managers.Import;
using PriceCompare.Backend.Managers.Import.Contracts;
using System.Web.Http;
using Unity.WebApi;

namespace PriceCompare.Backend.Services.WebApi
{
    public static class UnityConfig
    {
        public static void RegisterComponents()
        {
			var container = new UnityContainer();

            // register all your components with the container here
            // it is NOT necessary to register your controllers

            // e.g. container.RegisterType<ITestService, TestService>();
            container.RegisterType<IImportManager, ImportManager>();
            container.RegisterType<IImportEngien, ImportEngien>();
            container.RegisterType<IImportAccessor, ImportAccessor>();
            container.RegisterType<IDownloadAccessor, DownloadAccessor>();
            container.RegisterType<IDBImportAccessor, DBImportAccessor>();
            container.RegisterType<ICatalogAccessor, CatalogAccessor>();
            container.RegisterType<ICatalogManager, CatalogManager>();
            container.RegisterType<ICartAccessor, CartAccessor>();
            container.RegisterType<ICartManager, CartManager>();
            GlobalConfiguration.Configuration.DependencyResolver = new UnityDependencyResolver(container);
            
        }
    }
}