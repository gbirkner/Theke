using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using Theke.Models;
using Theke.Models.ViewModels;

namespace Theke.Controllers
{
    public class BarTablesController : Controller
    {
        private thekeEntities db = new thekeEntities();

        // GET: BarTables
        public ActionResult Index()
        {

            List<BarTableViewModel> bartableviewmodels = new List<BarTableViewModel>();
            //TableOrderViewModel list = new TableOrderViewModel(db.BarTable.ToList(), db.BarOrders.ToList());
            List<BarTable> bartables = db.BarTable.ToList();
            foreach (BarTable bartable in bartables)
            {
                List<BarOrder> barorders = bartable.BarOrders.ToList();
                BarTableViewModel name = new BarTableViewModel();
                name.SeatAmount = bartable.SeatAmount;
                name.TableName = bartable.TableName;
                name.BarTableID = bartable.BarTableID;
                name.hasOpenPaymentStatus = 0;
                foreach (BarOrder barorder in barorders)
                {
                   if (barorder.PaymentStatus == 1)
                    {
                        name.hasOpenPaymentStatus = barorder.PaymentStatus;
                    }
                    
                }
                bartableviewmodels.Add(name);
            }
            
            return View(bartableviewmodels);
        }

        // GET: BarTables/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            BarTable barTable = db.BarTable.Find(id);
            if (barTable == null)
            {
                return HttpNotFound();
            }
            return View(barTable);
        }

        // GET: BarTables/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: BarTables/Create
        // Aktivieren Sie zum Schutz vor übermäßigem Senden von Angriffen die spezifischen Eigenschaften, mit denen eine Bindung erfolgen soll. Weitere Informationen 
        // finden Sie unter http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "BarTableID,PositionX,PositionY,Width,Height,SeatAmount,TableName")] BarTable barTable)
        {
            if (ModelState.IsValid)
            {
                db.BarTable.Add(barTable);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(barTable);
        }

        // GET: BarTables/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            BarTable barTable = db.BarTable.Find(id);
            if (barTable == null)
            {
                return HttpNotFound();
            }
            return View(barTable);
        }

        // POST: BarTables/Edit/5
        // Aktivieren Sie zum Schutz vor übermäßigem Senden von Angriffen die spezifischen Eigenschaften, mit denen eine Bindung erfolgen soll. Weitere Informationen 
        // finden Sie unter http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "BarTableID,PositionX,PositionY,Width,Height,SeatAmount,TableName")] BarTable barTable)
        {
            if (ModelState.IsValid)
            {
                db.Entry(barTable).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(barTable);
        }

        // GET: BarTables/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            BarTable barTable = db.BarTable.Find(id);
            if (barTable == null)
            {
                return HttpNotFound();
            }
            return View(barTable);
        }

        // POST: BarTables/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            BarTable barTable = db.BarTable.Find(id);
            db.BarTable.Remove(barTable);
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
