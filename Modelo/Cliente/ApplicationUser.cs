using System.ComponentModel.DataAnnotations;
using System;
using System.Security.Claims;
using System.Threading.Tasks;
using Microsoft.AspNet.Identity.EntityFramework;
using Microsoft.AspNet.Identity;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity;

namespace Modelo.Cliente
{

    //public enum TipoSexo
    //{
    //    Masculino,
    //    Feminino
    //}

    //public class ApplicationUser : IdentityUser
    //{

    //    [Required]
    //    [Display(Name = "Nome")]
    //    public string Nome { get; set; }

    //    [Required]
    //    [Display(Name = "CPF")]
    //    public string Cpf { get; set; }

    //    [Required]
    //    [Display(Name = "Sexo")]
    //    public TipoSexo Sexo { get; set; }

    //    [Required]
    //    [Display(Name = "Data de nascimento")]
    //    public DateTime data_nasc { get; set; }

    //    [Required]
    //    [Display(Name = "País")]
    //    public string Pais { get; set; }

    //    [Required]
    //    [Display(Name = "Estado")]
    //    public string Estado { get; set; }

    //    [Required]
    //    [Display(Name = "Cidade")]
    //    public string Cidade { get; set; }

    //    [Required]
    //    [Display(Name = "CEP")]
    //    public int Cep { get; set; }

    //    [Required]
    //    [Display(Name = "Bairro")]
    //    public int Bairro { get; set; }

    //    [Required]
    //    [Display(Name = "Rua")]
    //    public string Rua { get; set; }

    //    [Required]
    //    [Display(Name = "Complemento")]
    //    public string Complemento { get; set; }

    //    public async Task<ClaimsIdentity> GenerateUserIdentityAsync(UserManager<ApplicationUser> manager)
    //    {
    //        // Observe que a authenticationType deve corresponder a uma definida em CookieAuthenticationOptions.AuthenticationType
    //        var userIdentity = await manager.CreateIdentityAsync(this, DefaultAuthenticationTypes.ApplicationCookie);
    //        // Adicionar declarações do usuário personalizadas aqui
    //        return userIdentity;
    //    }
    //}

    //public class ApplicationDbContext : IdentityDbContext<ApplicationUser>
    //{
    //    public ApplicationDbContext()
    //        : base("DefaultConnection", throwIfV1Schema: false)
    //    {
    //    }

    //    public static ApplicationDbContext Create()
    //    {
    //        return new ApplicationDbContext();
    //    }
    //}
}