using DataAccessLayer.Context;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using PagedList;
using PagedList.Mvc;
using EntityLayer.Entities;

namespace E_Shop.Controllers
{
    public class SaleController : Controller
    {
        // GET: Sale
        DataContext db = new DataContext();
        public ActionResult Index(int sayfa = 1)
        {
            if (User.Identity.IsAuthenticated)
            {
                var kullaniciadi = User.Identity.Name;
                var kullanici = db.Users.FirstOrDefault(x => x.Email == kullaniciadi);  //Sisteme email ile autontice oluyoruz.
                var model = db.Sales.Where(x => x.UserID == kullanici.Id).ToList().ToPagedList(sayfa, 5);
                return View(model);
            }
            return HttpNotFound();
        }

        public ActionResult Buy(int id)
        {
            var model = db.Carts.FirstOrDefault(x => x.Id == id);
            return View(model);
        }

        [HttpPost]
        public ActionResult Buy2(int id)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    var model = db.Carts.FirstOrDefault(x => x.Id == id);
                    var satis = new Sale
                    {
                        UserID = model.UserID,
                        ProductID = model.ProductID,
                        Quantity = model.Quantity,
                        Image = model.Image,
                        Price = model.Price,
                        Date = DateTime.Now,
                    };
                    db.Carts.Remove(model);
                    db.Sales.Add(satis);
                    db.SaveChanges();
                    ViewBag.islem = "Satın alma işlemi başarılı bir şekilde gerçekleşmiştir..";
                }

            }
            catch (Exception)
            {
                ViewBag.islem = "Satın alma işlemi başarısız..";
            }
            return View("islem");
        }
        public ActionResult BuyAll(decimal? Tutar)
        {
            if (User.Identity.IsAuthenticated)
            {
                var kullaniciadi = User.Identity.Name;
                var kullanici = db.Users.FirstOrDefault(x => x.Email == kullaniciadi);
                var model = db.Carts.Where(x => x.UserID == kullanici.Id).ToList();
                var kid = db.Carts.FirstOrDefault(x => x.UserID == kullanici.Id);
                if (kid == null)
                {
                    ViewBag.tutar = "Sepetinizde ürün bulunmamaktadır.";
                }
                else if (kid != null)
                {
                    Tutar = db.Carts.Where(x => x.UserID == kid.UserID).Sum(x => x.Product.Price * x.Quantity);
                    ViewBag.Tutar = "Toplam Tutar = " + Tutar + "TL";
                }
                return View(model);
            }
            return HttpNotFound();
        }
        [HttpPost]
        public ActionResult BuyAll2()
        {
            var Username = User.Identity.Name;
            var kullanici = db.Users.FirstOrDefault(x => x.Email == Username);
            var model = db.Carts.Where(x => x.UserID == kullanici.Id).ToList();
            int row = 0; //satır adında sıfır değ atama
            foreach (var item in model)
            {
                var satis = new Sale
                {
                    UserID = model[row].UserID,
                    ProductID = model[row].ProductID,
                    Quantity = model[row].Quantity,
                    Price = model[row].Price,
                    Image = model[row].Image,
                    Date = DateTime.Now
                };
                db.Sales.Add(satis);
                db.SaveChanges();
                row++;
            }
            db.Carts.RemoveRange(model);
            db.SaveChanges();
            return RedirectToAction("Index", "Cart");
        }
    }
}