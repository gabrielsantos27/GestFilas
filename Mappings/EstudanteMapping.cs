using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using ProjetoBacharelatoFilas.Consts;
using ProjetoBacharelatoFilas.Models;

namespace ProjetoBacharelatoFilas.Mappings
{
	//public class EstudanteMapping : IEntityTypeConfiguration<Estudante>
	//{
	//	public void Configure(EntityTypeBuilder<Estudante> builder)
	//	{
	//		builder.ToTable($"{Prefix.TB}{nameof(Estudante)}");
	//		builder.HasKey(c => c.Id);
	//		builder.Property(c => c.NomeCompleto).IsRequired().HasMaxLength(150);
	//		builder.Property(c => c.NumeroIdentidade).IsRequired().HasMaxLength(14);
	//		builder.Property(c => c.Curso).IsRequired().HasMaxLength(50);
	//		builder.Property(c => c.Telefone).IsRequired().HasMaxLength(9);
	//		builder.Property(c => c.Email).IsRequired().HasMaxLength(50);
	//		builder.Property(c => c.Telefone).IsRequired().HasMaxLength(9);
	//		builder.Property(c => c.DataCriacao).HasColumnType("date");
	//		builder.Property(c => c.DataAlteracao).HasColumnType("date");

	//		//Relacionamento 1:M
	//		builder.HasMany(c => c.Pedidos)
	//			   .WithOne(c => c.Estudante)
	//			   .HasForeignKey(c => c.EstudanteId)
	//			   .OnDelete(DeleteBehavior.Cascade);
	//	}
	//}
}
