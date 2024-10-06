namespace ProjetoBacharelatoFilas.Models
{
    public class AtendimentoPedido : BaseEntity
    {
        public int PedidoServicoId { get; set; }
        public int FuncionarioId { get; set; }
        public PedidoServico? PedidoServico { get; set; }
        public Funcionario? Funcionario { get; set; }

    }
    public class ModeloSenha
    {
        public Guid Id { get; set; }=Guid.NewGuid();    
        public string Senha { get; set; } = "000";
        public DateTime Data { get; set; }= DateTime.Now;   
    }
}
