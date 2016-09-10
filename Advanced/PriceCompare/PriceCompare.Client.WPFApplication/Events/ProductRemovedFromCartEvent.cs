using PriceCompare.Client.Model;
using Prism.Events;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PriceCompare.Client.WPFApplication.Events
{
    public class ProductRemovedFromCartEvent : PubSubEvent<CartItem>
    {
    }
}
