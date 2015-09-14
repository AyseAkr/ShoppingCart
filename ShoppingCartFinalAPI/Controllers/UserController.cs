
using ShoppingCartFinalAPI.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;

namespace ShoppingCartFinalAPI.Controllers
{
    public class UserController : Controller
    {
        Connection c = new Connection();

        //public ActionResult Index()
        //{
        //  //  return View();
        //}
        //[HttpGet]
        //public ActionResult LogIn()
        //{
        //    //return View();
        //} 
        [HttpPost]
        public ActionResult Login()
        {

            return View();
        }
        [HttpPost]
        public ActionResult Login(MemberUserObject user)
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
            if(Request.IsAjaxRequest())
            {
                return Json(message, JsonRequestBehavior.AllowGet);
            }
            else
            {
                return RedirectToAction("Index","Home");
            }

        }

        
    }


}