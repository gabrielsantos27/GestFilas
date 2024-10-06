namespace ProjetoBacharelatoFilas.Models
{
	public class Funcionario : BaseEntity
	{
		public string NomeCompleto { get; set; } = string.Empty;
		public string? Email { get; set; } = string.Empty;
		public string Telefone { get; set; } = string.Empty;
		public string NumeroIdentidade { get; set; } = string.Empty;
		public IEnumerable<AtendimentoPedido>? AtendimentoPedidos { get; set; }
	}
}
