using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using DM2.Models;

namespace DM2.Controllers
{
    public class ArticulosTagsController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        // GET: ArticulosTags
        public ActionResult Index()
        {
            var articulosTags = db.ArticulosTags.Include(a => a.Tags);
            return View(articulosTags.ToList());
        }

        // GET: ArticulosTags/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ArticulosTag articulosTag = db.ArticulosTags.Find(id);
            if (articulosTag == null)
            {
                return HttpNotFound();
            }
            return View(articulosTag);
        }

        // GET: ArticulosTags/Create
        public ActionResult Create()
        {
            ViewBag.IdTag = new SelectList(db.Tags, "IdTag", "NombreTag");
            return View();
        }

        // POST: ArticulosTags/Create
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que desea enlazarse. Para obtener 
        // más información vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "IdArtTag,IdTag,IdArticle")] ArticulosTag articulosTag)
        {
            if (ModelState.IsValid)
            {
                db.ArticulosTags.Add(articulosTag);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.IdTag = new SelectList(db.Tags, "IdTag", "NombreTag", articulosTag.IdTag);
            return View(articulosTag);
        }

        // GET: ArticulosTags/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ArticulosTag articulosTag = db.ArticulosTags.Find(id);
            if (articulosTag == null)
            {
                return HttpNotFound();
            }
            ViewBag.IdTag = new SelectList(db.Tags, "IdTag", "NombreTag", articulosTag.IdTag);
            return View(articulosTag);
        }

        // POST: ArticulosTags/Edit/5
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que desea enlazarse. Para obtener 
        // más información vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "IdArtTag,IdTag,IdArticle")] ArticulosTag articulosTag)
        {
            if (ModelState.IsValid)
            {
                db.Entry(articulosTag).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.IdTag = new SelectList(db.Tags, "IdTag", "NombreTag", articulosTag.IdTag);
            return View(articulosTag);
        }

        // GET: ArticulosTags/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ArticulosTag articulosTag = db.ArticulosTags.Find(id);
            if (articulosTag == null)
            {
                return HttpNotFound();
            }
            return View(articulosTag);
        }

        // POST: ArticulosTags/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            ArticulosTag articulosTag = db.ArticulosTags.Find(id);
            db.ArticulosTags.Remove(articulosTag);
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
