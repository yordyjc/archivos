using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Helpers;
using System.Web.Mvc;
using SubirArchivos.Models;

namespace SubirArchivos.Controllers
{
    public class ImagensController : Controller
    {
        private Imagencontext db = new Imagencontext();

        // GET: Imagens
        public ActionResult Index()
        {
            return View(db.Images.ToList());
        }

        // GET: Imagens/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Imagen imagen = db.Images.Find(id);
            if (imagen == null)
            {
                return HttpNotFound();
            }
            return View(imagen);
        }

        // GET: Imagens/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Imagens/Create
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que desea enlazarse. Para obtener 
        // más información vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "id,nombre")] Imagen imagen)
        {
            HttpPostedFileBase http = Request.Files[0];
            WebImage image = new WebImage(http.InputStream);
            imagen.img = image.GetBytes(); 
            if (ModelState.IsValid)
            {
                db.Images.Add(imagen);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(imagen);
        }

        // GET: Imagens/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Imagen imagen = db.Images.Find(id);
            if (imagen == null)
            {
                return HttpNotFound();
            }
            return View(imagen);
        }

        // POST: Imagens/Edit/5
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que desea enlazarse. Para obtener 
        // más información vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "id,nombre,img")] Imagen imagen)
        {
            if (ModelState.IsValid)
            {
                db.Entry(imagen).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(imagen);
        }

        // GET: Imagens/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Imagen imagen = db.Images.Find(id);
            if (imagen == null)
            {
                return HttpNotFound();
            }
            return View(imagen);
        }

        // POST: Imagens/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Imagen imagen = db.Images.Find(id);
            db.Images.Remove(imagen);
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
