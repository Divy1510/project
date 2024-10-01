using Microsoft.Data.SqlClient;
using System.Data;

namespace YomProject.Models
{
	public class TeamModel
	{

		public string name { get; set; }

		public string post { get; set; }

		public string discription { get; set; }

		public IFormFile image { get; set; }

		SqlConnection con = new SqlConnection("Data Source = .\\SQLEXPRESS ; Database = ADMIN; User Id=sa; Password=123; TrustServerCertificate=True");


		public int insert(string name, string post, string discription, string filename)
		{
			SqlCommand cmd = new SqlCommand("insert into team(name , post, discription ,image)values('" + name + "','" + post + "', '" + discription + "','" + filename + "')", con);
			con.Open();

			return cmd.ExecuteNonQuery();
		}
		public DataSet select()
		{
			SqlCommand cmd = new SqlCommand("select * from [dbo].[team]", con);
			SqlDataAdapter da = new SqlDataAdapter(cmd);
			DataSet ds = new DataSet();
			da.Fill(ds);
			return ds;
		}

		public int Delete(int id)
		{
			SqlCommand cmd = new SqlCommand("delete from [dbo].[team] where id = '" + id + "' ", con);
			con.Open();
			return cmd.ExecuteNonQuery();
		}

		public DataSet update_team(int id)
		{
			SqlCommand cmd = new SqlCommand("select * from [dbo].[team] where id = '" + id + "' ", con);
			SqlDataAdapter da = new SqlDataAdapter(cmd);
			DataSet ds = new DataSet();
			da.Fill(ds);
			return ds;
		}

		public int update_data(int id, string name, string post, string discription, string filename)
		{
			SqlCommand cmd = new SqlCommand("update [dbo].[team] set name = '" + name + "', post = '" + post + "' , discription = '" + discription + "', image = '" + filename + "' where id = '" + id + "'", con);
			con.Open();

			return cmd.ExecuteNonQuery();
		}
	}
}
