using Microsoft.EntityFrameworkCore;
using ProjetoBacharelatoFilas.Context;
using ProjetoBacharelatoFilas.Models;

namespace ProjetoBacharelatoFilas.Repositories
{
    public class PedidoServicoRepository : IPedidoServicoRepository
    {
        private readonly AppDbContext _context;
        public PedidoServicoRepository(AppDbContext context) => _context = context ?? throw new ArgumentNullException(nameof(context));
        public async Task<bool> Adicionar(PedidoServico pedidoServico)
        {
            await _context.PedidoServicos.AddAsync(pedidoServico);

            return await _context.SaveChangesAsync() > 0;
          
        }

        public async Task<PedidoServico> BuscarPedidoServicoAsync(int id)
        {
            return await _context.PedidoServicos.Include(c=>c.Servico).FirstOrDefaultAsync(c => c.Id == id);
        }

        public async Task<bool> Editar(PedidoServico pedidoServico)
        {
            _context.PedidoServicos.Update(pedidoServico);

            return await _context.SaveChangesAsync() > 0;
        }

        public async Task<bool> Eliminar(int id)
        {
            var pedidoServico = await _context.PedidoServicos.FindAsync(id);

            if (pedidoServico is null)
                return pedidoServico is null;

            _context.PedidoServicos.Remove(pedidoServico);

            return await _context.SaveChangesAsync() > 0;
        }

        public async Task<IEnumerable<PedidoServico>> Listar(CancellationToken token = default)
        {
            return await _context.PedidoServicos.AsNoTracking().Include(c=>c.Servico).ToListAsync(token);
        }
    }

}
