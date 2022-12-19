using MVC.Project.OnlineFurnitureSystem.Models.Data;
using MVC.Project.OnlineFurnitureSystem.Models.ViewModels.Shop;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MVC.Project.OnlineFurnitureSystem.Controllers
{
    public class ShopController : Controller
    {
        // GET: Shop
        public ActionResult Index()
        {
            return RedirectToAction("Index","Pages");
        }
        public ActionResult CategoryMenuPartial()
        {
            // Declare list of CategoryVM
            List<CategoryVM> categoryVMList;

            // Init the list
            using (Db db = new Db())
            {
                categoryVMList = db.Categories.ToArray().OrderBy(x => x.Sorting).Select(x => new CategoryVM(x,0)).ToList();
            }

            // Return partial with list
            return PartialView(categoryVMList);
        }

        // GET: /shop/category/name
        public ActionResult Category(string name)
        {
            // Declare a list of ProductVM
            List<ProductVM> productVMList;

            using (Db db = new Db())
            {
                // Get category id
                CategoryDTO categoryDTO = db.Categories.Where(x => x.Slug == name).FirstOrDefault();
                int catId = categoryDTO.Id;

                // Init the list
                productVMList = db.Products.ToArray().Where(x => x.CategoryId == catId).Select(x => new ProductVM(x)).ToList();

                // Get category name
                ViewBag.CategoryName = categoryDTO.Name;
            }

            // Return view with list
            return View(productVMList);
        }

        // GET: /shop/product-details/name
        [ActionName("product-details")]
        public ActionResult ProductDetails(string name)
        {
            // Declare the VM, DTO, and id
            ProductVM model;
            ProductDTO dto;
            int id;

            using (Db db = new Db())
            {
                // Check if product exists
                if (!db.Products.Any(x => x.Slug.Equals(name)))
                {
                    return RedirectToAction("Category", "Shop");
                }

                // Init productDTO
                dto = db.Products.Where(x => x.Slug == name).FirstOrDefault();

                // Get id
                id = dto.Id;

                // Init model
                model = new ProductVM(dto);
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
            List<ProductVM> lstProductVM;
            //Set defualt first page

            using (Db db = new Db())
            {
                lstProductVM = db.Products.ToArray()
                               .Where(x => x.Name.ToLower().Contains(searchWord.ToLower()))
                               .Select(x => new ProductVM(x)).ToList();
                if (lstProductVM == null && lstProductVM.Count == 0)
                {
                    return Content("<h1>No matched results<h1>");
                }
            }
            return View(lstProductVM);
        }

    }
}