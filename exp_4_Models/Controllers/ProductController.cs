using exp_4_Models.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace exp_4_Models.Controllers
{
    public class ProductController : Controller
    {
        private readonly NorthwindDbContext db;

        public ProductController()
        {
            db = new NorthwindDbContext();
        }

        public ActionResult List()
        {
            
            var products = db.Products.ToList();
            return View(products);
        }

        public ActionResult Add()
        {
            var product = new Product();
            return View(product);
        }

        [HttpPost]
        public ActionResult Add(Product model)
        {
            //TODO 
            db.Products.Add(model);
            return RedirectToAction("List");
            db.SaveChanges();
        }

        //public ActionResult Edit()
        //{
        //    return View();
        //}

        //[HttpPost]
        //public ActionResult Edit()
        //{
        //    return View();
        //}

        //public ActionResult Delete()
        //{
        //    return View();
        //}

    }
}