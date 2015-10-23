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
    public class UtilisateursController : Controller
    {
        private SoluDejEntities db = new SoluDejEntities();

        // GET: Utilisateurs
        public ActionResult Index()
        {
            var utilisateurs = db.Utilisateurs.Include(u => u.Entreprises);
            return View(utilisateurs.ToList());
        }

        // GET: Utilisateurs/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Utilisateurs utilisateurs = db.Utilisateurs.Find(id);
            if (utilisateurs == null)
            {
                return HttpNotFound();
            }
            return View(utilisateurs);
        }

        // GET: Utilisateurs/Create
        public ActionResult Create()
        {
            ViewBag.idEntreprise = new SelectList(db.Entreprises, "id", "nom");
            return View();
        }

        // POST: Utilisateurs/Create
        // Afin de déjouer les attaques par sur-validation, activez les propriétés spécifiques que vous voulez lier. Pour 
        // plus de détails, voir  http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "nom,prenom,mailSolutec,mailNotification,motDePasse,dateDeNaissance,idEntreprise,id")] Utilisateurs utilisateurs)
        {
            if (ModelState.IsValid)
            {
                db.Utilisateurs.Add(utilisateurs);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.idEntreprise = new SelectList(db.Entreprises, "id", "nom", utilisateurs.idEntreprise);
            return View(utilisateurs);
        }

        // GET: Utilisateurs/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Utilisateurs utilisateurs = db.Utilisateurs.Find(id);
            if (utilisateurs == null)
            {
                return HttpNotFound();
            }
            ViewBag.idEntreprise = new SelectList(db.Entreprises, "id", "nom", utilisateurs.idEntreprise);
            return View(utilisateurs);
        }

        // POST: Utilisateurs/Edit/5
        // Afin de déjouer les attaques par sur-validation, activez les propriétés spécifiques que vous voulez lier. Pour 
        // plus de détails, voir  http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "nom,prenom,mailSolutec,mailNotification,motDePasse,dateDeNaissance,idEntreprise,id")] Utilisateurs utilisateurs)
        {
            if (ModelState.IsValid)
            {
                db.Entry(utilisateurs).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.idEntreprise = new SelectList(db.Entreprises, "id", "nom", utilisateurs.idEntreprise);
            return View(utilisateurs);
        }

        // GET: Utilisateurs/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Utilisateurs utilisateurs = db.Utilisateurs.Find(id);
            if (utilisateurs == null)
            {
                return HttpNotFound();
            }
            return View(utilisateurs);
        }

        // POST: Utilisateurs/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Utilisateurs utilisateurs = db.Utilisateurs.Find(id);
            db.Utilisateurs.Remove(utilisateurs);
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
