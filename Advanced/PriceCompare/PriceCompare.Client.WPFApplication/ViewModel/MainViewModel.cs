using PriceCompare.Client.WPFApplication.Command;
using PriceCompare.Client.WPFApplication.Events;
using Prism.Events;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace PriceCompare.Client.WPFApplication.ViewModel
{
    public class MainViewModel : ViewModelBase
    {
        private bool _isBusy;
        private IEventAggregator _eventAggregator;
        public MainViewModel(ICatalogViewModel catalogViewModel,
            ICartViewModel cartViewModel, IEventAggregator eventAggregator)
        {
            CatalogViewModel = catalogViewModel;
            CartViewModel = cartViewModel;
            _eventAggregator = eventAggregator;
            GetCatalog = new DelegateCommand(OnGetCatalogExecute);
            UpdateDataBase = new DelegateCommand(OnUpdateDataBaseExecute);
        }

        private async void OnUpdateDataBaseExecute(object obj)
        {
            try
            {
                _isBusy = true;
                OnPropertyChanged(nameof(IsBusy));
                _eventAggregator.GetEvent<ClearCartAndCatalogEvent>().Publish();
                await CatalogViewModel.UpdateDB();
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                _isBusy = false;
                OnPropertyChanged(nameof(IsBusy));
            }

        }

        private async void OnGetCatalogExecute(object obj)
        {
            try
            {
                _isBusy = true;
                OnPropertyChanged(nameof(IsBusy));
                _eventAggregator.GetEvent<ClearCartAndCatalogEvent>().Publish();
                await CatalogViewModel.Load();
            }
            catch (Exception ex)
            {

                throw ex;
            }
            finally
            {
                _isBusy = false;
                OnPropertyChanged(nameof(IsBusy));
            }

        }

        public ICommand GetCatalog { get; private set; }

        public ICommand UpdateDataBase { get; private set; }

        public bool IsBusy
        {
            get { return _isBusy; }
            set
            {
                _isBusy = value;
                OnPropertyChanged();
            }
        }

        public ICatalogViewModel CatalogViewModel { get; private set; }
        public ICartViewModel CartViewModel { get; private set; }
    }
}
