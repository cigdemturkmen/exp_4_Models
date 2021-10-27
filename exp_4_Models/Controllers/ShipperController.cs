using exp_4_Models.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace exp_4_Models.Controllers
{
    public class ShipperController : Controller
    {
        private readonly NorthwindDbContext db;

        public ShipperController()
        {
            db = new NorthwindDbContext();
        }


        public ActionResult List()
        {
            var shippers = db.Shippers.ToList();
            return View(shippers);
        }

        public ActionResult Add()
        {
            var newShipper = new Shipper();
            return View(newShipper);
        }

        [HttpPost]
        public ActionResult Add(Shipper model)
        {
            if (!ModelState.IsValid)
            {
                return View(model);
            }

            if (!db.Shippers.Any(x => x.ShipperID == model.ShipperID)) 
            {
                db.Shippers.Add(model);

                var sonuc = db.SaveChanges();

                if (sonuc > 0)
                {
                    return RedirectToAction("List");
                }
            }
            else
            {
                ViewBag.Mesaj = "Aynı kategori adında başka bir kayıt bulunmaktadır. Lütfen başka bir isimle yeniden deneyiniz.";
                return View(model);
            }
            return null;
        }

        public ActionResult Edit(int id)
        {
            var shipper = db.Shippers.FirstOrDefault(x => x.ShipperID == id);
            if (shipper != null)
            {
                return View(shipper);
            }
            else
            {
                //kullanıcıya mesaj gönderebilirsiniz
                TempData["Mesaj"]= "Bu Id'ye sahip bir gönderici bulunmamaktadır.";
                return RedirectToAction("List");
            }
        }

        [HttpPost]
        public ActionResult Edit(Shipper model)
        {
            var shipper = db.Shippers.FirstOrDefault(x => x.ShipperID == model.ShipperID);

            if (shipper != null) 
            {
                shipper.CompanyName = model.CompanyName;
                shipper.Phone = model.Phone;

                var sonuc = db.SaveChanges();

                if (sonuc > 0)
                {
                    return RedirectToAction("List");
                }
            }

            return null;
        }

        public ActionResult Delete(int id)
        {
            var shipper = db.Shippers.FirstOrDefault(x => x.ShipperID == id);

            if (shipper != null)
            {
                db.Shippers.Remove(shipper);

                int sonuc = db.SaveChanges();

                if (sonuc > 0)
                {
                    TempData["Mesaj"] = "Silme işlemi gerçekleşti!";

                    return RedirectToAction("List");
                }
            }

            return null;
        }
    }
}