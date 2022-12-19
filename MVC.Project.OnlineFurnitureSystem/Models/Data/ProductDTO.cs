using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace MVC.Project.OnlineFurnitureSystem.Models.Data
{
    [Table("tblProducts")]
    public class ProductDTO
    {
        [Key]
        public int Id { get; set; }
        public string Name { get; set; }
        
        public string Description { get; set; }
        public decimal Price { get; set; }
        [StringLength(100)]
        public string CategoryName { get; set; }
        public int CategoryId { get; set; }
        [StringLength(100)]
        public string ImageName { get; set; }
        public string Slug { get; set; }

        //public bool? New { get; set; }
        //public int? QuantityInStock { get; set; }
        //public int? Discount { get; set; }
        //[StringLength(50)]
        //public string Style { get; set; }
        //public int? Likes { get; set; }

        [ForeignKey("CategoryId")]
        public virtual CategoryDTO Category { get; set; }
    }
}