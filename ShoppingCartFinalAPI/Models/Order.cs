using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ShoppingCartFinalAPI.Models
{
    public class Order
    {

        public double total { get; set; }
        public double price { get; set; }
        public string name { get; set; }
        public string detail { get; set; }
        public string currency { get; set; }
    }
}