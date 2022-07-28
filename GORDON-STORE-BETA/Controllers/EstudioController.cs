using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using GORDON_STORE_BETA.Models;
using GORDON_STORE_BETA.Context;
using System.Net;
using System.Data.Entity;

namespace GORDON_STORE_BETA.Controllers
{
    public class EstudioController : Controller
    {
        private EFContext context = new EFContext();
        // GET: Estudio
        public ActionResult Index()
        {
            return View(context.Estudios.OrderBy(c => c.Nome));
        }

        // GET: Estudio/Details/5
        public ActionResult Details(long? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Estudio estudio = context.Estudios.Find(id);
            if (estudio == null)
            {
                return HttpNotFound();
            }
            return View(estudio);
        }

        // GET: Estudio/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Estudio/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(Estudio estudio)
        {
            context.Estudios.Add(estudio);
            context.SaveChanges();
            return RedirectToAction("Index");
        }

        // GET: Estudio/Edit/5
        public ActionResult Edit(long? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Estudio estudio = context.Estudios.Find(id);
            if (estudio == null)
            {
                return HttpNotFound();
            }
            return View(estudio);
        }

        // POST: Estudio/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(Estudio estudio)
        {
            if (ModelState.IsValid)
            {
                context.Entry(estudio).State = EntityState.Modified;
                context.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(estudio);
        }

        // GET: Estudio/Delete/5
        public ActionResult Delete(long? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Estudio estudio = context.Estudios.Find(id);
            if (estudio == null)
            {
                return HttpNotFound();
            }
            return View(estudio);
        }

        // POST: Estudio/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(long id)
        {
            Estudio estudio = context.Estudios.Find(id);
            context.Estudios.Remove(estudio);
            context.SaveChanges();
            TempData["Message"] = "Estúdio " + estudio.Nome.ToUpper() + " foi removida";
            return RedirectToAction("Index");
        }
    }
}
