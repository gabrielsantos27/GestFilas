using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using ProjetoBacharelatoFilas.Consts;
using ProjetoBacharelatoFilas.Models;

namespace ProjetoBacharelatoFilas.Mappings
{
	public class AtendimentoPedidoMapping : IEntityTypeConfiguration<AtendimentoPedido>
	{
		public void Configure(EntityTypeBuilder<AtendimentoPedido> builder)
		{
			builder.ToTable($"{Prefix.TB}{nameof(AtendimentoPedido)}");
			builder.HasKey(c => c.Id);
			builder.Property(c => c.DataCriacao).HasColumnType("date");
			builder.Property(c => c.DataAlteracao).HasColumnType("date");
	
		}
	}
}
