﻿using ShoppingCartFinalAPI.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace ShoppingCartFinalAPI.Controllers
{
   
    public class OrderPageController : ApiController
    {
        Connection c = new Connection();
        [HttpGet]
        public List<Order> orderpage()
        {
            return c.OrderPage();
        }
    }
}
