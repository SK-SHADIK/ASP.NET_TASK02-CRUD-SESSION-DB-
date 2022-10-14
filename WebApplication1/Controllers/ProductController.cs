using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WebApplication1.DBS;

namespace WebApplication1.Controllers
{
    public class ProductController : Controller
    {
        public object Products { get; private set; }

        // GET: Product
        [HttpGet]
        public ActionResult Product()
        {
            var db = new ProductEntities1();
            var products = db.Products.ToList();
            return View(products);
            
        }
        [HttpGet]
        public ActionResult CreateProducts()
        {
            return View();
        }
        [HttpPost]
        public ActionResult CreateProducts(Product product)
        {
            var db = new ProductEntities1();
            db.Products.Add(product);
            db.SaveChanges();
            return RedirectToAction("Product");
        }
        [HttpGet]
        public ActionResult EditProducts(int id)
        {
            var db = new ProductEntities1();
            var product = (from p in db.Products
                        where p.Id == id
                        select p).SingleOrDefault();
            return View(product);
        }
        [HttpPost]
        public ActionResult EditProducts(Product product)
        {
            var db = new ProductEntities1();
            var ext = (from p in db.Products
                       where p.Id == product.Id
                       select p).SingleOrDefault();

            ext.Name = product.Name;
            ext.Price = product.Price;
            ext.Qty = product.Qty;
            db.SaveChanges();
            return RedirectToAction("Product");
        }
        public ActionResult DeleteProducts(Product product)
        {
            var db = new ProductEntities1();
            var ext = (from p in db.Products
                       where p.Id == product.Id
                       select p).SingleOrDefault();

            db.Products.Remove(ext);
            db.SaveChanges();


            return RedirectToAction("Product");
        }
        [HttpGet]
        public ActionResult Cart()
        {
            return View();
        }
    }
}