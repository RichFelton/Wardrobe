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
    public class ColorsController : Controller
    {
        private WardrobeEntities db = new WardrobeEntities();

        // GET: Colors
        public ActionResult Index()
        {
            var colors = db.Colors.Include(c => c.Accessory).Include(c => c.Bottom).Include(c => c.Sho).Include(c => c.Top);
            return View(colors.ToList());
        }

        // GET: Colors/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Color color = db.Colors.Find(id);
            if (color == null)
            {
                return HttpNotFound();
            }
            return View(color);
        }

        // GET: Colors/Create
        public ActionResult Create()
        {
            ViewBag.AccessoryID = new SelectList(db.Accessories, "AccessoryID", "Name");
            ViewBag.BottomID = new SelectList(db.Bottoms, "BottomID", "Name");
            ViewBag.ShoeID = new SelectList(db.Shoes, "ShoeID", "Name");
            ViewBag.TopID = new SelectList(db.Tops, "TopID", "Name");
            return View();
        }

        // POST: Colors/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "ColorID,Color1,TopID,BottomID,ShoeID,AccessoryID")] Color color)
        {
            if (ModelState.IsValid)
            {
                db.Colors.Add(color);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.AccessoryID = new SelectList(db.Accessories, "AccessoryID", "Name", color.AccessoryID);
            ViewBag.BottomID = new SelectList(db.Bottoms, "BottomID", "Name", color.BottomID);
            ViewBag.ShoeID = new SelectList(db.Shoes, "ShoeID", "Name", color.ShoeID);
            ViewBag.TopID = new SelectList(db.Tops, "TopID", "Name", color.TopID);
            return View(color);
        }

        // GET: Colors/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Color color = db.Colors.Find(id);
            if (color == null)
            {
                return HttpNotFound();
            }
            ViewBag.AccessoryID = new SelectList(db.Accessories, "AccessoryID", "Name", color.AccessoryID);
            ViewBag.BottomID = new SelectList(db.Bottoms, "BottomID", "Name", color.BottomID);
            ViewBag.ShoeID = new SelectList(db.Shoes, "ShoeID", "Name", color.ShoeID);
            ViewBag.TopID = new SelectList(db.Tops, "TopID", "Name", color.TopID);
            return View(color);
        }

        // POST: Colors/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "ColorID,Color1,TopID,BottomID,ShoeID,AccessoryID")] Color color)
        {
            if (ModelState.IsValid)
            {
                db.Entry(color).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.AccessoryID = new SelectList(db.Accessories, "AccessoryID", "Name", color.AccessoryID);
            ViewBag.BottomID = new SelectList(db.Bottoms, "BottomID", "Name", color.BottomID);
            ViewBag.ShoeID = new SelectList(db.Shoes, "ShoeID", "Name", color.ShoeID);
            ViewBag.TopID = new SelectList(db.Tops, "TopID", "Name", color.TopID);
            return View(color);
        }

        // GET: Colors/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Color color = db.Colors.Find(id);
            if (color == null)
            {
                return HttpNotFound();
            }
            return View(color);
        }

        // POST: Colors/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Color color = db.Colors.Find(id);
            db.Colors.Remove(color);
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
