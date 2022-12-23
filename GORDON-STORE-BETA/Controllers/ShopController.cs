//using System;
//using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Modelo.Cadastro;
using Modelo.Tabelas;
using Persistencia.Context;
using GORDON_STORE_ALPHA.Models.ViewModels;
using System.Collections.Generic;
using Servico.Cadastro;
using GORDON_STORE_BETA.Models.ViewModels;

namespace GORDON_STORE_BETA.Controllers
{
    public class ShopController : Controller
    {
        private EFContext cadcontext = new EFContext();
        private ProdutoServico produtoServico = new ProdutoServico();
        public ActionResult Index()
        {
           Shop shop = new Shop();
            shop.listaprodutos = produtoServico.ObterProdutosClassificadosPorNome();
            return View(shop);
        }
        //public ActionResult CategoryMenuPartial()
        //{
        //    // Declare list of CategoryVM
        //    List<Categoria> categoryVMList;

        //    // Init the list

        //    using (EFContext cadcontext = new EFContext())
        //    {
        //        categoryVMList = cadcontext.Categorias.ToArray().OrderBy(x => x.Nome)/*.Select(x => new CategoriaVM(x, 0)).ToList()*/;
        //    }


        //    // Return partial with list
        //    return PartialView(categoryVMList);
        //}

        //GET: /shop/category/name
        public ActionResult Category(long id)
        {
            // Declare a list of ProductVM
            List<ProdutoVM> productVMList;

            using (EFContext cadcontext = new EFContext())
            {
                // Get category id
                Categoria categoriaDTO = cadcontext.Categorias.Where(x => x.CategoriaId == id).FirstOrDefault();
                long catId = categoriaDTO.CategoriaId;

                // Init the list
                productVMList = cadcontext.Produtos.ToArray().Where(x => x.CategoriaId == catId).Select(x => new ProdutoVM(x)).ToList();

                // Get category name
                ViewBag.CategoriaNome = categoriaDTO.Nome;
            }

            // Return view with list
            return View(productVMList);
        }

        // GET: /shop/product-details/name
        [ActionName("product-details")]
        public ActionResult ProductDetails(string name)
        {
            // Declare the VM, DTO, and id
            ProdutoVM model;
            Produto dto;
            long? id;

            using (EFContext cadcontext = new EFContext())
            {
                // Check if product exists
                //if (!cadcontext.Produtos.Any(x => x.Slug.Equals(name)))
                //{
                //    return RedirectToAction("Category", "Shop");
                //}

                // Init productDTO
                dto = cadcontext.Produtos.Where(x => x.Slug == name).FirstOrDefault();

                // Get id
                id = dto.ProdutoId;

                // Init model
                model = new ProdutoVM(dto);
            }

            // Get gallery images
            model.GalleryImages = Directory.EnumerateFiles(Server.MapPath("~/Images/Uploads/Products/" + id + "/Gallery/Thumbs"))
                                                .Select(fn => Path.GetFileName(fn));

            // Return view with model
            return View("ProductDetails", model);
        }

        //Get: Shop/Search-Results/searchWord
        [ActionName("Search-Results")]
        public ActionResult SearchResults(string searchWord)
        {
            //initialize list of productvm
            List<ProdutoVM> lstProductVM;
            //Set defualt first page

            using (EFContext cadcontext = new EFContext())
            {
                lstProductVM = cadcontext.Produtos.ToArray()
                               .Where(x => x.Nome.ToLower().Contains(searchWord.ToLower()))
                               .Select(x => new ProdutoVM(x)).ToList();
                if (lstProductVM == null && lstProductVM.Count == 0)
                {
                    return Content("<h1>No matched results<h1>");
                }
            }
            return View(lstProductVM);
        }

    }
}
