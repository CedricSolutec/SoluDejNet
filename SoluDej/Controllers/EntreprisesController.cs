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
    public class EntreprisesController : Controller
    {
        private SoluDejEntities db = new SoluDejEntities();

        // GET: Entreprises
        public ActionResult Index()
        {
            var entreprises = db.Entreprises.Include(e => e.Arrondissements).Include(e => e.Villes);
            return View(entreprises.ToList());
        }

        // GET: Entreprises/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Entreprises entreprises = db.Entreprises.Find(id);
            if (entreprises == null)
            {
                return HttpNotFound();
            }
            return View(entreprises);
        }

        // GET: Entreprises/Create
        public ActionResult Create()
        {
            ViewBag.arrondissement = new SelectList(db.Arrondissements, "Id", "Arrondissement");
            ViewBag.ville = new SelectList(db.Villes, "Id", "Ville");
            return View();
        }

        // POST: Entreprises/Create
        // Afin de déjouer les attaques par sur-validation, activez les propriétés spécifiques que vous voulez lier. Pour 
        // plus de détails, voir  http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "id,nom,arrondissement,ville")] Entreprises entreprises)
        {
            if (ModelState.IsValid)
            {
                db.Entreprises.Add(entreprises);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.arrondissement = new SelectList(db.Arrondissements, "Id", "Arrondissement", entreprises.arrondissement);
            ViewBag.ville = new SelectList(db.Villes, "Id", "Ville", entreprises.ville);
            return View(entreprises);
        }

        // GET: Entreprises/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Entreprises entreprises = db.Entreprises.Find(id);
            if (entreprises == null)
            {
                return HttpNotFound();
            }
            ViewBag.arrondissement = new SelectList(db.Arrondissements, "Id", "Arrondissement", entreprises.arrondissement);
            ViewBag.ville = new SelectList(db.Villes, "Id", "Ville", entreprises.ville);
            return View(entreprises);
        }

        // POST: Entreprises/Edit/5
        // Afin de déjouer les attaques par sur-validation, activez les propriétés spécifiques que vous voulez lier. Pour 
        // plus de détails, voir  http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "id,nom,arrondissement,ville")] Entreprises entreprises)
        {
            if (ModelState.IsValid)
            {
                db.Entry(entreprises).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.arrondissement = new SelectList(db.Arrondissements, "Id", "Arrondissement", entreprises.arrondissement);
            ViewBag.ville = new SelectList(db.Villes, "Id", "Ville", entreprises.ville);
            return View(entreprises);
        }

        // GET: Entreprises/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Entreprises entreprises = db.Entreprises.Find(id);
            if (entreprises == null)
            {
                return HttpNotFound();
            }
            return View(entreprises);
        }

        // POST: Entreprises/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Entreprises entreprises = db.Entreprises.Find(id);
            db.Entreprises.Remove(entreprises);
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
