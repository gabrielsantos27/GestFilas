namespace ProjetoBacharelatoFilas.Models
{
	public class Estudante: BaseEntity
	{
		public string NomeCompleto { get; set; }=string.Empty;
        public string? Email { get; set; } = string.Empty;
		public string Telefone { get; set; } = string.Empty;
		public string NumeroIdentidade { get; set; } = string.Empty;
		public string? Curso { get; set; }
        public IEnumerable<Pedido>? Pedidos { get; set; } 
    }
}
