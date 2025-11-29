using Microsoft.Ajax.Utilities;
using SuperShopInventorySystem.Database;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace SuperShopInventorySystem.Controllers
{
    public class HomeController : Controller
    {
        SuperShopInventorySystemEntities db = new SuperShopInventorySystemEntities();

        [HttpGet]
        public ActionResult Registration()
        {
            var categories = db.Categories.ToList();
            ViewBag.Categories = categories;
            return View(new Product());
        }

        [HttpPost]
        public ActionResult Registration(Product product)
        {
            if (ModelState.IsValid && product != null)
            {
                db.Products.Add(product);
                db.SaveChanges();
            }
            TempData["Message"] = "Product Registered Successfully!";
            return RedirectToAction("List");
        }

        public ActionResult List()
        {
            var products = db.Products.ToList();
            return View(products);
        }

        public ActionResult Details(int id)
        {
            var product = db.Products.Find(id);
            return View(product);
        }

        public ActionResult Delete(int id)
        {
            var product = db.Products.Find(id);

            TempData["Message"] = "Deleted";

            return RedirectToAction("List");
        }


        public ActionResult Update(int id)
        {
            var product = db.Products.Find(id);
            var categories = db.Categories.ToList();
            ViewBag.Categories = categories;
            return View(product);

        }

        [HttpPost]
        public ActionResult Update(Product product)
        {
            if (ModelState.IsValid && product != null)
            {
                var prodToUpdate = db.Products.Find(product.ID);
                db.Entry(prodToUpdate).CurrentValues.SetValues(product);
                db.SaveChanges();
            }
            TempData["Message"] = "Product Updated Successfully!";
            return RedirectToAction("List");
        }
    }
}