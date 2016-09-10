using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace PriceCompare.Client.Model
{
    public class CatalogItem : BaseModel
    {
        private double _quantity;

        public Guid Id { get; set; }
        public string Name { get; set; }
        public bool ByWeight { get; set; }

        public double Quantity
        {
            get { return _quantity; }
            set
            {
                _quantity = value;
                OnPropertyChanged();
            }
        }
    }
}
