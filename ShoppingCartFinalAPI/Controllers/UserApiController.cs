using ShoppingCartFinalAPI.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace ShoppingCartFinalAPI.Controllers
{
    public class UserApiController : ApiController
    {
        Connection c = new Connection();

        [HttpPost]
        public String Login(MemberUserObject user)
        {
            String message = "";

            if (ModelState.IsValid)
            {
                if (c.IsUserExist(user) > 0)
                {
                    message = "success";
                
                }
                else
                {

                    message = "user name or password incorrect";

                }

            }
            else
            {
                message = "All field require";
            }
            return message;
        }
       


    }
}
