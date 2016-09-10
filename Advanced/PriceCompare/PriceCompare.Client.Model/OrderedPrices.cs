using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PriceCompare.Client.Model
{
    public class OrderedPrices : BaseModel
    {
        public string Name { get; set; }
        public double Price { get; set; }
    }
}
