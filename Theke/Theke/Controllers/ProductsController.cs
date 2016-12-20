using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using Theke.Models;

namespace Theke.Controllers
{
    public class ProductsController : Controller
    {
        private thekeEntities db = new thekeEntities();

        // GET: Products
        public ActionResult Index()
        {
            var product = db.Product.Include(p => p.AspNetUsers).Include(p => p.AspNetUsers1).Include(p => p.AgeRating).Include(p => p.Category).Include(p => p.NutriantContent).Include(p => p.Producer).Include(p => p.ProductUnit);
            return View(product.ToList());
        }

        // GET: Products/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Product product = db.Product.Find(id);
            if (product == null)
            {
                return HttpNotFound();
            }
            return View(product);
        }

        // GET: Products/Create
        public ActionResult Create()
        {
            ViewBag.CreatedByID = new SelectList(db.AspNetUsers, "Id", "Email");
            ViewBag.ModifiedByID = new SelectList(db.AspNetUsers, "Id", "Email");
            ViewBag.AgeRatingID = new SelectList(db.AgeRating, "AgeRatingID", "AgeRatingID");
            ViewBag.CategorieID = new SelectList(db.Category, "CategoryID", "Name");
            ViewBag.NutriantContentID = new SelectList(db.NutriantContent, "NutrinantContentID", "NutrinantContentID");
            ViewBag.ProducerID = new SelectList(db.Producer, "ProducerID", "Name");
            ViewBag.ProductUnitID = new SelectList(db.ProductUnit, "ProductUnitID", "Name");
            return View();
        }

        // POST: Products/Create
        // Aktivieren Sie zum Schutz vor übermäßigem Senden von Angriffen die spezifischen Eigenschaften, mit denen eine Bindung erfolgen soll. Weitere Informationen 
        // finden Sie unter http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "ProductID,IsActive,Name,Note,AgeRatingID,ProductUnitID,ProducerID,AlcoholAmount,NutriantContentID,EanNumber,Deposit,ItemAmount,CategorieID,MinPrice,MaxPricce,AveragePurchasePrice,CreatedByID,ModifiedByID,CreatedDate,ModfiedDate")] Product product)
        {
            if (ModelState.IsValid)
            {
                db.Product.Add(product);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.CreatedByID = new SelectList(db.AspNetUsers, "Id", "Email", product.CreatedByID);
            ViewBag.ModifiedByID = new SelectList(db.AspNetUsers, "Id", "Email", product.ModifiedByID);
            ViewBag.AgeRatingID = new SelectList(db.AgeRating, "AgeRatingID", "AgeRatingID", product.AgeRatingID);
            ViewBag.CategorieID = new SelectList(db.Category, "CategoryID", "Name", product.CategorieID);
            ViewBag.NutriantContentID = new SelectList(db.NutriantContent, "NutrinantContentID", "NutrinantContentID", product.NutriantContentID);
            ViewBag.ProducerID = new SelectList(db.Producer, "ProducerID", "Name", product.ProducerID);
            ViewBag.ProductUnitID = new SelectList(db.ProductUnit, "ProductUnitID", "Name", product.ProductUnitID);
            return View(product);
        }

        // GET: Products/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Product product = db.Product.Find(id);
            if (product == null)
            {
                return HttpNotFound();
            }
            ViewBag.CreatedByID = new SelectList(db.AspNetUsers, "Id", "Email", product.CreatedByID);
            ViewBag.ModifiedByID = new SelectList(db.AspNetUsers, "Id", "Email", product.ModifiedByID);
            ViewBag.AgeRatingID = new SelectList(db.AgeRating, "AgeRatingID", "AgeRatingID", product.AgeRatingID);
            ViewBag.CategorieID = new SelectList(db.Category, "CategoryID", "Name", product.CategorieID);
            ViewBag.NutriantContentID = new SelectList(db.NutriantContent, "NutrinantContentID", "NutrinantContentID", product.NutriantContentID);
            ViewBag.ProducerID = new SelectList(db.Producer, "ProducerID", "Name", product.ProducerID);
            ViewBag.ProductUnitID = new SelectList(db.ProductUnit, "ProductUnitID", "Name", product.ProductUnitID);
            return View(product);
        }

        // POST: Products/Edit/5
        // Aktivieren Sie zum Schutz vor übermäßigem Senden von Angriffen die spezifischen Eigenschaften, mit denen eine Bindung erfolgen soll. Weitere Informationen 
        // finden Sie unter http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "ProductID,IsActive,Name,Note,AgeRatingID,ProductUnitID,ProducerID,AlcoholAmount,NutriantContentID,EanNumber,Deposit,ItemAmount,CategorieID,MinPrice,MaxPricce,AveragePurchasePrice,CreatedByID,ModifiedByID,CreatedDate,ModfiedDate")] Product product)
        {
            if (ModelState.IsValid)
            {
                db.Entry(product).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.CreatedByID = new SelectList(db.AspNetUsers, "Id", "Email", product.CreatedByID);
            ViewBag.ModifiedByID = new SelectList(db.AspNetUsers, "Id", "Email", product.ModifiedByID);
            ViewBag.AgeRatingID = new SelectList(db.AgeRating, "AgeRatingID", "AgeRatingID", product.AgeRatingID);
            ViewBag.CategorieID = new SelectList(db.Category, "CategoryID", "Name", product.CategorieID);
            ViewBag.NutriantContentID = new SelectList(db.NutriantContent, "NutrinantContentID", "NutrinantContentID", product.NutriantContentID);
            ViewBag.ProducerID = new SelectList(db.Producer, "ProducerID", "Name", product.ProducerID);
            ViewBag.ProductUnitID = new SelectList(db.ProductUnit, "ProductUnitID", "Name", product.ProductUnitID);
            return View(product);
        }

        // GET: Products/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Product product = db.Product.Find(id);
            if (product == null)
            {
                return HttpNotFound();
            }
            return View(product);
        }

        // POST: Products/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Product product = db.Product.Find(id);
            db.Product.Remove(product);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}
