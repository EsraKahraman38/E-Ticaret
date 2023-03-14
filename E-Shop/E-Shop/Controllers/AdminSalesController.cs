using DataAccessLayer.Context;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using PagedList;
using PagedList.Mvc;

namespace E_Shop.Controllers
{
    [Authorize(Roles = "Admin")]  //Bu sayfaya admin girişi yapan erişim sağlasın
    public class AdminSalesController : Controller     //Burda satışların tamamına listeleme yapıyoruz.
    {
        DataContext db = new DataContext();
        // GET: AdminSales
        public ActionResult Index(int sayfa)
        {
            return View(db.Sales.ToList().ToPagedList(sayfa,5));
        }
    }
}