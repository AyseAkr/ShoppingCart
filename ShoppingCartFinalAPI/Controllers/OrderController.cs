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
    public class OrderController : ApiController
    {
        Connection c = new Connection();
       
        [HttpGet]
        public void  OrderDetail([FromUri]int[] ItemId,[FromUri]string total)
        {
           c.OrderData(ItemId,total); 
        }
        [HttpGet]
        public int orderConn()
        {
           return c.OrderPage();
        }

    }
}
