using BusinessLayer.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace E_Shop.Controllers
{
    public class CategoryController : Controller
    {
        CategoryRepository categorRepository = new CategoryRepository();
        // GET: Category
        public ActionResult CategoryList()
        {
            return PartialView(categorRepository.List());
        }

        public ActionResult Details(int id)
        {
            var cat = categorRepository.CategoryDetails(id);
            return View(cat);
        }
    }
}