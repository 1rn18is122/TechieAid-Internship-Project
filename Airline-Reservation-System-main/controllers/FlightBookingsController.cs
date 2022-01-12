using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using ARS.Models;

namespace ARS.Controllers
{
    public class FlightBookingsController : Controller
    {
        private ContextCS db = new ContextCS();

        // GET: FlightBookings
        public ActionResult Index()
        {
            var flightBookings = db.FlightBookings.Include(f => f.TicketReserve_tbls);
            return View(flightBookings.ToList());
        }

        // GET: FlightBookings/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            FlightBooking flightBooking = db.FlightBookings.Find(id);
            if (flightBooking == null)
            {
                return HttpNotFound();
            }
            return View(flightBooking);
        }

        // GET: FlightBookings/Create
        public ActionResult Create()
        {
            ViewBag.ResID = new SelectList(db.TicketReserve_tbl, "ResID", "Resfrom");
            return View();
        }

        // POST: FlightBookings/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "bid,bCusName,bCusAddress,bCusEmail,bCusPhoneNum,bCusSeats,ResID")] FlightBooking flightBooking)
        {
            if (ModelState.IsValid)
            {
                db.FlightBookings.Add(flightBooking);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.ResID = new SelectList(db.TicketReserve_tbl, "ResID", "Resfrom", flightBooking.ResID);
            return View(flightBooking);
        }

        // GET: FlightBookings/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            FlightBooking flightBooking = db.FlightBookings.Find(id);
            if (flightBooking == null)
            {
                return HttpNotFound();
            }
            ViewBag.ResID = new SelectList(db.TicketReserve_tbl, "ResID", "Resfrom", flightBooking.ResID);
            return View(flightBooking);
        }

        // POST: FlightBookings/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "bid,bCusName,bCusAddress,bCusEmail,bCusPhoneNum,bCusSeats,ResID")] FlightBooking flightBooking)
        {
            if (ModelState.IsValid)
            {
                db.Entry(flightBooking).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.ResID = new SelectList(db.TicketReserve_tbl, "ResID", "Resfrom", flightBooking.ResID);
            return View(flightBooking);
        }

        // GET: FlightBookings/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            FlightBooking flightBooking = db.FlightBookings.Find(id);
            if (flightBooking == null)
            {
                return HttpNotFound();
            }
            return View(flightBooking);
        }

        // POST: FlightBookings/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            FlightBooking flightBooking = db.FlightBookings.Find(id);
            db.FlightBookings.Remove(flightBooking);
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
