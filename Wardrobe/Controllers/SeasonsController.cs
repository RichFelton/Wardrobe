using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using Wardrobe;

namespace Wardrobe.Controllers
{
    public class SeasonsController : Controller
    {
        private WardrobeEntities db = new WardrobeEntities();

        // GET: Seasons
        public ActionResult Index()
        {
            var seasons = db.Seasons.Include(s => s.Accessory).Include(s => s.Bottom).Include(s => s.Sho).Include(s => s.Top);
            return View(seasons.ToList());
        }

        // GET: Seasons/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Season season = db.Seasons.Find(id);
            if (season == null)
            {
                return HttpNotFound();
            }
            return View(season);
        }

        // GET: Seasons/Create
        public ActionResult Create()
        {
            ViewBag.AccessoryID = new SelectList(db.Accessories, "AccessoryID", "Name");
            ViewBag.BottomID = new SelectList(db.Bottoms, "BottomID", "Name");
            ViewBag.ShoeID = new SelectList(db.Shoes, "ShoeID", "Name");
            ViewBag.TopID = new SelectList(db.Tops, "TopID", "Name");
            return View();
        }

        // POST: Seasons/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "SeasonID,Season1,TopID,BottomID,ShoeID,AccessoryID")] Season season)
        {
            if (ModelState.IsValid)
            {
                db.Seasons.Add(season);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.AccessoryID = new SelectList(db.Accessories, "AccessoryID", "Name", season.AccessoryID);
            ViewBag.BottomID = new SelectList(db.Bottoms, "BottomID", "Name", season.BottomID);
            ViewBag.ShoeID = new SelectList(db.Shoes, "ShoeID", "Name", season.ShoeID);
            ViewBag.TopID = new SelectList(db.Tops, "TopID", "Name", season.TopID);
            return View(season);
        }

        // GET: Seasons/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Season season = db.Seasons.Find(id);
            if (season == null)
            {
                return HttpNotFound();
            }
            ViewBag.AccessoryID = new SelectList(db.Accessories, "AccessoryID", "Name", season.AccessoryID);
            ViewBag.BottomID = new SelectList(db.Bottoms, "BottomID", "Name", season.BottomID);
            ViewBag.ShoeID = new SelectList(db.Shoes, "ShoeID", "Name", season.ShoeID);
            ViewBag.TopID = new SelectList(db.Tops, "TopID", "Name", season.TopID);
            return View(season);
        }

        // POST: Seasons/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "SeasonID,Season1,TopID,BottomID,ShoeID,AccessoryID")] Season season)
        {
            if (ModelState.IsValid)
            {
                db.Entry(season).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.AccessoryID = new SelectList(db.Accessories, "AccessoryID", "Name", season.AccessoryID);
            ViewBag.BottomID = new SelectList(db.Bottoms, "BottomID", "Name", season.BottomID);
            ViewBag.ShoeID = new SelectList(db.Shoes, "ShoeID", "Name", season.ShoeID);
            ViewBag.TopID = new SelectList(db.Tops, "TopID", "Name", season.TopID);
            return View(season);
        }

        // GET: Seasons/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Season season = db.Seasons.Find(id);
            if (season == null)
            {
                return HttpNotFound();
            }
            return View(season);
        }

        // POST: Seasons/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Season season = db.Seasons.Find(id);
            db.Seasons.Remove(season);
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
