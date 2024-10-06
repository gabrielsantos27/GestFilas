using ProjetoBacharelatoFilas.Models;

namespace ProjetoBacharelatoFilas.Repositories
{
    public interface IFuncionarioRepository
    {
        Task<bool> Adicionar(Funcionario funcionario);
        Task<bool> Editar(Funcionario funcionario);
        Task<bool> Eliminar(int id);
        Task<Funcionario> BuscarFuncionario(int id);
        Task<int> MaxFuncionario();
        Task<IEnumerable<Funcionario>> Listar(CancellationToken token = default);
    }

}
