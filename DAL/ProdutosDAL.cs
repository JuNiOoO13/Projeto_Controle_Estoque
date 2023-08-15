using System.Data.SqlClient;
using System.Reflection.Metadata.Ecma335;
using Microsoft.AspNetCore.Identity;
using Projeto_ControleEstoque.Models;

namespace Projeto_ControleEstoque.DAL
{
	public class ProdutosDAL
	{
		static SqlConnection connection;

		public static List<Produto> dbSelect()
		{
			Produto produto;
			List<Produto> produtos = new List<Produto>();
			SqlCommand command;

			connection = Conexao.StartConnetion();
			command = new SqlCommand("SELECT * FROM Products", connection);
			using (SqlDataReader data =  command.ExecuteReader())
			{
				while(data.Read())
				{
					produto = new Produto()
					{
						Id = data.GetInt32(0),
						Nome = data.GetString(1),
						DataInclusao = data.GetDateTime(2),
						Categoria = data.GetString(3),
						Quantidade = data.GetInt32(4)

					};
					produtos.Add(produto);
				}
			}
			return produtos;

		}
		public static void dbInsert(Produto produto)
		{
			connection = Conexao.StartConnetion();
			SqlCommand command = new SqlCommand(
				"INSERT INTO Products" +
				"(Nome,DataInclusao, Categoria, Quantidade)" +
				"VALUES(" +
				$"'{produto.Nome}'," +
				$"'{produto.DataInclusao}'," +
				$"'{produto.Categoria}'," +
				$"{produto.Quantidade})",
				connection
				);

			command.ExecuteNonQuery();
			Conexao.EndConnetion();
		}
		
		public static void dbDelete(int id)
		{
			connection = Conexao.StartConnetion();
			SqlCommand command = new SqlCommand($"DELETE FROM Products where Id = {id}", connection);
			command.ExecuteNonQuery();
			Conexao.EndConnetion();
		}

		public static void dbUpdate(Produto produto)
		{
			List<string> valores = new List<string>();
			if (produto.Nome != null)
				valores.Add($"Nome = '{produto.Nome}'");
				
			valores.Add($"Categoria = '{produto.Categoria}'");

			if (produto.Quantidade != null)
				valores.Add($"Quantidade = {produto.Quantidade}");


			string query = "UPDATE Products SET ";

			for (int i = 0; i < valores.Count; i++)
			{
				query += valores[i];
				if (valores.Count - 1 == i)
				{
					break;
				}
				else query += ",";
			}

			query += $" WHERE Id = {produto.Id}";
			connection = Conexao.StartConnetion();
			SqlCommand command = new SqlCommand(query, connection);
			command.ExecuteNonQuery();
		}
			
		
	}
}
