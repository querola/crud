using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using DM2.Models;
using PagedList;

namespace DM2.Controllers
{
    public class ArticlesController : Controller
    {
        private TDMEntities db = new TDMEntities();

        [Authorize]
        // GET: Articles
        public ViewResult Index(string sortOrder, string currentFilter, string searchString, int? page)
        {

            var idarticles = db.Articles.OrderByDescending(x => x.IdArticle).ToString();

            ViewBag.CurrentSort = sortOrder;
            ViewBag.NameSortParm = String.IsNullOrEmpty(sortOrder) ? "Nombre" : "";
            ViewBag.DateSortParm = sortOrder == "Fecha" ? "Fecha" : "Fecha";
            ViewBag.IdSortParm = idarticles == null ? "" : idarticles;

            if (searchString != null)
            {
                page = 1;
            }
            else
            {
                searchString = currentFilter;
            }

            ViewBag.CurrentFilter = searchString;

            var articles = from s in db.Articles
                           select s;

            if (!String.IsNullOrEmpty(searchString))
            {
                articles = articles.Where(s => s.Nombre.Contains(searchString));
            }

            switch (sortOrder)
            {
                case "Nombre":
                    articles = articles.OrderByDescending(s => s.Nombre);
                    break;
                case "Fecha":
                    articles = articles.OrderByDescending(s => s.Fecha);
                    break;
                //case "Id":
                //    articles = articles.OrderByDescending(s => s.Id);
                //break;
                default:
                    articles = articles.Include(a => a.Sections).Include(a => a.Users).OrderByDescending(x => x.Fecha);
                    break;
            }

            int pageSize = 10;
            int pageNumber = (page ?? 1);
            return View(articles.ToPagedList(pageNumber, pageSize));
            }

            // GET: Articles/Details/5
            public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Articles articles = db.Articles.Find(id);
            if (articles == null)
            {
                return HttpNotFound();
            }
            return View(articles);
        }

        // GET: Articles/Create
        public ActionResult Create()
        {
            ViewBag.IdSection = new SelectList(db.Sections, "IdSection", "Nombre");
            ViewBag.IdUser = new SelectList(db.Users, "IdUser", "UserName");
            return View();
        }

        // POST: Articles/Create
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que desea enlazarse. Para obtener 
        // más información vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "IdArticle,URL,Fecha,Nombre,Body,ImgURL,IdUser,IdSection")] Articles articles)
        {
            if (ModelState.IsValid)
            {
                db.Articles.Add(articles);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.IdSection = new SelectList(db.Sections, "IdSection", "Nombre", articles.IdSection);
            ViewBag.IdUser = new SelectList(db.Users, "IdUser", "UserName", articles.IdUser);
            return View(articles);
        }

        // GET: Articles/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Articles articles = db.Articles.Find(id);
            if (articles == null)
            {
                return HttpNotFound();
            }
            ViewBag.IdSection = new SelectList(db.Sections, "IdSection", "Nombre", articles.IdSection);
            ViewBag.IdUser = new SelectList(db.Users, "IdUser", "UserName", articles.IdUser);
            return View(articles);
        }

        // POST: Articles/Edit/5
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que desea enlazarse. Para obtener 
        // más información vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "IdArticle,URL,Fecha,Nombre,Body,ImgURL,IdUser,IdSection")] Articles articles)
        {
            if (ModelState.IsValid)
            {
                db.Entry(articles).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.IdSection = new SelectList(db.Sections, "IdSection", "Nombre", articles.IdSection);
            ViewBag.IdUser = new SelectList(db.Users, "IdUser", "UserName", articles.IdUser);
            return View(articles);
        }

        // GET: Articles/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Articles articles = db.Articles.Find(id);
            if (articles == null)
            {
                return HttpNotFound();
            }
            return View(articles);
        }

        // POST: Articles/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Articles articles = db.Articles.Find(id);
            db.Articles.Remove(articles);
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
