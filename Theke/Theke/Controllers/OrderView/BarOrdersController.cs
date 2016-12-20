using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using Theke.Models;

namespace Theke.Controllers.OrderView
{
    public class BarOrdersController : Controller
    {
        private thekeEntities db = new thekeEntities();

        // GET: BarOrders
        public ActionResult Index()
        {
            var barOrders = db.BarOrders.Include(b => b.Waiter);
            return View(barOrders.ToList());
        }

        // GET: BarOrders/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            BarOrder barOrder = db.BarOrders.Find(id);
            if (barOrder == null)
            {
                return HttpNotFound();
            }
            return View(barOrder);
        }

        // GET: BarOrders/Create
        public ActionResult Create()
        {
            ViewBag.WaiterID = new SelectList(db.Waiter, "WaiterID", "VName");
            return View();
        }

        // POST: BarOrders/Create
        // Aktivieren Sie zum Schutz vor übermäßigem Senden von Angriffen die spezifischen Eigenschaften, mit denen eine Bindung erfolgen soll. Weitere Informationen 
        // finden Sie unter http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "BarOrderID,PaymentStatus,BarOrderBarTableID,Datetime,OrderPositionID,WaiterID")] BarOrder barOrder)
        {
            if (ModelState.IsValid)
            {
                db.BarOrders.Add(barOrder);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.WaiterID = new SelectList(db.Waiter, "WaiterID", "VName", barOrder.WaiterID);
            return View(barOrder);
        }

        // GET: BarOrders/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            BarOrder barOrder = db.BarOrders.Find(id);
            if (barOrder == null)
            {
                return HttpNotFound();
            }
            ViewBag.WaiterID = new SelectList(db.Waiter, "WaiterID", "VName", barOrder.WaiterID);
            return View(barOrder);
        }

        // POST: BarOrders/Edit/5
        // Aktivieren Sie zum Schutz vor übermäßigem Senden von Angriffen die spezifischen Eigenschaften, mit denen eine Bindung erfolgen soll. Weitere Informationen 
        // finden Sie unter http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "BarOrderID,PaymentStatus,BarOrderBarTableID,Datetime,OrderPositionID,WaiterID")] BarOrder barOrder)
        {
            if (ModelState.IsValid)
            {
                db.Entry(barOrder).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.WaiterID = new SelectList(db.Waiter, "WaiterID", "VName", barOrder.WaiterID);
            return View(barOrder);
        }

        // GET: BarOrders/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            BarOrder barOrder = db.BarOrders.Find(id);
            if (barOrder == null)
            {
                return HttpNotFound();
            }
            return View(barOrder);
        }

        // POST: BarOrders/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            BarOrder barOrder = db.BarOrders.Find(id);
            db.BarOrders.Remove(barOrder);
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
