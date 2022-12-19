using MVC.Project.OnlineFurnitureSystem.Areas.Admin.Models.ViewModels;
using MVC.Project.OnlineFurnitureSystem.Models.Data;
using MVC.Project.OnlineFurnitureSystem.Models.ViewModels;
using MVC.Project.OnlineFurnitureSystem.Models.ViewModels.Shop;
using PagedList;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Helpers;
using System.Web.Mvc;

namespace MVC.Project.OnlineFurnitureSystem.Areas.Admin.Controllers
{
    [Authorize(Roles = "Admin")]
    public class ShopController : Controller
    {
        // GET: Admin/Categories
        public ActionResult Categories(CategoryVM vM)
        {
            //Declare CategoriesVM
            List<CategoryVM> CatLstVM;

            using (Db db = new Db())
            {
                CatLstVM = db.Categories.ToArray().OrderBy(x => x.Sorting).Select(x => new CategoryVM(x, vM.Id)).ToList();
            }
            //return CategoryVMList

            return View(CatLstVM);
        }

        // GET: Admin/AddCategory
        public ActionResult AddCategory()
        {
            return View();
        }
        // Post: Admin/AddCategory
        [HttpPost]
        public ActionResult AddCategory(CategoryVM catVM)
        {
            CategoryDTO dto = new CategoryDTO();
            using (Db db = new Db())
            {
                //Check if the Category is unique or not
                if (db.Categories.Any(x => x.Name == catVM.Name))
                {
                    ModelState.AddModelError("", "This Category already exists");
                    return View(catVM);
                }
                dto.Name = catVM.Name;
                dto.Slug = catVM.Name.Replace(" ", "-").ToLower();
                dto.Sorting = 100;
                db.Categories.Add(dto);
                db.SaveChanges();
            }
            TempData["Success Message"] = "The caetgory is added successfully";
            return RedirectToAction("AddCategory");
        }
        // Post: Admin/Shop/ReoderCategories
        [HttpPost]
        public void ReoderCategories(int[] id)
        {
            using (Db db = new Db())
            {
                //intialize counter
                int count = 1;

                //Declare CategoryDTO
                CategoryDTO categoryDTO;

                //Set sorting for each Category
                foreach (var catID in id)
                {
                    categoryDTO = db.Categories.Find(catID);
                    categoryDTO.Sorting = count;
                    db.SaveChanges();
                    count++;
                }
            }
        }

        //Delete Action of  A category
        public ActionResult DeleteCategory(int id)
        {
            using (Db db = new Db())
            {
                CategoryDTO catDto = db.Categories.FirstOrDefault(x => x.Id == id);
                if (catDto != null)
                {
                    db.Categories.Remove(catDto);
                    db.SaveChanges();
                }
            }
            return RedirectToAction("Categories");
        }

        //Post: Admin/Shop/Edit/id
        [HttpPost]
        public ActionResult Edit(int id, string txtCatName)
        {
            using (Db db = new Db())
            {
                CategoryDTO oldCatDTO = db.Categories.FirstOrDefault(x => x.Id == id);
                oldCatDTO.Name = txtCatName;
                db.SaveChanges();
            }
            return RedirectToAction("Categories");
        }

        //Get: Admin/Shop/AddProduct
        [HttpGet]
        public ActionResult AddProduct()
        {
            ProductVM model = new ProductVM();

            using (Db db = new Db())
            {
                //Select all the categories from category table
                model.Categories = new SelectList(db.Categories.ToList(), "Id", "Name");
            }
            // return model
            return View(model);
        }

        //Post: Admin/Shop/AddProduct/id
        [HttpPost]
        public ActionResult AddProduct(ProductVM model, HttpPostedFileBase file)
        {
            // Check model state
            if (!ModelState.IsValid)
            {
                using (Db db = new Db())
                {
                    model.Categories = new SelectList(db.Categories.ToList(), "Id", "Name");
                    return View(model);
                }
            }

            // Make sure product name is unique
            using (Db db = new Db())
            {
                if (db.Products.Any(x => x.Name == model.Name))
                {
                    model.Categories = new SelectList(db.Categories.ToList(), "Id", "Name");
                    ModelState.AddModelError("", "That product name already exists!");
                    return View(model);
                }
            }

            // Declare product id
            int id;

            // Init and save productDTO
            using (Db db = new Db())
            {
                ProductDTO product = new ProductDTO();

                product.Name = model.Name;
                //product.Slug = model.Name.Replace(" ", "-").ToLower();
                product.Description = model.Description;
                product.Price = model.Price;
                product.CategoryId = model.CategoryId;
                //product.QuantityInStock = model.QuantityInStock;
                //product.Style = model.Style;
                //product.Likes = model.Likes;
                //product.New = model.New;
                //product.Discount = model.Discount;

                CategoryDTO catDTO = db.Categories.FirstOrDefault(x => x.Id == model.CategoryId);
                product.CategoryName = catDTO.Name;

                db.Products.Add(product);
                db.SaveChanges();

                // Get the id
                id = product.Id;
            }

            // Set TempData message
            TempData["SM"] = "You have added a product successfully";

            #region Upload Image

            // Create necessary directories
            var originalDirectory = new DirectoryInfo(string.Format("{0}Images\\Uploads", Server.MapPath(@"\")));

            var pathString1 = Path.Combine(originalDirectory.ToString(), "Products");
            var pathString2 = Path.Combine(originalDirectory.ToString(), "Products\\" + id.ToString());
            var pathString3 = Path.Combine(originalDirectory.ToString(), "Products\\" + id.ToString() + "\\Thumbs");
            var pathString4 = Path.Combine(originalDirectory.ToString(), "Products\\" + id.ToString() + "\\Gallery");
            var pathString5 = Path.Combine(originalDirectory.ToString(), "Products\\" + id.ToString() + "\\Gallery\\Thumbs");

            if (!Directory.Exists(pathString1))
                Directory.CreateDirectory(pathString1);

            if (!Directory.Exists(pathString2))
                Directory.CreateDirectory(pathString2);

            if (!Directory.Exists(pathString3))
                Directory.CreateDirectory(pathString3);

            if (!Directory.Exists(pathString4))
                Directory.CreateDirectory(pathString4);

            if (!Directory.Exists(pathString5))
                Directory.CreateDirectory(pathString5);

            // Check if a file was uploaded
            if (file != null && file.ContentLength > 0)
            {
                // Get file extension
                string ext = file.ContentType.ToLower();

                // Verify extension
                if (ext != "image/jpg" &&
                    ext != "image/jpeg" &&
                    ext != "image/pjpeg" &&
                    ext != "image/gif" &&
                    ext != "image/x-png" &&
                    ext != "image/png")
                {
                    using (Db db = new Db())
                    {
                        model.Categories = new SelectList(db.Categories.ToList(), "Id", "Name");
                        ModelState.AddModelError("", "The image was not uploaded - wrong image extension.");
                        return View(model);
                    }
                }

                // Init image name
                string imageName = file.FileName;

                // Save image name to DTO
                using (Db db = new Db())
                {
                    ProductDTO dto = db.Products.Find(id);
                    dto.ImageName = imageName;

                    db.SaveChanges();
                }

                // Set original and thumb image paths
                var path = string.Format("{0}\\{1}", pathString2, imageName);
                var path2 = string.Format("{0}\\{1}", pathString3, imageName);

                // Save original
                file.SaveAs(path);

                // Create and save thumb
                WebImage img = new WebImage(file.InputStream);
                img.Resize(130, 130);
                img.Save(path2);
            }

            #endregion
            // Redirect
            return RedirectToAction("AddProduct");
        }

        //Get: Admin/Shop/Products
        public ActionResult Products(int? page, int? catID)
        {
            //initialize list of productvm
            List<ProductVM> lstProductVM;

            //Set defualt first page
            var pageIndex = page ?? 1;

            using (Db db = new Db())
            {
                lstProductVM = db.Products.ToArray()
                               .Where(x => catID == null || catID == 0 || x.CategoryId == catID)
                               .Select(x => new ProductVM(x)).ToList();

                ViewBag.categories = new SelectList(db.Categories.ToList(), "Id", "Name");

                //set selected category
                ViewBag.selectedCat = catID.ToString();

            }

            //set pagination
            var onePageOfProducts = lstProductVM.ToPagedList(pageIndex, 3);

            ViewBag.OnePageOfProducts = onePageOfProducts;

            //return the list for the view
            return View(lstProductVM);
        }

        //Get: Admin/Shop/EditProduct/id
        [HttpGet]
        public ActionResult EditProduct(int id)
        {
            ProductVM model;
            using (Db db = new Db())
            {
                ProductDTO OldProduct = db.Products.Find(id);
                if (OldProduct == null)
                {
                    return Content("This product doesn't exist");
                }
                model = new ProductVM(OldProduct);

                model.Categories = new SelectList(db.Categories.ToList(), "Id", "Name");

                //Gallery Images
                model.GalleryImages = Directory.EnumerateFiles(Server.MapPath("~/Images/Uploads/Products/" + id + "/Gallery/Thumbs"))
                                                .Select(fn => Path.GetFileName(fn));
            }
            //return model
            return View(model);
        }

        // POST: Admin/Shop/EditProduct/id
        [HttpPost]
        public ActionResult EditProduct(ProductVM model, HttpPostedFileBase file)
        {
            // Get product id
            int id = model.Id;

            // Populate categories select list and gallery images
            using (Db db = new Db())
            {
                model.Categories = new SelectList(db.Categories.ToList(), "Id", "Name");
            }
            model.GalleryImages = Directory.EnumerateFiles(Server.MapPath("~/Images/Uploads/Products/" + id + "/Gallery/Thumbs"))
                                                .Select(fn => Path.GetFileName(fn));

            // Check model state
            if (!ModelState.IsValid)
            {
                return View(model);
            }

            // Make sure product name is unique
            using (Db db = new Db())
            {
                if (db.Products.Where(x => x.Id != id).Any(x => x.Name == model.Name))
                {
                    ModelState.AddModelError("", "That product name is taken!");
                    return View(model);
                }
            }

            // Update product
            using (Db db = new Db())
            {
                ProductDTO dto = db.Products.Find(id);

                dto.Name = model.Name;
                //dto.Slug = model.Name.Replace(" ", "-").ToLower();
                dto.Description = model.Description;
                dto.Price = model.Price;
                dto.CategoryId = model.CategoryId;
                dto.ImageName = model.ImageName;

                CategoryDTO catDTO = db.Categories.FirstOrDefault(x => x.Id == model.CategoryId);
                dto.CategoryName = catDTO.Name;

                db.SaveChanges();
            }

            // Set TempData message
            TempData["SM"] = "You have edited the product!";

            #region Image Upload

            // Check for file upload
            if (file != null && file.ContentLength > 0)
            {

                // Get extension
                string ext = file.ContentType.ToLower();

                // Verify extension
                if (ext != "image/jpg" &&
                    ext != "image/jpeg" &&
                    ext != "image/pjpeg" &&
                    ext != "image/gif" &&
                    ext != "image/x-png" &&
                    ext != "image/png")
                {
                    using (Db db = new Db())
                    {
                        ModelState.AddModelError("", "The image was not uploaded - wrong image extension.");
                        return View(model);
                    }
                }

                // Set uplpad directory paths
                var originalDirectory = new DirectoryInfo(string.Format("{0}Images\\Uploads", Server.MapPath(@"\")));

                var pathString1 = Path.Combine(originalDirectory.ToString(), "Products\\" + id.ToString());
                var pathString2 = Path.Combine(originalDirectory.ToString(), "Products\\" + id.ToString() + "\\Thumbs");

                // Delete files from directories

                DirectoryInfo di1 = new DirectoryInfo(pathString1);
                DirectoryInfo di2 = new DirectoryInfo(pathString2);

                foreach (FileInfo file2 in di1.GetFiles())
                    file2.Delete();

                foreach (FileInfo file3 in di2.GetFiles())
                    file3.Delete();

                // Save image name

                string imageName = file.FileName;

                using (Db db = new Db())
                {
                    ProductDTO dto = db.Products.Find(id);
                    dto.ImageName = imageName;

                    db.SaveChanges();
                }

                // Save original and thumb images

                var path = string.Format("{0}\\{1}", pathString1, imageName);
                var path2 = string.Format("{0}\\{1}", pathString2, imageName);

                file.SaveAs(path);

                WebImage img = new WebImage(file.InputStream);
                img.Resize(130, 130);
                img.Save(path2);
            }

            #endregion

            // Redirect
            return RedirectToAction("EditProduct");
        }

        // GET: Admin/Shop/DeleteProduct/id
        public ActionResult DeleteProduct(int id)
        {
            // Delete product from DB
            using (Db db = new Db())
            {
                ProductDTO dto = db.Products.Find(id);
                db.Products.Remove(dto);

                db.SaveChanges();
            }

            // Delete product folder
            var originalDirectory = new DirectoryInfo(string.Format("{0}Images\\Uploads", Server.MapPath(@"\")));
            string pathString = Path.Combine(originalDirectory.ToString(), "Products\\" + id.ToString());

            if (Directory.Exists(pathString))
                Directory.Delete(pathString, true);

            // Redirect
            return RedirectToAction("Products");
        }

        // POST: Admin/Shop/SaveGalleryImages
        [HttpPost]
        public void SaveGalleryImages(int id)
        {
            // Loop through files
            foreach (string fileName in Request.Files)
            {
                // Init the file
                HttpPostedFileBase file = Request.Files[fileName];

                // Check it's not null
                if (file != null && file.ContentLength > 0)
                {
                    // Set directory paths
                    var originalDirectory = new DirectoryInfo(string.Format("{0}Images\\Uploads", Server.MapPath(@"\")));

                    string pathString1 = Path.Combine(originalDirectory.ToString(), "Products\\" + id.ToString() + "\\Gallery");
                    string pathString2 = Path.Combine(originalDirectory.ToString(), "Products\\" + id.ToString() + "\\Gallery\\Thumbs");

                    // Set image paths
                    var path = string.Format("{0}\\{1}", pathString1, file.FileName);
                    var path2 = string.Format("{0}\\{1}", pathString2, file.FileName);

                    // Save original and thumb

                    file.SaveAs(path);
                    WebImage img = new WebImage(file.InputStream);
                    img.Resize(130, 130);
                    img.Save(path2);
                }
            }
        }

        // POST: Admin/Shop/DeleteImage
        [HttpPost]
        public void DeleteImage(int id, string imageName)
        {
            string fullPath1 = Request.MapPath("~/Images/Uploads/Products/" + id.ToString() + "/Gallery/" + imageName);
            string fullPath2 = Request.MapPath("~/Images/Uploads/Products/" + id.ToString() + "/Gallery/Thumbs/" + imageName);

            if (System.IO.File.Exists(fullPath1))
                System.IO.File.Delete(fullPath1);

            if (System.IO.File.Exists(fullPath2))
                System.IO.File.Delete(fullPath2);
        }

        //// GET: Admin/Shop/Orders
        //public ActionResult Orders()
        //{
        //    // Init list of OrdersForAdminVM
        //    List<OrdersForAdminVM> ordersForAdmin = new List<OrdersForAdminVM>();

        //    using (Db db = new Db())
        //    {
        //        var ordersssss = db.Orders.ToList();
        //        // Init list of OrderVM
        //        List<OrderVM> orders = db.Orders.ToArray().Select(x => new OrderVM(x)).ToList();


        //        // Loop through list of OrderVM
        //        foreach (var order in orders)
        //        {

        //            // Init product dict
        //            Dictionary<string, int> productsAndQty = new Dictionary<string, int>();

        //            // Declare total
        //            decimal total = 0m;

        //            // Init list of OrderDetailsDTO
        //            List<OrderDetailsDTO> orderDetailsList = db.OrderDetails.Where(X => X.OrderId == order.OrderId).ToList();

        //            // Loop through list of OrderDetailsDTO
        //            foreach (var orderDetails in orderDetailsList)
        //            {
        //                var userID = orderDetails.UserId;
        //                UserDTO user = db.Users.Where(x => x.Id == userID).FirstOrDefault();
        //                string username = user.Username;
        //                // Get product
        //                ProductDTO product = db.Products.Where(x => x.Id == orderDetails.ProductId).FirstOrDefault();

        //                // Get product price
        //                decimal price = product.Price;

        //                // Get product name
        //                string productName = product.Name;

        //                // Add to product dict
        //                productsAndQty.Add(productName, orderDetails.Quantity);

        //                // Get total
        //                total += orderDetails.Quantity * price;
        //                // Add to ordersForAdminVM list
        //                ordersForAdmin.Add(new OrdersForAdminVM()
        //                {
        //                    OrderNumber = order.OrderId,
        //                    Username = username,
        //                    Total = total,
        //                    ProductsAndQty = productsAndQty,
        //                    CreatedAt = order.CreatedAt
        //                });
        //            }


        //        }
        //    }
        //    // Return view with OrdersForAdminVM list
        //    return View(ordersForAdmin);
        //}


        // GET: Admin/Shop/Orders

        public ActionResult Orders()
        {
            // Init list of OrdersForAdminVM
            List<OrdersForAdminVM> ordersForAdmin = new List<OrdersForAdminVM>();

            using (Db db = new Db())
            {
                // Init list of OrderVM
                List<OrderVM> orders = db.Orders.ToArray().Select(x => new OrderVM(x)).ToList();

                // Loop through list of OrderVM
                foreach (var order in orders)
                {
                    // Init product dict
                    Dictionary<string, int> productsAndQty = new Dictionary<string, int>();

                    // Declare total
                    decimal total = 0m;

                    // Init list of OrderDetailsDTO
                    List<OrderDetailsDTO> orderDetailsList = db.OrderDetails.Where(X => X.OrderId == order.OrderId).ToList();

                    // Get username
                    UserDTO user = db.Users.Where(x => x.Id == order.UserId).FirstOrDefault();
                    string username = user.Username;

                    // Loop through list of OrderDetailsDTO
                    foreach (var orderDetails in orderDetailsList)
                    {
                        // Get product
                        ProductDTO product = db.Products.Where(x => x.Id == orderDetails.ProductId).FirstOrDefault();

                        // Get product price
                        decimal price = product.Price;

                        // Get product name
                        string productName = product.Name;

                        // Add to product dict
                        productsAndQty.Add(productName, orderDetails.Quantity);

                        // Get total
                        total += orderDetails.Quantity * price;
                    }

                    // Add to ordersForAdminVM list
                    ordersForAdmin.Add(new OrdersForAdminVM()
                    {
                        OrderNumber = order.OrderId,
                        Username = username,
                        Total = total,
                        ProductsAndQty = productsAndQty,
                        CreatedAt = order.CreatedAt
                    });

                }
            }
            // Return view with OrdersForAdminVM list
            return View(ordersForAdmin);
        }
    }
}