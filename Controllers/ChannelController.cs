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
    public class ChannelController : Controller
    {
        private ReefKeeperDBContext db = new ReefKeeperDBContext();

        // GET: Channelontroller
        public ActionResult Index()
        {
            return View(db.Channel.ToList());
        }

        // GET: Channelontroller/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ChannelModels channelModels = db.Channel.Find(id);
            if (channelModels == null)
            {
                return HttpNotFound();
            }
            return View(channelModels);
        }

        // GET: Channelontroller/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Channelontroller/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "ChannelId,Description,Value,Default_Value")] ChannelModels channelModels)
        {
            if (ModelState.IsValid)
            {
                db.Channel.Add(channelModels);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(channelModels);
        }

        // GET: Channelontroller/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ChannelModels channelModels = db.Channel.Find(id);
            if (channelModels == null)
            {
                return HttpNotFound();
            }
            return View(channelModels);
        }

        // POST: Channelontroller/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "ChannelId,Description,Value,Default_Value")] ChannelModels channelModels)
        {
            if (ModelState.IsValid)
            {
                db.Entry(channelModels).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(channelModels);
        }

        // GET: Channelontroller/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ChannelModels channelModels = db.Channel.Find(id);
            if (channelModels == null)
            {
                return HttpNotFound();
            }
            return View(channelModels);
        }

        // POST: Channelontroller/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            ChannelModels channelModels = db.Channel.Find(id);
            db.Channel.Remove(channelModels);
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
