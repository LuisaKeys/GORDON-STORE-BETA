using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace MVC.Project.OnlineFurnitureSystem.Models.Data
{
    [Table("tblSideBar")]
    public class SidebarDTO
    {
        [Key]
        public int Id { get; set; }
        public string Body { get; set; }
    }
}