using ProjetoBacharelatoFilas.Models;

namespace ProjetoBacharelatoFilas.Repositories
{
    public interface IPedidoServicoRepository
    {
        Task<bool> Adicionar(PedidoServico pedidoServico);
        Task<bool> Editar(PedidoServico pedidoServico);
        Task<bool> Eliminar(int id);
        Task<PedidoServico> BuscarPedidoServicoAsync(int id);
        Task<IEnumerable<PedidoServico>> Listar(CancellationToken token = default);
    }

}
