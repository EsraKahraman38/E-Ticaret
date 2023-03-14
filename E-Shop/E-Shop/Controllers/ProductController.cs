using BusinessLayer.Concrete;
using DataAccessLayer.Context;
using EntityLayer.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace E_Shop.Controllers
{
    public class ProductController : Controller
    {
        ProductRepository productRepository = new ProductRepository();
        DataContext db = new DataContext();
        // GET: Product
        public PartialViewResult PopulerProduct()
        {
            var product = productRepository.GetPopulerProduct();
            ViewBag.populer = product;
            return PartialView();
        }
        [Route("product/productdetails/{id}/{name}")]   //Seo kısmı
        public ActionResult ProductDetails(int id)
        {
            var details = productRepository.GetById(id);
            var yorum = db.Comments.Where(x => x.ProductID == id).ToList();  //Yorumları ürünlerin altına listeler
            ViewBag.yorum = yorum;
            return View(details);
        }
        [HttpPost]
        public ActionResult Comment(Comment data)
        {
            if (User.Identity.IsAuthenticated)
            {
                db.Comments.Add(data);
                db.SaveChanges();     
                return RedirectToAction("Index", "Home");
            }
            return View();
        }
        public ActionResult ProductDetails2(int id)
        {
            var details = productRepository.GetById(id);
            var yorum = db.Comments.Where(x => x.ProductID == id).ToList();  //Yorumları ürünlerin altına listeler
            ViewBag.yorum = yorum;
            return View(details);
        }
        
    }
}