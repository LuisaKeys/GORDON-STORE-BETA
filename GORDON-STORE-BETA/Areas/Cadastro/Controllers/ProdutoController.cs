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
using System.Net.NetworkInformation;
using System.IO;

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
        private ActionResult GravarProduto(Produto produto, HttpPostedFileBase upimg, string chkRemoverImagem)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    if (chkRemoverImagem != null)
                    {
                        produto.UpImg = null;
                    }
                    if (upimg != null)
                    {
                        produto.UpImgMimeType = upimg.ContentType;
                        produto.UpImg = SetUpImg(upimg);
                    }
                    produtoServico.GravarProduto(produto);
                    return RedirectToAction("Index");
                }
                if (upimg != null)
                {
                    produto.UpImgMimeType = upimg.ContentType;
                    produto.UpImg = SetUpImg(upimg);
                    produto.NomeArquivo = upimg.FileName;
                    produto.TamanhoArquivo = upimg.ContentLength;
                }
                produtoServico.GravarProduto(produto);
                PopularViewBag(produto);
                return View(produto);
            }
            catch
            {
                PopularViewBag(produto);
                return View(produto);
            }
        }

        //transfrma o arquivo recebido em um vetor de bytes
        private byte[] SetUpImg(HttpPostedFileBase upimg)
        {
            var bytesUpImg = new byte[upimg.ContentLength];
            upimg.InputStream.Read(bytesUpImg, 0, upimg.ContentLength);
            return bytesUpImg;
        }

        //contém a imagem para a exibição na visão
        public FileContentResult GetUpImg(long id)
        {
            Produto produto = produtoServico.ObterProdutoPorId(id);
            if (produto != null)
            {
                return File(produto.UpImg, produto.UpImgMimeType);
            }
            return null;
        }

        //transferece o arquivo copiado do banco de dados para a pasta de download
        public ActionResult DownloadArquivo(long id)
        {
            Produto produto = produtoServico.ObterProdutoPorId(id);
            FileStream fileStream = new FileStream(Server.MapPath("~/App_Data/" + produto.NomeArquivo), FileMode.Create, FileAccess.Write);
            fileStream.Write(produto.UpImg, 0, Convert.ToInt32(produto.TamanhoArquivo));
            fileStream.Close();
            return File(fileStream.Name, produto.UpImgMimeType, produto.NomeArquivo);
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
        public ActionResult Create(Produto produto, HttpPostedFileBase upimg = null, string chkRemoverImagem = null)
        {
            return GravarProduto(produto, upimg, chkRemoverImagem);
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
        public ActionResult Edit(Produto produto, HttpPostedFileBase upimg = null, string chkRemoverImagem = null)
        {
            return GravarProduto(produto, upimg, chkRemoverImagem);
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
