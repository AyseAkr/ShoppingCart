using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ShoppingCartFinalAPI.Models
{
    public class ProductModel
    {
        public int Id { get; set; }
        public string ProductName { get; set; }
        public string detail { get; set; }
        public double price { get; set; }
        public string currency { get; set; }

        public static implicit operator ProductModel(int v)
        {
            throw new NotImplementedException();
        }
    }
}