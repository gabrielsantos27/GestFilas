using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using ProjetoBacharelatoFilas.Consts;
using ProjetoBacharelatoFilas.Models;

namespace ProjetoBacharelatoFilas.Mappings
{
	public class PedidoServicoMapping : IEntityTypeConfiguration<PedidoServico>
	{
		public void Configure(EntityTypeBuilder<PedidoServico> builder)
		{
			builder.ToTable($"{Prefix.TB}{nameof(PedidoServico)}");
			builder.HasKey(c => c.Id);
			builder.Property(c => c.DataCriacao).HasColumnType("date");
			builder.Property(c => c.DataAlteracao).HasColumnType("date");

			//Relacionamento 1:M
			builder.HasMany(c => c.AtendimentoPedidos)
				   .WithOne(c => c.PedidoServico)
				   .HasForeignKey(c => c.PedidoServicoId)
				   .OnDelete(DeleteBehavior.Cascade);
		}
	}
}
