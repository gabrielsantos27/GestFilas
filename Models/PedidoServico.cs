using System.ComponentModel.DataAnnotations;

namespace ProjetoBacharelatoFilas.Models
{
	public class PedidoServico:BaseEntity
    {
		public int ServicoId { get; set; }
		//public int PedidoId { get; set; }
        //public int EstudanteId { get; set; }

        [Display(Name = "Senha do Pedido")]
        public string SenhaPedido { get; set; } = string.Empty;

        public string NomeCompleto { get; set; } = string.Empty;
        public string? Email { get; set; } = string.Empty;
        public string Telefone { get; set; } = string.Empty;
        public string NumeroIdentidade { get; set; } = string.Empty;
        public string? Curso { get; set; }
        public Servico? Servico { get; set; }
        public IEnumerable<AtendimentoPedido>? AtendimentoPedidos { get; set; }
    }
}
