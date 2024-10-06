using ProjetoBacharelatoFilas.Helpers.Enum;

namespace ProjetoBacharelatoFilas.Models
{
	public class Servico: BaseEntity
	{
        public string NomeServico { get; set; } = string.Empty;
        public Estado Estado { get; set; } = Estado.Ativo;
		public IEnumerable<PedidoServico>? PedidoServicos { get; set; }
	}
}
