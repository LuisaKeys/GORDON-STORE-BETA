using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace MVC.Project.OnlineFurnitureSystem.Models.Data
{
    [Table("tblCategories")]
    public class CategoryDTO
    {
        [Key]
        public int Id { get; set; }
        [StringLength(50)]
        public string Slug { get; set; }
        [StringLength(150)]
        public string Name { get; set; }
        public int Sorting { get; set; }
    }
}