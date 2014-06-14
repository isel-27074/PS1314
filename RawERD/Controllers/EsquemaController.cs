using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using RawERD.Data;

namespace RawERD.Controllers
{
    public class EsquemaController : Controller
    {
        private DataModel db = new DataModel();

        public ActionResult Esquema()
        {
            return View();
        }


        public ActionResult CriarEntidade()
        {
            return View();
        }

        [HttpPost]
        public ActionResult CriarEntidade()
        {
            return View();
        }

        public ActionResult CriarAtributo()
        {
            return View();
        }

        [HttpPost]
        public ActionResult CriarAtributo()
        {
            return View();
        }

        public ActionResult CriarRelacao()
        {
            return View();
        }

        [HttpPost]
        public ActionResult CriarRelacao()
        {
            return View();
        }

        #region MVC5 Controller with views using Entity Framework

        // GET: Esquema
        public ActionResult Index()
        {
            var diagrams = db.Diagrams.Include(d => d.User);
            return View(diagrams.ToList());
        }

        // GET: Esquema/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Diagram diagram = db.Diagrams.Find(id);
            if (diagram == null)
            {
                return HttpNotFound();
            }
            return View(diagram);
        }

        // GET: Esquema/Create
        public ActionResult Create()
        {
            ViewBag.idUser = new SelectList(db.Users, "idUser", "username");
            return View();
        }

        // POST: Esquema/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "idDiagram,idUser,title,privacy,json")] Diagram diagram)
        {
            if (ModelState.IsValid)
            {
                db.Diagrams.Add(diagram);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.idUser = new SelectList(db.Users, "idUser", "username", diagram.idUser);
            return View(diagram);
        }

        // GET: Esquema/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Diagram diagram = db.Diagrams.Find(id);
            if (diagram == null)
            {
                return HttpNotFound();
            }
            ViewBag.idUser = new SelectList(db.Users, "idUser", "username", diagram.idUser);
            return View(diagram);
        }

        // POST: Esquema/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "idDiagram,idUser,title,privacy,json")] Diagram diagram)
        {
            if (ModelState.IsValid)
            {
                db.Entry(diagram).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.idUser = new SelectList(db.Users, "idUser", "username", diagram.idUser);
            return View(diagram);
        }

        // GET: Esquema/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Diagram diagram = db.Diagrams.Find(id);
            if (diagram == null)
            {
                return HttpNotFound();
            }
            return View(diagram);
        }

        // POST: Esquema/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Diagram diagram = db.Diagrams.Find(id);
            db.Diagrams.Remove(diagram);
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

        #endregion MVC5 Controller with views using Entity Framework
    }
}