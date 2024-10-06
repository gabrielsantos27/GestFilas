using Microsoft.EntityFrameworkCore;
using ProjetoBacharelatoFilas.Context;
using ProjetoBacharelatoFilas.Models;

namespace ProjetoBacharelatoFilas.Repositories
{
    public class FuncionarioRepository : IFuncionarioRepository
    {
        private readonly AppDbContext _context;
        public FuncionarioRepository(AppDbContext context) => _context = context ?? throw new ArgumentNullException(nameof(context));
        public async Task<bool> Adicionar(Funcionario funcionario)
        {
            await _context.Funcionarios.AddAsync(funcionario);

            return await _context.SaveChangesAsync() > 0;
        }

        public async Task<Funcionario> BuscarFuncionario(int id)
        {
            return await _context.Funcionarios.FirstOrDefaultAsync(c => c.Id == id);
        }

        public async Task<bool> Editar(Funcionario funcionario)
        {
            _context.Funcionarios.Update(funcionario);

            return await _context.SaveChangesAsync() > 0;
        }

        public async Task<bool> Eliminar(int id)
        {
            var funcionario = await _context.Funcionarios.FindAsync(id);

            if (funcionario is null)
                return funcionario is null;

            _context.Funcionarios.Remove(funcionario);

            return await _context.SaveChangesAsync() > 0;
        }

        public async Task<IEnumerable<Funcionario>> Listar(CancellationToken token = default)
        {
            return await _context.Funcionarios.AsNoTracking().ToListAsync(token);
        }

        public async Task<int> MaxFuncionario()
        {
            return await _context.Funcionarios.MaxAsync(c => c.Id);
        }
    }

}
