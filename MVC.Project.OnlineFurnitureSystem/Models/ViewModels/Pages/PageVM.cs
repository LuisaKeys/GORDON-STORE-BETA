using MVC.Project.OnlineFurnitureSystem.Models.Data;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MVC.Project.OnlineFurnitureSystem.Models.ViewModels.Pages
{
    public class PageVM
    {
        public PageVM()
        {
        }
        public PageVM(PageDTO row)
        {
            Id = row.Id;
            Title = row.Title;
            Slug = row.Slug;
            Body = row.Body;
            Sorting = row.Sorting;
            HasSideBar = row.HasSideBar;
        }
        [Key]
        public int Id { get; set; }
        [Required(ErrorMessage = "You must enter the title")]
        [StringLength(50, ErrorMessage = "The title should be at most 50 characters")]
        public string Title { get; set; }
        public string Slug { get; set; }

        
        [DataType(DataType.MultilineText)]
        [AllowHtml]
        public string Body { get; set; }
        public int Sorting { get; set; }
        [Display(Name = "SideBar")]
        public bool HasSideBar { get; set; }
    }
}