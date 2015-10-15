using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using SoluDej.Models;

namespace SoluDej.Controllers
{
    public class EvenementsController : Controller
    {
        private SoluDejEntities db = new SoluDejEntities();

        // GET: Evenements
        public ActionResult Index()
        {
            var evenements = db.Evenements.Include(e => e.Restaurants);
            return View(evenements.ToList());
        }

        // GET: Evenements/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Evenements evenements = db.Evenements.Find(id);
            if (evenements == null)
            {
                return HttpNotFound();
            }
            return View(evenements);
        }

        // GET: Evenements/Create
        public ActionResult Create()
        {
            ViewBag.Restaurant = new SelectList(db.Restaurants, "Id", "Nom");
            return View();
        }

        // POST: Evenements/Create
        // Afin de déjouer les attaques par sur-validation, activez les propriétés spécifiques que vous voulez lier. Pour 
        // plus de détails, voir  http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,Restaurant,Date,PlacesLimitees,NombrePlaces,Commentaire")] Evenements evenements)
        {
            if (ModelState.IsValid)
            {
                db.Evenements.Add(evenements);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.Restaurant = new SelectList(db.Restaurants, "Id", "Nom", evenements.Restaurant);
            return View(evenements);
        }

        // GET: Evenements/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Evenements evenements = db.Evenements.Find(id);
            if (evenements == null)
            {
                return HttpNotFound();
            }
            ViewBag.Restaurant = new SelectList(db.Restaurants, "Id", "Nom", evenements.Restaurant);
            return View(evenements);
        }

        // POST: Evenements/Edit/5
        // Afin de déjouer les attaques par sur-validation, activez les propriétés spécifiques que vous voulez lier. Pour 
        // plus de détails, voir  http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,Restaurant,Date,PlacesLimitees,NombrePlaces,Commentaire")] Evenements evenements)
        {
            if (ModelState.IsValid)
            {
                db.Entry(evenements).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.Restaurant = new SelectList(db.Restaurants, "Id", "Nom", evenements.Restaurant);
            return View(evenements);
        }

        // GET: Evenements/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Evenements evenements = db.Evenements.Find(id);
            if (evenements == null)
            {
                return HttpNotFound();
            }
            return View(evenements);
        }

        // POST: Evenements/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Evenements evenements = db.Evenements.Find(id);
            db.Evenements.Remove(evenements);
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
