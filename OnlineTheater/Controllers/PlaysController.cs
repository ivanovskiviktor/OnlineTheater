using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using OnlineTheater.Models;

namespace OnlineTheater.Controllers
{
    public class PlaysController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        // GET: Plays
        public ActionResult Index()
        {
            return View(db.Plays.ToList());
        }

        // GET: Plays/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Play play = db.Plays.Find(id);
            if (play == null)
            {
                return HttpNotFound();
            }
            return View(play);
        }

        // GET: Plays/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Plays/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "PlayId,PlayName,Director,Price,Publisher,Language")] Play play)
        {
            if (ModelState.IsValid)
            {
                db.Plays.Add(play);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(play);
        }

        // GET: Plays/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Play play = db.Plays.Find(id);
            if (play == null)
            {
                return HttpNotFound();
            }
            return View(play);
        }

        // POST: Plays/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "PlayId,PlayName,Director,Price,Publisher,Language")] Play play)
        {
            if (ModelState.IsValid)
            {
                db.Entry(play).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(play);
        }

        // GET: Plays/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Play play = db.Plays.Find(id);
            if (play == null)
            {
                return HttpNotFound();
            }
            return View(play);
        }

        // POST: Plays/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Play play = db.Plays.Find(id);
            db.Plays.Remove(play);
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
