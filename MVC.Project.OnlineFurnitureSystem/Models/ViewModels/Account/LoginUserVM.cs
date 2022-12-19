using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace MVC.Project.OnlineFurnitureSystem.Models.ViewModels.Account
{
    public class LoginUserVM
    {
        [Required]
        [Display(Name="User Name")]
        public string UserName { get; set; }

        [Required]
        [DataType(DataType.Password)]
        public string password { get; set; }

        [Required]
        [Display(Name = "Remember me")]
        public bool RememberMe { get; set; }
    }
}