using MVC.Project.OnlineFurnitureSystem.Models.Data;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MVC.Project.OnlineFurnitureSystem.Models.ViewModels.Pages
{
    public class SidebarVM
    {
        public SidebarVM()
        {

        }
        public SidebarVM(SidebarDTO sidbarDTO)
        {
            Id = sidbarDTO.Id;
            Body = sidbarDTO.Body;
        }
        public int Id { get; set; }
        [DataType(DataType.MultilineText)]
        [Display(Name ="Sidebar")]
        [AllowHtml]
        public string Body { get; set; }
    }
}