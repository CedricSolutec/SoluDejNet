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
    public class ArrondissementsController : Controller
    {
        private SoluDejEntities db = new SoluDejEntities();

        // GET: Arrondissements
        public ActionResult Index()
        {
            var arrondissements = db.Arrondissements.Include(a => a.Villes);
            return View(arrondissements.ToList());
        }

        // GET: Arrondissements/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Arrondissements arrondissements = db.Arrondissements.Find(id);
            if (arrondissements == null)
            {
                return HttpNotFound();
            }
            return View(arrondissements);
        }

        // GET: Arrondissements/Create
        public ActionResult Create()
        {
            ViewBag.Ville = new SelectList(db.Villes, "Id", "Ville");
            return View();
        }

        // POST: Arrondissements/Create
        // Afin de déjouer les attaques par sur-validation, activez les propriétés spécifiques que vous voulez lier. Pour 
        // plus de détails, voir  http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,Ville,Arrondissement")] Arrondissements arrondissements)
        {
            if (ModelState.IsValid)
            {
                db.Arrondissements.Add(arrondissements);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.Ville = new SelectList(db.Villes, "Id", "Ville", arrondissements.Ville);
            return View(arrondissements);
        }

        // GET: Arrondissements/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Arrondissements arrondissements = db.Arrondissements.Find(id);
            if (arrondissements == null)
            {
                return HttpNotFound();
            }
            ViewBag.Ville = new SelectList(db.Villes, "Id", "Ville", arrondissements.Ville);
            return View(arrondissements);
        }

        // POST: Arrondissements/Edit/5
        // Afin de déjouer les attaques par sur-validation, activez les propriétés spécifiques que vous voulez lier. Pour 
        // plus de détails, voir  http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,Ville,Arrondissement")] Arrondissements arrondissements)
        {
            if (ModelState.IsValid)
            {
                db.Entry(arrondissements).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.Ville = new SelectList(db.Villes, "Id", "Ville", arrondissements.Ville);
            return View(arrondissements);
        }

        // GET: Arrondissements/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Arrondissements arrondissements = db.Arrondissements.Find(id);
            if (arrondissements == null)
            {
                return HttpNotFound();
            }
            return View(arrondissements);
        }

        // POST: Arrondissements/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Arrondissements arrondissements = db.Arrondissements.Find(id);
            db.Arrondissements.Remove(arrondissements);
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
