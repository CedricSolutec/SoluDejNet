using SoluDej.Models;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web.Mvc;

namespace SoluDej.Controllers
{
    public class VillesController : Controller
    {
        private SoluDejEntities db = new SoluDejEntities();

        // GET: Villes
        public ActionResult Index()
        {
            return View(db.Villes.ToList());
        }

        // GET: Villes/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Villes villes = db.Villes.Find(id);
            if (villes == null)
            {
                return HttpNotFound();
            }
            return View(villes);
        }

        // GET: Villes/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Villes/Create
        // Afin de déjouer les attaques par sur-validation, activez les propriétés spécifiques que vous voulez lier. Pour 
        // plus de détails, voir  http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,Ville")] Villes villes)
        {
            if (ModelState.IsValid)
            {
                db.Villes.Add(villes);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(villes);
        }

        // GET: Villes/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Villes villes = db.Villes.Find(id);
            if (villes == null)
            {
                return HttpNotFound();
            }
            return View(villes);
        }

        // POST: Villes/Edit/5
        // Afin de déjouer les attaques par sur-validation, activez les propriétés spécifiques que vous voulez lier. Pour 
        // plus de détails, voir  http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,Ville")] Villes villes)
        {
            if (ModelState.IsValid)
            {
                db.Entry(villes).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(villes);
        }

        // GET: Villes/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Villes villes = db.Villes.Find(id);
            if (villes == null)
            {
                return HttpNotFound();
            }
            return View(villes);
        }

        // POST: Villes/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Villes villes = db.Villes.Find(id);
            db.Villes.Remove(villes);
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
