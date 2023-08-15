using System.Data.SqlClient;
using System.Runtime.CompilerServices;

namespace Projeto_ControleEstoque.DAL
{
	public class Conexao
	{
		static string connectionString = "Data Source=DESKTOP-NKP3RKN\\SQLEXPRESS01;Initial Catalog=ControleEstoque_db;Integrated Security=True;";
		static SqlConnection connection;
		public static SqlConnection StartConnetion()
		{
			connection = new SqlConnection(connectionString);
			connection.Open();
			return connection;
		}
		public static void EndConnetion()
		{
			connection.Close();
		}
	}
}
