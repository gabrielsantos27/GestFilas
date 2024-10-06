using Microsoft.AspNetCore.Identity;
using ProjetoBacharelatoFilas.Models;

namespace ProjetoBacharelatoFilas.Identity
{
    public class AspNetUser:IdentityUser
    {
        public int FuncionarioId { get; set; }
        public Funcionario? Funcionario { get; set; }
    }
}
