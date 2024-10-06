using Microsoft.EntityFrameworkCore;
using ProjetoBacharelatoFilas.Context;
using ProjetoBacharelatoFilas.Helpers.Enum;
using ProjetoBacharelatoFilas.Models;

namespace ProjetoBacharelatoFilas.Repositories
{

    public class ModeloSenhaRepository : IModeloSenhaRepository
    {
        private readonly AppDbContext _context;

        public ModeloSenhaRepository(AppDbContext context)
        {
            _context = context;
        }

        public async Task<ModeloSenha> Adicionar()
        {
            // Check if any ModeloSenhas exist
            var hasExisting = _context.ModeloSenhas.Any();

            ModeloSenha maxRes=new ModeloSenha();
            if (hasExisting)
            {
                // Get the last record with order by Id
                maxRes.Senha =  _context.ModeloSenhas.Max(c => c.Senha);
            }
            else
            {
                // Create a new ModeloSenha with default values (optional)
                maxRes = new ModeloSenha();
                maxRes.Id = Guid.NewGuid(); ;
                maxRes.Senha = "001"; // Or set other default values
            }

            // Check if the current date matches the last record's date
            var isSameDate = maxRes.Data.ToShortDateString() == DateTime.Now.ToShortDateString();

            if (isSameDate)
            {
                var result= (Convert.ToInt32(maxRes.Senha) + 1);
                maxRes.Senha = "00" + result;
                maxRes.Id = Guid.NewGuid();
            }
            else
            {
                maxRes.Senha = "001";
                maxRes.Id = Guid.NewGuid();
            }


            await _context.ModeloSenhas.AddAsync(maxRes);

            await _context.SaveChangesAsync();

            return maxRes;
        }


        public Task<ModeloSenha> BuscarModeloSenha(int id)
        {
            throw new NotImplementedException();
        }

        public Task<bool> Editar(ModeloSenha modelo)
        {
            throw new NotImplementedException();
        }

        public Task<bool> Eliminar(int id)
        {
            throw new NotImplementedException();
        }

        public Task<IEnumerable<ModeloSenha>> Listar(CancellationToken token = default)
        {
            throw new NotImplementedException();
        }
    }
    public class ServicoRepository : IServicoRepository
    {
        private readonly AppDbContext _context;
        public ServicoRepository(AppDbContext context)=>_context=context??throw new ArgumentNullException(nameof(context));
        public async Task<bool> Adicionar(Servico servico)
        {
            await _context.Servicos.AddAsync(servico);

            return await _context.SaveChangesAsync() > 0;
            
        }

        public async Task<bool> Editar(Servico servico)
        {
            _context.Servicos.Update(servico);

            return await _context.SaveChangesAsync() > 0;
        }

        public async Task<bool> Eliminar(int id)
        {
            var servico= await _context.Servicos.FindAsync(id);

            if (servico is null)
                return servico is null;

            _context.Servicos.Remove(servico);

            return await _context.SaveChangesAsync() > 0;
        }
        public async Task<Servico> BuscarServico(int id)
        {
            return await _context.Servicos.FirstOrDefaultAsync(c => c.Id == id);
        }

        public async Task<IEnumerable<Servico>> Listar(CancellationToken token = default)
        {
            return await _context.Servicos.AsNoTracking().ToListAsync(token);
        }
    }
    
}
