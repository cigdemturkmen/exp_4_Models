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
        private readonly NorthwindDbContext _dbContext;

        public ProductController()
        {
            _dbContext = new NorthwindDbContext();
        }

        public ActionResult List()
        {
            //instance almasak da geliyor liste?
            var products = _dbContext.Products.ToList();
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
            _dbContext.Products.Add(model);
            return RedirectToAction("List");
            _dbContext.SaveChanges();
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