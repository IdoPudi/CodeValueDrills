using PriceCompare.Client.WPFApplication.DataProvider;
using PriceCompare.Client.WPFApplication.Events;
using Prism.Events;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PriceCompare.Client.Model;
using System.Collections.ObjectModel;
using System.Windows.Input;
using PriceCompare.Client.WPFApplication.Command;

namespace PriceCompare.Client.WPFApplication.ViewModel
{
    public interface ICartViewModel
    {
    }

    public class CartViewModel : ViewModelBase, ICartViewModel
    {
        private ICartDataProvider _dataProvider;
        private CartItem _selectedItem;
        private IEventAggregator _eventAggregator;
        private double _chainOneTotal;
        private double _chainTwoTotal;
        private double _chainThreeTotal;

        public CartViewModel(ICartDataProvider _dataProvider,
            IEventAggregator eventAggregator)
        {
            InitializeCollections();
            
            
            this._dataProvider = _dataProvider;
            _eventAggregator = eventAggregator;
            _eventAggregator.GetEvent<ProductAddedToCartEvent>().Subscribe(OnItemAdded);
            _eventAggregator.GetEvent<ClearCartAndCatalogEvent>().Subscribe(OnClearCart);
            RemoveItemFromCart = new DelegateCommand(OnRemoveExecute, OnRemoveCanExecute);
            ClearCart = new DelegateCommand(OnClearExecute, OnClearCanExecute);
        }

        private void OnClearCart()
        {
            CartItems.Clear();
            _chainOneTotal = 0;
            _chainTwoTotal = 0;
            _chainThreeTotal = 0;
            OnPropertyChanged(nameof(ChainOneTotal));
            OnPropertyChanged(nameof(ChainTwoTotal));
            OnPropertyChanged(nameof(ChainThreeTotal));
            ClearLowAndHighCollections();
        }

        private void InitializeCollections()
        {
            CartItems = new ObservableCollection<CartItem>();
            ChainOneHigh = new ObservableCollection<OrderedPrices>();
            ChainOneLow = new ObservableCollection<OrderedPrices>();
            ChainTwoHigh = new ObservableCollection<OrderedPrices>();
            ChainTwoLow = new ObservableCollection<OrderedPrices>();
            ChainThreeLow = new ObservableCollection<OrderedPrices>();
            ChainThreeHigh = new ObservableCollection<OrderedPrices>();
        }

        public ICommand RemoveItemFromCart { get; private set; }
        public ICommand ClearCart { get; private set; }
        public ObservableCollection<CartItem> CartItems { get; private set; }
        public ObservableCollection<OrderedPrices> ChainOneHigh { get; private set; }
        public ObservableCollection<OrderedPrices> ChainOneLow { get; private set; }
        public ObservableCollection<OrderedPrices> ChainTwoHigh { get; private set; }
        public ObservableCollection<OrderedPrices> ChainTwoLow { get; private set; }
        public ObservableCollection<OrderedPrices> ChainThreeHigh { get; private set; }
        public ObservableCollection<OrderedPrices> ChainThreeLow { get; private set; }

        public CartItem SelectedItem
        {
            get { return _selectedItem; }
            set
            {
                _selectedItem = value;
                OnPropertyChanged();
                InvalidateCommands();
            }
        }

        public double ChainOneTotal
        {
            get { return _chainOneTotal; }
            set
            {
                _chainOneTotal = value;
                OnPropertyChanged();
            }
        }

        public double ChainTwoTotal
        {
            get { return _chainTwoTotal; }
            set
            {
                _chainTwoTotal = value;
                OnPropertyChanged();
            }
        }

        public double ChainThreeTotal
        {
            get { return _chainThreeTotal; }
            set
            {
                _chainThreeTotal = value;
                //_chainThreeTotal = CartItems.Sum(s => s.ChainThreeTotalPrice);
                OnPropertyChanged();
            }
        }

        private async void OnItemAdded(CatalogItem catalogItem)
        {
            try
            {
                var cartItem = await _dataProvider.GetCartItemFromDataBase(catalogItem);
                CartItems.Add(cartItem);
                _chainOneTotal += cartItem.ChainOneTotalPrice;
                _chainTwoTotal += cartItem.ChainTwoTotalPrice;
                _chainThreeTotal += cartItem.ChainThreeTotalPrice;
                OnPropertyChanged(nameof(ChainOneTotal));
                OnPropertyChanged(nameof(ChainTwoTotal));
                OnPropertyChanged(nameof(ChainThreeTotal));
                if (CartItems.Count >= 6)
                {
                    UpdateLowAndHighPrices();
                }
                else
                {
                    ClearLowAndHighCollections();
                }
                InvalidateCommands();
            }
            catch (Exception ex)
            {
                throw ex;
            }
            
        }

        private void ClearLowAndHighCollections()
        {
            ChainOneHigh.Clear();
            ChainOneLow.Clear();
            ChainTwoHigh.Clear();
            ChainTwoLow.Clear();
            ChainThreeHigh.Clear();
            ChainThreeLow.Clear();
        }

        private void UpdateLowAndHighPrices()
        {
            ChainOneHigh.Clear();
            var resultOneHigh = _dataProvider.GetHighPricesInChainOne(CartItems.ToList());
            foreach (var item in resultOneHigh)
            {
                ChainOneHigh.Add(item);
            }
            ChainOneLow.Clear();
            var resultOneLow = _dataProvider.GetLowPricesInChainOne(CartItems.ToList());
            foreach (var item in resultOneLow)
            {
                ChainOneLow.Add(item);
            }
            ChainTwoHigh.Clear();
            var resultTwoHigh = _dataProvider.GetHighPricesInChainTwo(CartItems.ToList());
            foreach (var item in resultTwoHigh)
            {
                ChainTwoHigh.Add(item);
            }
            ChainTwoLow.Clear();
            var resultTwoLow = _dataProvider.GetLowPricesInChainTwo(CartItems.ToList());
            foreach (var item in resultTwoLow)
            {
                ChainTwoLow.Add(item);
            }
            ChainThreeHigh.Clear();
            var resultThreeHigh = _dataProvider.GetHighPricesInChainThree(CartItems.ToList());
            foreach (var item in resultThreeHigh)
            {
                ChainThreeHigh.Add(item);
            }
            ChainThreeLow.Clear();
            var resultThreeLow = _dataProvider.GetLowPricesInChainThree(CartItems.ToList());
            foreach (var item in resultThreeLow)
            {
                ChainThreeLow.Add(item);
            }
        }

        private void InvalidateCommands()
        {
            ((DelegateCommand)RemoveItemFromCart).RaiseCanExecuteChanged();
            ((DelegateCommand)ClearCart).RaiseCanExecuteChanged();
        }

        private bool OnClearCanExecute(object arg)
        {
            return CartItems != null && CartItems.Count != 0;
        }

        private void OnClearExecute(object obj)
        {
            _chainOneTotal = 0;
            _chainTwoTotal = 0;
            _chainThreeTotal = 0;
            OnPropertyChanged(nameof(ChainOneTotal));
            OnPropertyChanged(nameof(ChainTwoTotal));
            OnPropertyChanged(nameof(ChainThreeTotal));
            _eventAggregator.GetEvent<ClearCartEvent>().Publish(CartItems.ToList());
            CartItems.Clear();
            ClearLowAndHighCollections();
        }

        private bool OnRemoveCanExecute(object arg)
        {
            return CartItems != null && CartItems.Count != 0 && SelectedItem != null;
        }

        private void OnRemoveExecute(object obj)
        {
            _chainOneTotal -= _selectedItem.ChainOneTotalPrice;
            _chainTwoTotal -= _selectedItem.ChainTwoTotalPrice;
            _chainThreeTotal -= _selectedItem.ChainThreeTotalPrice;
            OnPropertyChanged(nameof(ChainOneTotal));
            OnPropertyChanged(nameof(ChainTwoTotal));
            OnPropertyChanged(nameof(ChainThreeTotal));
            _eventAggregator.GetEvent<ProductRemovedFromCartEvent>().Publish(_selectedItem);
            CartItems.Remove(_selectedItem);
            if (CartItems.Count >= 6)
            {
                UpdateLowAndHighPrices();
            }
            else
            {
                ClearLowAndHighCollections();
            }
        }
    }
}
