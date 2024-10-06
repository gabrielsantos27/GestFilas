using System.ComponentModel.DataAnnotations;

namespace ProjetoBacharelatoFilas.Models
{
	public class Pedido : BaseEntity
	{
        
        public int EstudanteId { get; set; }

		[Display(Name = "Senha do Pedido")]
		public string SenhaPedido { get; set; } = string.Empty;
        
        [Display(Name ="Nome do estudante")]
        public Estudante? Estudante { get; set; }

        public IEnumerable<PedidoServico>? PedidoServicos { get; set; }

    }
}
