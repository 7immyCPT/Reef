using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using Reef.DAL;
using Reef.Models;

namespace Reef.Controllers
{
    public class RelayController : Controller
    {
        private ReefKeeperDBContext db = new ReefKeeperDBContext();

        // GET: RelayModels
        public ActionResult Index()
        {
            return View(db.Relay.ToList());
        }

        // GET: RelayModels/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            RelayModels relayModels = db.Relay.Find(id);
            if (relayModels == null)
            {
                return HttpNotFound();
            }
            return View(relayModels);
        }

        // GET: RelayModels/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: RelayModels/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "RelayId,Description")] RelayModels relayModels)
        {
            if (ModelState.IsValid)
            {
                db.Relay.Add(relayModels);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(relayModels);
        }

        // GET: RelayModels/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            RelayModels relayModels = db.Relay.Find(id);
            if (relayModels == null)
            {
                return HttpNotFound();
            }
            return View(relayModels);
        }

        // POST: RelayModels/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "RelayId,Description")] RelayModels relayModels)
        {
            if (ModelState.IsValid)
            {
                db.Entry(relayModels).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(relayModels);
        }

        // GET: RelayModels/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            RelayModels relayModels = db.Relay.Find(id);
            if (relayModels == null)
            {
                return HttpNotFound();
            }
            return View(relayModels);
        }

        // POST: RelayModels/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            RelayModels relayModels = db.Relay.Find(id);
            db.Relay.Remove(relayModels);
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
