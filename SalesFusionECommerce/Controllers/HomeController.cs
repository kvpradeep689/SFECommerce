using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.Mvc;

namespace SalesFusionECommerce.Controllers
{
    [Authorize]
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            ViewBag.Title = "SalesFusion E-Commerce Site";
            return View();
        }
    }
}
