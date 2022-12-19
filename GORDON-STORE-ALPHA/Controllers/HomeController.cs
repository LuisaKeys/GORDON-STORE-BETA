using GORDON_STORE_ALPHA.Models.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Servico.Cadastro;

namespace GORDON_STORE_ALPHA.Controllers
{
    public class HomeController : Controller
    {
        ProdutoServico produtoServico = new ProdutoServico();
        public ActionResult Index()
        {
            HomeClass home = new HomeClass();

            home.listaprodutos = produtoServico.ObterProdutosClassificadosPorNome();
            home.listaProdutoLancamento = produtoServico.ObterProdutosClassificadosPorData();
            return View(home);
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }
    }
}