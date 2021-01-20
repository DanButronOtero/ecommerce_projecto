using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Microsoft.AspNet.Identity;

namespace AccessoPaso1.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            String correo = User.Identity.GetUserName();
            if (Session["itemTotal"] == null)
                Session["itemTotal"] = 0;
            if (correo.Contains("compras@mymodels.com"))
            {
                
                    return RedirectToAction("Index", "Compras");
                
            }
            return View();
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }
    }
}