using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using ProjetoBacharelatoFilas.Helpers.Enum;
using ProjetoBacharelatoFilas.Identity;
using ProjetoBacharelatoFilas.Models;

namespace ProjetoBacharelatoFilas.Context
{
    public class AppDbContext : IdentityDbContext<AspNetUser>
    {
        public DbSet<Estudante>? Estudantes { get; set; }
        public DbSet<Funcionario>? Funcionarios { get; set; }
        public DbSet<ModeloSenha>? ModeloSenhas { get; set; }
        public DbSet<Servico>? Servicos { get; set; }
        public DbSet<PedidoServico>? PedidoServicos { get; set; }
        public DbSet<AtendimentoPedido>? AtendimentoPedidos { get; set; }

        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
        {

        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {

            base.OnModelCreating(modelBuilder);
            modelBuilder.ApplyConfigurationsFromAssembly(typeof(AppDbContext).Assembly);

            modelBuilder.Entity<Servico>().HasData(
                new Servico
                {
                    Id=1,
                    NomeServico = "Pedido de Declaração Sem Notas",
                    Estado = Estado.Ativo,
                    DataCriacao = DateTime.Now,
                    DataAlteracao = DateTime.Now
                },new Servico
                {
                    Id = 2,
                    NomeServico = "Pedido de Declaração Com Notas",
                    Estado = Estado.Ativo,
                    DataCriacao = DateTime.Now,
                    DataAlteracao = DateTime.Now
                },new Servico
                {
                    Id = 3,
                    NomeServico = "Pagamento de Propina",
                    Estado = Estado.Ativo,
                    DataCriacao = DateTime.Now,
                    DataAlteracao = DateTime.Now
                }
                );

            modelBuilder.Entity<Estudante>().HasData(
               new Estudante
               {
                   Id = 1,
                   NomeCompleto = "Gabriel Santos",
                   Email = "gabriel.saraivah27@gmail.com",
                   Telefone = "943316083",
                   NumeroIdentidade ="005813194LA045",
                   Curso = "Informatica",
                   DataCriacao = DateTime.Now,
                   DataAlteracao = DateTime.Now
               }, new Estudante
               {
                   Id = 2,
                   NomeCompleto = "Moises Mavinga",
                   Email = "moises.mavinga17@gmail.com",
                   Telefone = "939910403",
                   NumeroIdentidade = "006660681UE043",
                   Curso = "Informatica",
                   DataCriacao = DateTime.Now,
                   DataAlteracao = DateTime.Now
               }
               );
        }


    }
}
