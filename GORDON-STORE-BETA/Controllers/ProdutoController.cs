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
    public class ProdutoController : Controller
    {
        private EFContext context = new EFContext();
        //GET: Produtos
        public ActionResult Index()
        {
            var produtos =
            context.Produtos.Include(c => c.Categoria).Include(f => f.Estudio).
            OrderBy(n => n.Nome);
            return View(produtos);
        }


        // GET: Produto/Details/5
        public ActionResult Details(long? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Produto produto = context.Produtos.Find(id);
            if (produto == null)
            {
                return HttpNotFound();
            }
            return View(produto);
        }

        // GET: Produto/Create
        public ActionResult Create()
        {
            ViewBag.CategoriaId = new SelectList(context.Categorias.OrderBy(b => b.Nome),
            "CategoriaId", "Nome");
            ViewBag.FabricanteId = new SelectList(context.Estudios.OrderBy(b => b.Nome),
            "FabricanteId", "Nome");
            return View();
        }

        // POST: Produto/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        // POST: Produtos/Create
        [HttpPost]
        public ActionResult Create(Produto produto)
        {
            try
            {
                // TODO: Add insert logic here
                context.Produtos.Add(produto);
                context.SaveChanges();
                return RedirectToAction("Index");
            }
            catch
            {
                return View(produto);
            }
        }

        // GET: Produto/Edit/5
        public ActionResult Edit(long? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Produto produto = context.Produtos.Find(id);
            if (produto == null)
            {
                return HttpNotFound();
            }
            return View(produto);
        }

        // POST: Produto/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(Produto produto)
        {
            if (ModelState.IsValid)
            {
                context.Entry(produto).State = EntityState.Modified;
                context.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(produto);
        }

        // GET: Produto/Delete/5
        public ActionResult Delete(long? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Produto produto = context.Produtos.Find(id);
            if (produto == null)
            {
                return HttpNotFound();
            }
            return View(produto);
        }

        // POST: Produto/Delete/5
        [HttpPost]
        public ActionResult Delete(long id)
        {
            Produto produto = context.Produtos.Find(id);
            context.Produtos.Remove(produto);
            context.SaveChanges();
            TempData["Message"] = "Produto " + produto.Nome.ToUpper() + " foi removida";
            return RedirectToAction("Index");
        }
    }
}
