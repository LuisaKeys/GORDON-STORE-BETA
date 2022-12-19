using MVC.Project.OnlineFurnitureSystem.Models.Data;
using MVC.Project.OnlineFurnitureSystem.Models.ViewModels.Pages;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MVC.Project.OnlineFurnitureSystem.Areas.Admin.Controllers
{
    [Authorize(Roles = "Admin")]
    public class PagesController : Controller
    {
        // GET: Admin/Pages
        public ActionResult Index()
        {
            List<PageVM> PageLst;

            using (Db db = new Db())
            {
                PageLst = db.Pages.ToArray().OrderBy(x => x.Sorting).Select(x => new PageVM(x)).ToList();
            }
            return View(PageLst);
        }
        // GET: Admin/Pages/AddPage
        public ActionResult AddPage()
        {
            return View();
        }

        // Post: Admin/Pages/AddPage
        [HttpPost]
        public ActionResult AddPage(PageVM model)
        {
            //check model state
            if (!ModelState.IsValid)
            {
                return View();
            }
            using (Db db = new Db())
            {
                //Init PageDTO
                PageDTO page = new PageDTO();
                //page Title
                page.Title = model.Title;

                //Declairing slug
                string slug;
                //check for slug
                if (string.IsNullOrWhiteSpace(model.Slug))
                {
                    slug = model.Title.Replace(" ", "-").ToLower();
                }
                else
                {
                    slug = model.Slug.Replace(" ", "-").ToLower();
                }
                //Make sure that slug and Title are unique
                if (db.Pages.Any(x => x.Title == model.Title) || db.Pages.Any(x => x.Slug == model.Slug))
                {
                    ModelState.AddModelError("", "That title or slug already exists");
                    return View(model);
                }
                //Page adding the rest
                page.Slug = slug;
                page.Body = model.Body;
                page.HasSideBar = model.HasSideBar;
                page.Sorting = 100;

                db.Pages.Add(page);
                db.SaveChanges();
            }
            //Set TempData Message
            TempData["Success Message"] = "You have added a new page";

            //Redirect
            return RedirectToAction("AddPage");
        }

        // Post: Admin/Pages/EditPage/id
        [HttpGet]
        public ActionResult EditPage(int id)
        {
            PageVM page;

            using (Db db = new Db())
            {
                PageDTO dTO = db.Pages.Find(id);

                if (dTO == null)
                {
                    return Content("This page doesn't exist");
                }
                page = new PageVM(dTO);
            }

            return View(page);
        }

        // Post: Admin/Pages/EditPage/id
        [HttpPost]
        public ActionResult EditPage(PageVM model)
        {
            //check model state
            if (!ModelState.IsValid)
            {
                return View(model);
            }

            using (Db db = new Db())
            {
                int id = model.Id;
                string slug = string.Empty;

                if (model.Slug != "home")
                {
                    if (string.IsNullOrWhiteSpace(model.Slug))
                    {
                        slug = model.Title.Replace(" ", "-").ToLower();
                    }
                    else
                    {
                        slug = model.Slug.Replace(" ", "-").ToLower();
                    }
                }
                else
                {
                    slug = "home";
                }
                ////check if the title or slug already exists
                //if (db.Pages.Where(x => x.Id == id).Any(x => x.Title == model.Title) ||
                //    db.Pages.Where(x => x.Id == id).Any(x => x.Slug == model.Slug))
                //{
                //    ModelState.AddModelError("", "The title or slug already exists. you can click on Back to pages to view all pages");
                //    return View(model);
                //}

                PageDTO page = db.Pages.Find(id);
                page.Slug = slug;
                page.Body = model.Body;
                page.HasSideBar = model.HasSideBar;
                db.SaveChanges();
            }
            TempData["Success Message"] = "You have edited the page";
            return RedirectToAction("EditPage");
        }

        // Get: Admin/Pages/PageDetails/id
        public ActionResult PageDetails(int id)
        {
            PageVM model;

            using (Db db = new Db())
            {
                PageDTO page = db.Pages.Find(id);
                if (page == null)
                {
                    return Content("This page doesn't exist");
                }

                model = new PageVM(page);
            }
            return View(model);
        }

        // Get: Admin/Pages/DeletePage/id
        public ActionResult DeletePage(int id)
        {
            using (Db db = new Db())
            {
                PageDTO page = db.Pages.Find(id);

                if (page == null)
                {
                    return Content("This page doesn't exist");
                }
                db.Pages.Remove(page);

                db.SaveChanges();
            }
            return RedirectToAction("Index");
        }

        // Post: Admin/Pages/ReoderPages
        [HttpPost]
        public void ReorderPages(int[] id)
        {
            using (Db db = new Db())
            {
                // Set initial count
                int count = 1;  

                // Declare PageDTO
                PageDTO dto;

                // Set sorting for each page
                foreach (var pageId in id)
                {
                    dto = db.Pages.Find(pageId);
                    dto.Sorting = count;
                    db.SaveChanges();
                    count++;
                }
            }
        }

        // Get: Admin/Pages/EditSidebar
        public ActionResult EditSidebar()
        {
            SidebarVM model;
            using (Db db=new Db() )
            {
                SidebarDTO dto= db.SideBar.Find(1);
                model = new SidebarVM(dto);
            }
            return View(model);
        }

        // Post: Admin/Pages/EditSidebar
        [HttpPost]
        public ActionResult EditSidebar(SidebarVM sidebarVM)
        {
            using (Db db = new Db())
            {
                SidebarDTO dto = db.SideBar.Find(sidebarVM.Id);
                dto.Body = sidebarVM.Body;
                db.SaveChanges();
            }
            TempData["Success Message"] = "You have edited the sidebar";
            return RedirectToAction("EditSidebar");
        }
    }
}