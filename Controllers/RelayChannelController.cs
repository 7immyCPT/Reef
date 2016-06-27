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
    public class RelayChannelController : Controller
    {
        private ReefKeeperDBContext db = new ReefKeeperDBContext();

        // GET: RelayChannel
        public ActionResult Index()
        {
            var relayChannel = db.RelayChannel.Include(r => r.Channel).Include(r => r.Relay);
            return View(relayChannel.ToList());
        }

        // GET: RelayChannel/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            RelayChannelModels relayChannelModels = db.RelayChannel.Find(id);
            if (relayChannelModels == null)
            {
                return HttpNotFound();
            }
            return View(relayChannelModels);
        }

        // GET: RelayChannel/Create
        public ActionResult Create()
        {
            ViewBag.ChannelId = new SelectList(db.Channel, "ChannelId", "Description");
            ViewBag.RelayId = new SelectList(db.Relay, "RelayId", "Description");
            return View();
        }

        // POST: RelayChannel/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "RelayChannelId,RelayId,ChannelId,ClientId")] RelayChannelModels relayChannelModels)
        {
            if (ModelState.IsValid)
            {
                db.RelayChannel.Add(relayChannelModels);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.ChannelId = new SelectList(db.Channel, "ChannelId", "Description", relayChannelModels.ChannelId);
            ViewBag.RelayId = new SelectList(db.Relay, "RelayId", "Description", relayChannelModels.RelayId);
            return View(relayChannelModels);
        }

        // GET: RelayChannel/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            RelayChannelModels relayChannelModels = db.RelayChannel.Find(id);
            if (relayChannelModels == null)
            {
                return HttpNotFound();
            }
            ViewBag.ChannelId = new SelectList(db.Channel, "ChannelId", "Description", relayChannelModels.ChannelId);
            ViewBag.RelayId = new SelectList(db.Relay, "RelayId", "Description", relayChannelModels.RelayId);
            return View(relayChannelModels);
        }

        // POST: RelayChannel/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "RelayChannelId,RelayId,ChannelId,ClientId")] RelayChannelModels relayChannelModels)
        {
            if (ModelState.IsValid)
            {
                db.Entry(relayChannelModels).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.ChannelId = new SelectList(db.Channel, "ChannelId", "Description", relayChannelModels.ChannelId);
            ViewBag.RelayId = new SelectList(db.Relay, "RelayId", "Description", relayChannelModels.RelayId);
            return View(relayChannelModels);
        }

        // GET: RelayChannel/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            RelayChannelModels relayChannelModels = db.RelayChannel.Find(id);
            if (relayChannelModels == null)
            {
                return HttpNotFound();
            }
            return View(relayChannelModels);
        }

        // POST: RelayChannel/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            RelayChannelModels relayChannelModels = db.RelayChannel.Find(id);
            db.RelayChannel.Remove(relayChannelModels);
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
