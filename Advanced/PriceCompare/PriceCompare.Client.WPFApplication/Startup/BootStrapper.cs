using Autofac;
using PriceCompare.Client.Services.Cart;
using PriceCompare.Client.Services.Catalog;
using PriceCompare.Client.Services.Import;
using PriceCompare.Client.WPFApplication.DataProvider;
using PriceCompare.Client.WPFApplication.View;
using PriceCompare.Client.WPFApplication.ViewModel;
using Prism.Events;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PriceCompare.Client.WPFApplication.Startup
{
    public class BootStrapper
    {
        public IContainer BootStrap()
        {
            var builder = new ContainerBuilder();

            builder.RegisterType<EventAggregator>()
                .As<IEventAggregator>().SingleInstance();

            builder.RegisterType<MainWindow>().AsSelf();
            builder.RegisterType<MainViewModel>().AsSelf();

            builder.RegisterType<CatalogViewModel>()
                .As<ICatalogViewModel>();
            builder.RegisterType<CartViewModel>()
                .As<ICartViewModel>();

            builder.RegisterType<CatalogDataProvider>()
                .As<ICatalogDataProvider>();
            builder.RegisterType<CartDataProvider>()
                .As<ICartDataProvider>();

            builder.RegisterType<CatalogApi>()
                .As<ICatalogApi>();
            builder.RegisterType<ImportApi>()
                .As<IImportApi>();
            builder.RegisterType<CartApi>()
                .As<ICartApi>();

            return builder.Build();
        }
    }
}
