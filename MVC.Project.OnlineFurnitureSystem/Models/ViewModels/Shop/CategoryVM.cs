using MVC.Project.OnlineFurnitureSystem.Models.Data;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace MVC.Project.OnlineFurnitureSystem.Models.ViewModels.Shop
{
    public class CategoryVM
    {
        public CategoryVM()
        {

        }
        public CategoryVM(CategoryDTO row, int? inlineId)
        {
            Id = row.Id;
            Slug = row.Slug;
            Name = row.Name;
            Sorting = row.Sorting;
            inlineEdit = inlineId;
        }
        public int? inlineEdit { get; set; }
        public int Id { get; set; }
        public string Slug { get; set; }
        [Required]
        [Display(Name="Category Name")]
        [StringLength(maximumLength:50, ErrorMessage = "The category name must be greater than 2 characters",MinimumLength =2)]
        public string Name { get; set; }
        public int Sorting { get; set; }
    }
}