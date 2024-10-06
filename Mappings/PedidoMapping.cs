using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using ProjetoBacharelatoFilas.Consts;
using ProjetoBacharelatoFilas.Models;

namespace ProjetoBacharelatoFilas.Mappings
{
	//public class PedidoMapping : IEntityTypeConfiguration<Pedido>
	//{
	//	public void Configure(EntityTypeBuilder<Pedido> builder)
	//	{
	//		builder.ToTable($"{Prefix.TB}{nameof(Pedido)}");
	//		builder.HasKey(c => c.Id);
	//		builder.Property(c => c.SenhaPedido).IsRequired().HasMaxLength(6);
	//		builder.Property(c => c.DataCriacao).HasColumnType("date");
	//		builder.Property(c => c.DataAlteracao).HasColumnType("date");

	//		//Relacionamento 1:M
	//		builder.HasMany(c => c.PedidoServicos)
	//			   .WithOne(c => c.Pedido)
	//			   .HasForeignKey(c => c.PedidoId)
	//			   .OnDelete(DeleteBehavior.Cascade);

	//	}
	//}
}
