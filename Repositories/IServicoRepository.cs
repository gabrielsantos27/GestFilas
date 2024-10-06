using ProjetoBacharelatoFilas.Models;
using System.Reflection.Metadata;

namespace ProjetoBacharelatoFilas.Repositories
{
    public interface IServicoRepository
    {
        Task<bool> Adicionar(Servico servico);
        Task<bool> Editar(Servico servico);
        Task<bool> Eliminar(int id);
        Task<Servico> BuscarServico(int id);
        Task<IEnumerable<Servico>> Listar(CancellationToken token=default);
    }
    public interface IModeloSenhaRepository
    {
        Task<ModeloSenha> Adicionar();
        Task<bool> Editar(ModeloSenha modelo);
        Task<bool> Eliminar(int id);
        Task<ModeloSenha> BuscarModeloSenha(int id);
        Task<IEnumerable<ModeloSenha>> Listar(CancellationToken token = default);
    }



}
