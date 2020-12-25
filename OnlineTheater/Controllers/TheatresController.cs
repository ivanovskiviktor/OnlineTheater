using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using Microsoft.AspNet.Identity;
using OnlineTheater.Models;

namespace OnlineTheater.Controllers
{
    public class TheatresController : Controller
    {

        private ApplicationDbContext db = new ApplicationDbContext();

        // GET: Theatres
        [Authorize(Roles = ("Admin, TheatreAgent, User"))]
        public ActionResult Index()
        {
            return View(db.Theatres.ToList());
        }

        // GET: Theatres/Details/5
        [Authorize(Roles = ("Admin, TheatreAgent, User"))]
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Theatre theatre = db.Theatres.Find(id);
            if (theatre == null)
            {
                return HttpNotFound();
            }
            return View(theatre);
        }

        // GET: Theatres/Create
        [Authorize(Roles = ("Admin, TheatreAgent"))]
        public ActionResult Create()
        {
            return View();
        }

        // POST: Theatres/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [Authorize(Roles = ("Admin, TheatreAgent"))]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "TheatreId,Name,Address")] Theatre theatre)
        {
            if (ModelState.IsValid)
            {
                db.Theatres.Add(theatre);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(theatre);
        }

        // GET: Theatres/Edit/5
        [Authorize(Roles = ("Admin, TheatresAgent"))]
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Theatre theatre = db.Theatres.Find(id);
            if (theatre == null)
            {
                return HttpNotFound();
            }
            return View(theatre);
        }

        // POST: Theatres/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [Authorize(Roles = ("Admin, TheatreAgent"))]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "TheatreId,Name,Address")] Theatre theatre)
        {
            if (ModelState.IsValid)
            {
                db.Entry(theatre).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(theatre);
        }

        // GET: Theatres/Delete/5
        [Authorize(Roles = ("Admin, TheatreAgent"))]
        public ActionResult Delete(int id)
        {
            Theatre theatre = db.Theatres.Find(id);

            var playReservations = db.PlayReservations.Where(u => u.theatre.TheatreId == id).ToList();

            foreach (var reservation in playReservations)
            {
                db.PlayReservations.Remove(reservation);
            }

            db.Theatres.Remove(theatre);

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

        //GET: AddToTheatre
        [Authorize(Roles = ("Admin, TheatreAgent"))]
        public ActionResult AddToTheatre(int id)
        {
            var model = new AddToTheatre();
            model.selectedTheatre = id;
            model.Plays = db.Plays.ToList();
            var theatre = db.Theatres.Find(model.selectedTheatre);
            ViewBag.TheatreName = theatre.Name;

            return View(model);
        }

        [HttpPost]
        [Authorize(Roles = ("Admin, TheatreAgent"))]
        public ActionResult AddToTheatre(AddToTheatre model)
        {
            var theatre = db.Theatres.Find(model.selectedTheatre);
            var play = db.Plays.Find(model.selectedPlay);
            theatre.Plays.Add(play);
            db.SaveChanges();

            return RedirectToAction("Index", "Theatres");
        }

        //GET: ReservePlay
        public ActionResult ReservePlay()
        {
            var model = new ReservePlay();
            model.allTheatres = db.Theatres.ToList();

            return View(model);
        }

        [HttpPost]
        public ActionResult ReservePlay(int allTheatres, int play)
        {
            PlayReservation reservation = new PlayReservation();
            reservation.theatre = db.Theatres.Where(m => m.TheatreId == allTheatres).First();
            reservation.selectedPlay = db.Plays.Where(m => m.PlayId == play).First();
            var userID = User.Identity.GetUserId();
            reservation.user = db.Users.Where(m => m.Id == userID).First();
            db.Users.Where(m => m.Id == userID).First().reservedPlays.Add(reservation);

            db.PlayReservations.Add(reservation);
            db.SaveChanges();
            return RedirectToAction("Index", "Home");
        }

        // POST: Theatres/ReservePlay/5
        [HttpPost]  
        public ActionResult GetPlayById(int theatreId)
        {
            List<Play> plays = new List<Play>();
            plays = db.Theatres.Where(m => m.TheatreId == theatreId).First().Plays.ToList();
            SelectList playsList = new SelectList(plays, "PlayId", "PlayName", 0);
            return Json(playsList);
        }

    }
}
