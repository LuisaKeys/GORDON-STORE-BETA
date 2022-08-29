using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Net;
using System.Data.Entity;
using Modelo.Cadastro;
using Servico.Cadastro;
using Servico.Tabelas;
using GORDON_STORE_BETA.Context;

namespace GORDON_STORE_BETA.Areas.Cadastro.Controllers
{
    public class ProdutoController : Controller
    {
        
        private ProdutoServico produtoServico = new ProdutoServico();
        private CategoriaServico categoriaServico = new CategoriaServico();
        private EstudioServico estudioServico = new EstudioServico();

        //Pega os detalhes do produto de acordo com o id, serve para diminuir a redundância na hora de mostrar vz
        private ActionResult ObterVisaoProdutoPorId(long? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Produto produto = produtoServico.ObterProdutoPorId((long?)id);
            if (produto == null)
            {
                return HttpNotFound();
            }
            return View(produto);
        }
        // Serve para popular combobox
        private void PopularViewBag(Produto produto = null)
        {
            if (produto == null)
            {
                ViewBag.CategoriaId = new SelectList(categoriaServico.ObterCategoriasClassificadasPorNome(),
                "CategoriaId", "Nome");
                ViewBag.EstudioId = new SelectList(estudioServico.ObterEstudiosClassificadosPorNome(),
                "EstudioId", "Nome");
            }
            else
            {
                ViewBag.CategoriaId = new SelectList(categoriaServico.ObterCategoriasClassificadasPorNome(),
                "CategoriaId", "Nome", produto.CategoriaId);
                ViewBag.EstudioId = new SelectList(estudioServico.ObterEstudiosClassificadosPorNome(),
                "EstudioId", "Nome", produto.EstudioId);
            }
        }
        
        // Salva os produtos
        private ActionResult GravarProduto(Produto produto)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    produtoServico.GravarProduto(produto);
                    return RedirectToAction("Index");
                }
                PopularViewBag(produto);
                return View(produto);
            }
            catch
            {
                return View(produto);
            }
        }
       

        //---------------------- ACTIONS ABAIXO -----------------------//
        //GET: Produtos
        [Authorize(Roles = "Administradores")]
        public ActionResult Index()
        {
            return View(produtoServico.ObterProdutosClassificadosPorNome());
        }


        // GET: Produto/Details/5
        [Authorize]
        public ActionResult Details(long? id)
        {
            return ObterVisaoProdutoPorId(id);
        }

        // GET: Produto/Create
        [Authorize]
        public ActionResult Create()
        {
            PopularViewBag();
            return View();
        }

        // POST: Produtos/Create
        [HttpPost]
        public ActionResult Create(Produto produto)
        {
            return GravarProduto(produto);
        }

        // GET: Produto/Edit/5
        [Authorize]
        public ActionResult Edit(long? id)
        {
            PopularViewBag(produtoServico.ObterProdutoPorId((long)id));
            return ObterVisaoProdutoPorId(id);
        }

        // POST: Produto/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(Produto produto)
        {
            return GravarProduto(produto);
        }

        // GET: Produto/Delete/5
        [Authorize]
        public ActionResult Delete(long? id)
        {
            return ObterVisaoProdutoPorId(id);
        }

        // POST: Produto/Delete/5
        [HttpPost]
        public ActionResult Delete(int id, FormCollection collection)
        {
            try
            {
                Produto produto = produtoServico.EliminarProdutoPorId(id);
                TempData["Message"] = "Produto " + produto.Nome.ToUpper() + " foi removido";
                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

    }
}
