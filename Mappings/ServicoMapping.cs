using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using ProjetoBacharelatoFilas.Consts;
using ProjetoBacharelatoFilas.Models;

namespace ProjetoBacharelatoFilas.Mappings
{
	public class ServicoMapping : IEntityTypeConfiguration<Servico>
	{
		public void Configure(EntityTypeBuilder<Servico> builder)
		{
			builder.ToTable($"{Prefix.TB}{nameof(Servico)}");
			builder.HasKey(c => c.Id);
			builder.Property(c => c.NomeServico).IsRequired().HasMaxLength(150);
			builder.Property(c => c.Estado).IsRequired();
			builder.Property(c => c.DataCriacao).HasColumnType("date");
			builder.Property(c => c.DataAlteracao).HasColumnType("date");

			//Relacionamento 1:M
			builder.HasMany(c => c.PedidoServicos)
				   .WithOne(c => c.Servico)
				   .HasForeignKey(c => c.ServicoId)
				   .OnDelete(DeleteBehavior.Cascade);
		}
	}
}
