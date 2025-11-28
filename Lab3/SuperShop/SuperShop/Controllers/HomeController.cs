using SuperShop.EF;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace SuperShop.Controllers
{
    public class HomeController : Controller
    {
        ShopManagementEntities db = new ShopManagementEntities();
        public ActionResult Index()
        {
            var product = db.Products.ToList();
            return View(product);
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
        [HttpGet]
        public ActionResult ProductRegistration()
        {
            var cat = db.Categories.ToList();
            return View(cat);
        }

        [HttpPost]
        public ActionResult ProductRegistration(Product product)
        {
            if (ModelState.IsValid)
            {
                db.Products.Add(product);
                db.SaveChanges();
                TempData["Msg"] = "Product Added";
                return RedirectToAction("Index");
            }
           

            var cat = db.Categories.ToList();
            return View(cat);
        }


        public ActionResult Details(int id)
        {
            var product = db.Products.Find(id);
            return View(product);
        }
    }
}