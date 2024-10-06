using System.ComponentModel.DataAnnotations;

namespace ProjetoBacharelatoFilas.ViewModels
{
    public class LoginViewModel
    {
        [Required(ErrorMessage = "Informe o nome")]
        [Display(Name = "Nome")]
        public string Email { get; set; }
        [Required(ErrorMessage = "Informe a senha")]
        [Display(Name = "senha")]
        [DataType(DataType.Password)]
        public string Password { get; set; }
        public string ReturnUrl { get; set; }
    }
}
