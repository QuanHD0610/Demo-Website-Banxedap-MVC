using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using BANXEDAP.Models;

namespace BANXEDAP.Controllers
{
    public class HomeController : Controller
    {
        // GET: Home
        public ActionResult Index()
        {
            mydataEntities db = new mydataEntities();
            List<Product> products = db.Products.ToList();
            return View(products);
        }
        public ActionResult Sigin()
        {
            return View();
        }
        public ActionResult SignUp()
        {
            return View();  
        }
    }
}