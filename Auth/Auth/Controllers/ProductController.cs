using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using Auth.Models;

namespace Auth.Controllers
{
    
    public class ProductController : Controller
    {
        // GET: Product
        private AuthorizeDemoEntities db = new AuthorizeDemoEntities();

        [Authorize(Roles = "Admin,Customer")]
        public ActionResult List()
        {
            return View(db.ProductDetails.ToList());
        }

        [Authorize(Roles = "Admin")]
        public ActionResult Create()
        {
            return View();
        }
        
        [Authorize(Roles = "Admin")]
        [HttpPost]
        public ActionResult Create(ProductDetail productDetail)
        {
            if(ModelState.IsValid)
            {
                db.ProductDetails.Add(productDetail);
                db.SaveChanges();
                return RedirectToAction("List");
            }
            return View(productDetail);
        }

        public ActionResult Edit(int id)
        {
            ProductDetail product = db.ProductDetails.Find(id);
            return View(product);
        }

        [HttpPost]
        public ActionResult Edit(ProductDetail productDetail)
        {
            if (ModelState.IsValid)
            {
                db.Entry(productDetail).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("List");
            }
            return View(productDetail);
            
        }

        public ActionResult Delete(int id)
        {
            ProductDetail product = db.ProductDetails.Find(id);
            db.ProductDetails.Remove(product);
            db.SaveChanges();
            return RedirectToAction("List");
        }


    }
}