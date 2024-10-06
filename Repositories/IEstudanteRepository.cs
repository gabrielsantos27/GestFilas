using ProjetoBacharelatoFilas.Models;

namespace ProjetoBacharelatoFilas.Repositories
{
    public interface IEstudanteRepository
    {
        Task<bool> Adicionar(Estudante estudante);
        Task<bool> Editar(Estudante estudante);
        Task<bool> Eliminar(int id);
        Task<Estudante> BuscarEstudante(int id);
        Task<IEnumerable<Estudante>> Listar(CancellationToken token = default);
    }

}
