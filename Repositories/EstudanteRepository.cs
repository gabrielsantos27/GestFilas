using Microsoft.EntityFrameworkCore;
using ProjetoBacharelatoFilas.Context;
using ProjetoBacharelatoFilas.Helpers.Enum;
using ProjetoBacharelatoFilas.Models;

namespace ProjetoBacharelatoFilas.Repositories
{
    public class EstudanteRepository : IEstudanteRepository
    {
        private readonly AppDbContext _context;
        public EstudanteRepository(AppDbContext context) => _context = context ?? throw new ArgumentNullException(nameof(context));
        public async Task<bool> Adicionar(Estudante estudante)
        {
            await _context.Estudantes.AddAsync(estudante);

            return await _context.SaveChangesAsync() > 0;
        }

        public async Task<bool> Editar(Estudante estudante)
        {
            _context.Estudantes.Update(estudante);

            return await _context.SaveChangesAsync() > 0;
        }

        public async Task<bool> Eliminar(int id)
        {
            var estudante = await _context.Estudantes.FindAsync(id);

            if (estudante is null)
                return estudante is null;

            _context.Estudantes.Remove(estudante);

            return await _context.SaveChangesAsync() > 0;
        }

        public async Task<Estudante> BuscarEstudante(int id)
        {
            return await _context.Estudantes.FirstOrDefaultAsync(c => c.Id == id);
        }

        public async Task<IEnumerable<Estudante>> Listar(CancellationToken token = default)
        {
            return await _context.Estudantes.AsNoTracking().ToListAsync(token);
        }
    }

}
