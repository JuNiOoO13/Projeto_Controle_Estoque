using System.Globalization;

namespace Projeto_ControleEstoque.Models
{
	public class Produto
	{
		public int Id { get; set; }
		public string? Nome { get; set; }
		public string? Categoria { get; set;}
		public DateTime DataInclusao {  get; set; }
		public int? Quantidade { get; set;}
	}
}
