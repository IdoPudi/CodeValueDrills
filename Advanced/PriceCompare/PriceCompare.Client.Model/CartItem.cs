using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace PriceCompare.Client.Model
{
    public class CartItem : BaseModel
    {
        private double _quantity;

        public Guid Id { get; set; }
        public string Name { get; set; }
        public bool ByWeight { get; set; }
        public double ChainOneItemPrice { get; set; }
        public double ChainOneTotalPrice => ChainOneItemPrice * Quantity;
        public double ChainTwoItemPrice { get; set; }
        public double ChainTwoTotalPrice => ChainTwoItemPrice * Quantity;
        public double ChainThreeItemPrice { get; set; }
        public double ChainThreeTotalPrice => ChainThreeItemPrice * Quantity;
        public string ByWeightInString { get; set; }

        public double Quantity
        {
            get { return _quantity; }
            set
            {
                _quantity = value;
                OnPropertyChanged();
                if (IsValidQuantity(ByWeight, _quantity))
                {
                    OnPropertyChanged(nameof(ChainOneTotalPrice));
                    OnPropertyChanged(nameof(ChainTwoTotalPrice));
                    OnPropertyChanged(nameof(ChainThreeTotalPrice));
                }

            }
        }

        public bool IsValidQuantity(bool isByWeight, double Quantity)
        {
            if (Quantity <= 0)
            {
                return false;
            }
            if (isByWeight == false)
            {
                if (Quantity == Math.Truncate(Quantity))
                {
                    return true;
                }
                return false;
            }
            return true;
        }
    }
}
