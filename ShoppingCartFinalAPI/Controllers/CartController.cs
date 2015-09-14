using ShoppingCartFinalAPI.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web;
using System.Web.Http;

namespace ShoppingCartFinalAPI.Controllers
{
    public class CartController : ApiController
    {
        Connection c = new Connection();


    //    [HttpGet]

     //   public int cartcontrol()
     //   {
           // int s = c.countCart();
           // return s;
     //   }
        public double Get()
        {
            double cartitemscount = 0;
            var Sessions = HttpContext.Current.Session;
            if (Sessions["ShoppingCartItems"] != null)
            {
                List<ProductModel> product = Sessions["ShoppingCartItems"] as List<ProductModel>;

                foreach (var ProductModel in product)
                {
                    cartitemscount += ProductModel.price;
                }

            }
            return cartitemscount;
        }
        public double Get(int productID)
        {
            double cartitemscount = 0;
            var Session = HttpContext.Current.Session;
            List<ProductModel> product = new List<ProductModel>();
            if (Session["ShoppingCartItems"] != null)
            {
                product = Session["ShoppingCartItems"] as List<ProductModel>;
                ProductModel selected = product.Find(p => p.price == productID);
                if (selected != null)
                {
                    selected.price++;
                    int index = product.FindIndex(p => p.Id == productID);
                    product[index] = selected;
                }
                else
                {
                    selected = new ProductModel() { Id = productID, price = 1 };
                    product.Add(selected);
                }
                Session["ShoppingCartItems"] = product;
            }
            else
            {
                ProductModel selected = new ProductModel() { Id = productID, price = 1 };
                product.Add(selected);
                Session["ShoppingCartItems"] = product;
            }
            foreach (var productInShoppingCart in product)
            {
                cartitemscount += productInShoppingCart.price;
            }
            return cartitemscount;

        }
    }


}