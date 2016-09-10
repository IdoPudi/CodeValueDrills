using PriceCompare.Client.Model;
using PriceCompare.Client.WPFApplication.Command;
using PriceCompare.Client.WPFApplication.DataProvider;
using PriceCompare.Client.WPFApplication.Events;
using Prism.Events;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace PriceCompare.Client.WPFApplication.ViewModel
{
    public interface ICatalogViewModel
    {
        Task Load();
        Task UpdateDB();
    }

    public class CatalogViewModel : ViewModelBase, ICatalogViewModel
    {
        private ICatalogDataProvider _dataProvider;
        private CatalogItem _selectedItem;
        private double _quantity;
        private IEventAggregator _eventAggregator;
        private Dictionary<Guid, string> _removedItems;

        public CatalogViewModel(ICatalogDataProvider _dataProvider,
            IEventAggregator eventAggregator)
        {
            Items = new ObservableCollection<CatalogItem>();
            _removedItems = new Dictionary<Guid, string>();
            _selectedItem = Items?.FirstOrDefault();
            this._dataProvider = _dataProvider;
            _eventAggregator = eventAggregator;
            _eventAggregator.GetEvent<ProductRemovedFromCartEvent>().Subscribe(OnItemRemoved);
            _eventAggregator.GetEvent<ClearCartEvent>().Subscribe(OnCartCleared);
            _eventAggregator.GetEvent<ClearCartAndCatalogEvent>().Subscribe(OnClearCatalog);
            AddItemToCart = new DelegateCommand(OnAddExecute, OnAddCanExecute);
            TextChanged = new DelegateCommand(OnTextChanged);
        }

        private void OnClearCatalog()
        {
            Items.Clear();
            _removedItems.Clear();
        }

        public ICommand AddItemToCart { get; private set; }
        public ICommand TextChanged { get; private set; }
        public ObservableCollection<CatalogItem> Items { get; private set; }

        public async Task Load()
        {
            Items.Clear();
            var catalogItems = await _dataProvider.GetAllCatalogItems();
            foreach (var item in catalogItems)
            {
                Items.Add(item);
            }
            InvalidateCommands();
        }

        public async Task UpdateDB()
        {
            await _dataProvider.UpdateDataBase();
        }

        public double Quantity
        {
            get { return _quantity; }
            set
            {
                _quantity = value;
                OnPropertyChanged();
                InvalidateCommands();
            }
        }

        public CatalogItem SelectedItem
        {
            get { return _selectedItem; }
            set
            {
                _selectedItem = value;
                _quantity = 0;
                OnPropertyChanged(nameof(Quantity));
                OnPropertyChanged();
                InvalidateCommands();
            }
        }

        private void InvalidateCommands()
        {
            ((DelegateCommand)AddItemToCart).RaiseCanExecuteChanged();
        }

        private bool OnAddCanExecute(object arg)
        {
            return Items != null && Items.Count != 0 && SelectedItem != null
                && _dataProvider.IsValidQuantity(_selectedItem, _quantity);
        }

        private void OnAddExecute(object obj)
        {
            _selectedItem.Quantity = _quantity;
            _removedItems.Add(_selectedItem.Id, _selectedItem.Name);
            _eventAggregator.GetEvent<ProductAddedToCartEvent>().Publish(_selectedItem);
            Items.Remove(_selectedItem);
        }

        private void OnCartCleared(List<CartItem> cart)
        {
            _removedItems.Clear();
            var result = (from c in cart
                          select new CatalogItem
                          {
                              Id = c.Id,
                              ByWeight = c.ByWeight,
                              Name = c.Name
                          }).ToList();
            foreach (var item in result)
            {
                Items.Add(item);
            }

        }

        private void OnItemRemoved(CartItem cartItem)
        {
            _removedItems.Remove(cartItem.Id);
            CatalogItem item = new CatalogItem() { Id = cartItem.Id, Name = cartItem.Name, ByWeight = cartItem.ByWeight };
            Items.Add(item);
        }

        private void OnTextChanged(object obj)
        {
            InvalidateCommands();
        }
    }
}
