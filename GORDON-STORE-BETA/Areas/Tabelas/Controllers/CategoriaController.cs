using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using GORDON_STORE_BETA.Context;
using System.Net;
using System.Data.Entity;
using Modelo.Tabelas;
using Servico.Tabelas;

namespace GORDON_STORE_BETA.Areas.Tabelas.Controllers
{
    public class CategoriaController : Controller
    {
        private CategoriaServico categoriaServico = new CategoriaServico();

        //Pega os detalhes da categoria de acordo com o id, serve para diminuir a redundância na hora de mostrar vz
        private ActionResult ObterVisaoCategoriaPorId(long? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(
                HttpStatusCode.BadRequest);
            }
            Categoria categoria = categoriaServico.ObterCategoriaPorId((long)id);
            if (categoria == null)
            {
                return HttpNotFound();
            }
            return View(categoria);
        }
        //Salva dados da Categoria
        private ActionResult GravarCategoria(Categoria categoria)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    categoriaServico.GravarCategoria(categoria);
                    return RedirectToAction("Index");
                }
                return View(categoria);
            }
            catch
            {
                return View(categoria);
            }
        }

        //---------------------- ACTIONS ABAIXO -----------------------//
        // GET: Estudio
        public ActionResult Index()
        {
            return View(categoriaServico.ObterCategoriasClassificadasPorNome());
        }

        // GET: Estudio/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(Categoria categoria)
       {
            return GravarCategoria(categoria);
        }
        // GET: Edit
        public ActionResult Edit(long? id)
        {
            return ObterVisaoCategoriaPorId(id);
        }
        // POST: Edit
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(Categoria categoria)
        {
            return GravarCategoria(categoria);
        }
        // GET: Details
        public ActionResult Details(long? id)
        {
            return ObterVisaoCategoriaPorId(id);
        }
        // GET: Delete
        public ActionResult Delete(long? id)
        {
            return ObterVisaoCategoriaPorId(id);
        }
        // POST: Delete
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(long id)
        {
            try
            {
                Categoria categoria = categoriaServico.EliminarCategoriaPorId(id);
                TempData["Message"] = "Categoria " + categoria.Nome.ToUpper() + " foi removida";
                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }
    }
}