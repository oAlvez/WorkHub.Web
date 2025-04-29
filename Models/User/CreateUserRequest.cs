using System.ComponentModel.DataAnnotations;

namespace WorkHub.Web.Models.User;

public class CreateUserRequest
{
    [Required]
    [Display(Name = "Nome completo")]
    public string FullName { get; set; }

    [Required]
    [Display(Name = "Apelido")]
    public string ShortName { get; set; }

    [Required]
    [EmailAddress]
    [Display(Name = "E-mail")]
    public string Email { get; set; }

    [Required]
    [DataType(DataType.Password)]
    [Display(Name = "Senha")]
    public string Password { get; set; }
}
