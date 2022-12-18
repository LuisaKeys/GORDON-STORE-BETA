//using System;
//using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using GORDON_STORE_ALPHA.Context;
using Modelo.Cadastro;
using Modelo.Tabelas;
using Persistencia.Context;
using GORDON_STORE_ALPHA.Models.ViewModels;
using System.Collections.Generic;

namespace WebAppECartDemo.Controllers
{
    public class ShopController : Controller
    {
        private ContextCart cartcontext = new ContextCart();
        private EFContext cadcontext = new EFContext();
        public ActionResult Index()
        {
            var produtoVMList = cadcontext.Produtos.ToArray().OrderBy(x => x.Nome).Select(x => new ProdutoVM(x)).ToList();
            return View(produtoVMList);
        }
        //public ActionResult CategoryMenuPartial()
        //{
        //    // Declare list of CategoryVM
        //    List<Categoria> categoryVMList;

        //    // Init the list

        //    categoryVMList = cadcontext.Categorias.ToArray().OrderBy(x => x.Sorting).Select(x => new CategoryVM(x, 0)).ToList();


        //    // Return partial with list
        //    return PartialView(categoryVMList);
        //}

        // GET: /shop/category/name
        //public ActionResult Category(string name)
        //{
        //    // Declare a list of ProductVM
        //    List<ProductVM> productVMList;

        //    using (Db db = new Db())
        //    {
        //        // Get category id
        //        CategoryDTO categoryDTO = db.Categories.Where(x => x.Slug == name).FirstOrDefault();
        //        int catId = categoryDTO.Id;

        //        // Init the list
        //        productVMList = db.Products.ToArray().Where(x => x.CategoryId == catId).Select(x => new ProductVM(x)).ToList();

        //        // Get category name
        //        ViewBag.CategoryName = categoryDTO.Name;
        //    }

        //    // Return view with list
        //    return View(productVMList);
        //}

        // GET: /shop/product-details/name
        [ActionName("product-details")]
        public ActionResult ProductDetails(string name)
        {
            // Declare the VM, DTO, and id
            ProdutoVM model;
            Produto dto;
            long id;

            using (EFContext cadcontext = new EFContext())
            {
                // Check if product exists
                if (!cadcontext.Produtos.Any(x => x.Nome.Equals(name)))
                {
                    return RedirectToAction("Category", "Shop");
                }

                // Init productDTO
                dto = cadcontext.Produtos.Where(x => x.Nome == name).FirstOrDefault();

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
