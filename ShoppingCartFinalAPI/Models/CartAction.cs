using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ShoppingCartFinalAPI.Models
{
    public class CartAction
    {
        public int Id { get; set; }
        public ProductModel ProductId { get; set; }
    }
}