using DataAccessLayer.Context;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace E_Shop.Controllers
{
    [Authorize(Roles ="Admin")]
    public class AdminIstatisticController : Controller
    {
        DataContext db = new DataContext();
        // GET: AdminIstatistic
        public ActionResult Index()
        {
            var satis = db.Sales.Count();
            ViewBag.satis = satis;

            var urun = db.Sales.Count();
            ViewBag.urun = urun;

            var kategori = db.Sales.Count();
            ViewBag.kategori = kategori;

            var sepet = db.Sales.Count();
            ViewBag.sepet = sepet;

            var user = db.Sales.Count();
            ViewBag.user = user;

            return View();
        }

    }
}