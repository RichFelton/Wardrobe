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
    public class OccasionsController : Controller
    {
        private WardrobeEntities db = new WardrobeEntities();

        // GET: Occasions
        public ActionResult Index()
        {
            var occasions = db.Occasions.Include(o => o.Accessory).Include(o => o.Bottom).Include(o => o.Sho).Include(o => o.Top);
            return View(occasions.ToList());
        }

        // GET: Occasions/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Occasion occasion = db.Occasions.Find(id);
            if (occasion == null)
            {
                return HttpNotFound();
            }
            return View(occasion);
        }

        // GET: Occasions/Create
        public ActionResult Create()
        {
            ViewBag.AccessoryID = new SelectList(db.Accessories, "AccessoryID", "Name");
            ViewBag.BottomID = new SelectList(db.Bottoms, "BottomID", "Name");
            ViewBag.ShoeID = new SelectList(db.Shoes, "ShoeID", "Name");
            ViewBag.TopID = new SelectList(db.Tops, "TopID", "Name");
            return View();
        }

        // POST: Occasions/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "OccasionID,Occasion1,TopID,BottomID,ShoeID,AccessoryID")] Occasion occasion)
        {
            if (ModelState.IsValid)
            {
                db.Occasions.Add(occasion);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.AccessoryID = new SelectList(db.Accessories, "AccessoryID", "Name", occasion.AccessoryID);
            ViewBag.BottomID = new SelectList(db.Bottoms, "BottomID", "Name", occasion.BottomID);
            ViewBag.ShoeID = new SelectList(db.Shoes, "ShoeID", "Name", occasion.ShoeID);
            ViewBag.TopID = new SelectList(db.Tops, "TopID", "Name", occasion.TopID);
            return View(occasion);
        }

        // GET: Occasions/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Occasion occasion = db.Occasions.Find(id);
            if (occasion == null)
            {
                return HttpNotFound();
            }
            ViewBag.AccessoryID = new SelectList(db.Accessories, "AccessoryID", "Name", occasion.AccessoryID);
            ViewBag.BottomID = new SelectList(db.Bottoms, "BottomID", "Name", occasion.BottomID);
            ViewBag.ShoeID = new SelectList(db.Shoes, "ShoeID", "Name", occasion.ShoeID);
            ViewBag.TopID = new SelectList(db.Tops, "TopID", "Name", occasion.TopID);
            return View(occasion);
        }

        // POST: Occasions/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "OccasionID,Occasion1,TopID,BottomID,ShoeID,AccessoryID")] Occasion occasion)
        {
            if (ModelState.IsValid)
            {
                db.Entry(occasion).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.AccessoryID = new SelectList(db.Accessories, "AccessoryID", "Name", occasion.AccessoryID);
            ViewBag.BottomID = new SelectList(db.Bottoms, "BottomID", "Name", occasion.BottomID);
            ViewBag.ShoeID = new SelectList(db.Shoes, "ShoeID", "Name", occasion.ShoeID);
            ViewBag.TopID = new SelectList(db.Tops, "TopID", "Name", occasion.TopID);
            return View(occasion);
        }

        // GET: Occasions/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Occasion occasion = db.Occasions.Find(id);
            if (occasion == null)
            {
                return HttpNotFound();
            }
            return View(occasion);
        }

        // POST: Occasions/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Occasion occasion = db.Occasions.Find(id);
            db.Occasions.Remove(occasion);
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
