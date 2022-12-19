using MVC.Project.OnlineFurnitureSystem.Models.Data;
using MVC.Project.OnlineFurnitureSystem.Models.ViewModels.Pages;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MVC.Project.OnlineFurnitureSystem.Controllers
{
    public class PagesController : Controller
    {
        // GET: Index/{page}
        public ActionResult Index(string page = "")

        {
            // Get/set page slug
            if (page == "")
                page = "home";

            // Declare model and DTO
            PageVM model;
            PageDTO dto;

            using (Db db = new Db())
            {
                // Check if page exists
                if (!db.Pages.Any(x => x.Slug.Equals(page)))
                {
                    return RedirectToAction("Index", new { page = "" });
                }

                // Get page DTO
                dto = db.Pages.Where(x => x.Slug == page).FirstOrDefault();
            }

            // Set page title
            TempData["PageTitle"] = dto.Title;
            ViewBag.Title = dto.Title;

            // Check for sidebar
            if (dto.HasSideBar == true)
            {
                ViewBag.Sidebar = "Yes";
            }
            else
            {
                ViewBag.Sidebar = "No";
            }

            // Init model
            model = new PageVM(dto);


            // Return view with model
            return View(model);
        }
        public ActionResult PagesMenuPartial()
        {
            // Declare a list of PageVM
            List<PageVM> pageVMList;

            // Get all pages except home
            using (Db db = new Db())
            {
                pageVMList = db.Pages.ToArray().OrderBy(x => x.Sorting).Where(x => x.Slug != "home").Select(x => new PageVM(x)).ToList();
            }
            // Return partial view with list
            return PartialView(pageVMList);
        }
        public ActionResult SideBarPartial()
        {
            // Declare MODEL
             SidebarVM model;

            //initialize the model
            using (Db db = new Db())
            {
                SidebarDTO dto = db.SideBar.Find(1);
                model = new SidebarVM(dto);
            }
            // Return partial view 
            return PartialView(model);
        }
        public ActionResult HomePagePartial()
        {
            return PartialView("HomePagePartial");
        }
    }
}