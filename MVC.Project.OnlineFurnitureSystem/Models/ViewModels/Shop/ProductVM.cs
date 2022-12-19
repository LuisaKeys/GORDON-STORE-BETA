using MVC.Project.OnlineFurnitureSystem.Models.Data;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MVC.Project.OnlineFurnitureSystem.Models.ViewModels.Shop
{
    public class ProductVM
    {
        public ProductVM()
        {
        }
        public ProductVM(ProductDTO row)
        {
            Id = row.Id;
            Name = row.Name;
            Slug = row.Slug;
            Description = row.Description;
            Price = row.Price;
            CategoryName = row.CategoryName;
            CategoryId = row.CategoryId;
            ImageName = row.ImageName;
            //New = row.New;
            //QuantityInStock = row.QuantityInStock;
            //Style = row.Style;
            //Likes = row.Likes;
            //Discount = row.Discount;
        }

        public int Id { get; set; }

        [Required(ErrorMessage = "You should enter the product name")]
        [StringLength(100)]
        [Display(Name = "Product Name")]
        [DataType(DataType.Text)]
        public string Name { get; set; }

        public string Slug { get; set; }

        [Required(ErrorMessage = "You should enter the product description")]
        [Display(Name = "Product Description")]
        [StringLength(350, ErrorMessage = "Product description should be at most 350 characters")]
        [DataType(DataType.MultilineText)]
        public string Description { get; set; }

        [Display(Name = "Product Price")]
        [DataType(DataType.Currency)]
        [Required(ErrorMessage = "You should enter the price of the product")]
        [Range(1,1000,ErrorMessage ="The price should be positive")]
        //[RegularExpression("^/d+$", ErrorMessage = "price should be like 10,50")]
        public decimal Price { get; set; }
        [Display(Name="Category Name")]
        public string CategoryName { get; set; }
        [Required]
        public int CategoryId { get; set; }
        public string ImageName { get; set; }

        //public bool? New { get; set; }

        //[Display(Name = "Available Quantity")]
        //[RegularExpression("/^d+$",ErrorMessage ="Quantity should be positive number")]
        //public int? QuantityInStock { get; set; }
        //[RegularExpression("/^d+$", ErrorMessage = "Discount should be positive number")]
        //public int? Discount { get; set; }
        //[StringLength(50)]
        //public string Style { get; set; }
        //[RegularExpression("/^d+$", ErrorMessage = "Discount should be positive number")]
        //public int? Likes { get; set; }

        public IEnumerable<SelectListItem> Categories { get; set; }
        public IEnumerable<string> GalleryImages { get; set; }
    }
}