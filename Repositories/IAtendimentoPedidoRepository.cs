using Microsoft.EntityFrameworkCore;
using ProjetoBacharelatoFilas.Context;
using ProjetoBacharelatoFilas.Models;

namespace ProjetoBacharelatoFilas.Repositories
{
    public interface IAtendimentoPedidoRepository
    {
        Task<bool> Adicionar(AtendimentoPedido atendimento);
        Task<bool> Editar(AtendimentoPedido atendimento);
        Task<bool> Eliminar(int id);
        Task<IEnumerable<AtendimentoPedido>> Listar(CancellationToken token=default);
    }
    public class AtendimentoPedidoRepository : IAtendimentoPedidoRepository
    {
        private readonly AppDbContext _context;
        public AtendimentoPedidoRepository(AppDbContext context) => _context = context ?? throw new ArgumentNullException(nameof(context));
        public async Task<bool> Adicionar(AtendimentoPedido atendimento)
        {
            await _context.AtendimentoPedidos.AddAsync(atendimento);

            return await _context.SaveChangesAsync() > 0;
        }

        public async Task<bool> Editar(AtendimentoPedido atendimento)
        {
            _context.AtendimentoPedidos.Update(atendimento);

            return await _context.SaveChangesAsync() > 0;
        }

        public async Task<bool> Eliminar(int id)
        {
            var servico = await _context.Servicos.FindAsync(id);

            if (servico is null)
                return servico is null;

            _context.Servicos.Remove(servico);

            return await _context.SaveChangesAsync() > 0;
        }

        public async Task<IEnumerable<AtendimentoPedido>> Listar(CancellationToken token = default)
        {
            return await _context.AtendimentoPedidos.AsNoTracking().ToListAsync(token);

        }
    }

}
