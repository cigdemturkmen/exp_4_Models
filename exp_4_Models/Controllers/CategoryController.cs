using exp_4_Models.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace exp_4_Models.Controllers
{
    public class CategoryController : Controller
    {
        // readonly: proje çalıştığında değeri birkez set edilebilir, sonrasında değer değiştirilemez. yalnızca bir kez instance alınmasını sağlar.

        private readonly NorthwindDbContext _dbContext;  // dbContext field'ı tanımlayıp constructor'da setledik.

        public CategoryController()
        {
            _dbContext = new NorthwindDbContext();
        }
        public ActionResult List()
        {
            NorthwindDbContext db = new NorthwindDbContext();
            var categories = db.Categories.ToList();
            return View(categories);
        }

        public ActionResult Add()
        {
            var category = new Category();
            return View(category);
        }

        [HttpPost]
        public ActionResult Add(Category model)
        {
            if (!ModelState.IsValid) //server-side validation
            {
                // kullanıcı modele attribute olarak eklenen validationı atlamış olabilir.
                return View(model);
            }

            // iş kuralı
            if (!_dbContext.Categories.Any(x => x.CategoryName.ToLower() == model.CategoryName.ToLower()))//aynı ktgri ismi yoksa ekle
            {
                _dbContext.Categories.Add(model);

                var sonuc = _dbContext.SaveChanges();

                if (sonuc > 0)
                {
                    return RedirectToAction("List");
                }
            }
            else
            {
                ViewBag.Mesaj = "Aynı kategori adında başka bir kayıt bulunmaktadır. Lütfen başka bir isimle yeniden deneyiniz.";
                return View(model); // return View("Add", model);
            }
            
                return null;      
        }

        public ActionResult Edit(int id)
        {
            var category = _dbContext.Categories.FirstOrDefault(x => x.CategoryID == id);
            return View(category);
        }

        [HttpPost]
        public ActionResult Edit(Category model)
        {
            
            var category = _dbContext.Categories.FirstOrDefault(x => x.CategoryID == model.CategoryID);

            if (category != null) //category null geliyor
            {
                category.CategoryName = model.CategoryName;
                category.Description = model.Description;
            }

            _dbContext.SaveChanges();

            return RedirectToAction("List");  
        }

        public ActionResult Delete(int id)
        {
            var category = _dbContext.Categories.FirstOrDefault(x => x.CategoryID == id);

            if (category != null)
            {
                _dbContext.Categories.Remove(category);

                int sonuc = _dbContext.SaveChanges();

                    if (sonuc >0)
                {
                    TempData["Mesaj"] = "Silme işlemi gerçekleşti!";

                    return RedirectToAction("List");
                }
            }

            return null;
        }
    }
}