using PriceCompare.Client.Model;
using Prism.Events;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PriceCompare.Client.WPFApplication.Events
{
    class ClearCartEvent : PubSubEvent<List<CartItem>>
    {
    }
}
