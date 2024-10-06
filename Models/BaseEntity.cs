using System.ComponentModel.DataAnnotations;

namespace ProjetoBacharelatoFilas.Models
{
	public class BaseEntity
	{
		[Key] 
		public int Id { get; set; }

		public DateTime  DataCriacao { get; set; }=DateTime.Now;
		public DateTime DataAlteracao { get; set;}=DateTime.Now;	


	}
}
