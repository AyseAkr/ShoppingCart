using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ShoppingCartFinalAPI.Models
{
    public class Order
    {
        public int Id { get; set; }
        public string total { get; set; }
        //public int ItemId { get; set; }
        public int[] ItemId { get; set; }
    }
}