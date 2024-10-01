using Microsoft.Data.SqlClient;
using System.Data;

namespace YomProject.Models
{
	public class ThemeSeModel
	{

		public string heading { get; set; }

		public string title { get; set; }
		public string description { get; set; }

		public IFormFile image { get; set; }

		SqlConnection con = new SqlConnection("Data Source = .\\SQLEXPRESS; Database =  ADMIN; User Id=sa; password=123;TrustServerCertificate=True");

		public int insert(string heading, string title, string description, string filname)
		{
			SqlCommand cmd = new SqlCommand("insert into theme2(Heading , title , description , image)values('" + heading + "' , '" + title + "','" + description + "','" + filname + "')", con);
			con.Open();


			return cmd.ExecuteNonQuery();
		}

		public DataSet select()
		{
			SqlCommand cmd = new SqlCommand("select * from [dbo].[theme2]", con);
			SqlDataAdapter da = new SqlDataAdapter(cmd);
			DataSet ds = new DataSet();
			da.Fill(ds);
			return ds;
		}

		public int Delete_the(int id)
		{
			SqlCommand cmd = new SqlCommand("delete from [dbo].[theme2] where id =  + id ", con);
			con.Open();
			return cmd.ExecuteNonQuery();
		}

		public DataSet update_the(int id)
		{
			SqlCommand cmd = new SqlCommand("select * from [dbo].[theme2] where id = '" + id + "' ", con);
			SqlDataAdapter da = new SqlDataAdapter(cmd);
			DataSet ds = new DataSet();
			da.Fill(ds);
			return ds;
		}

		public int update_the(int id, string heading, string title, string description, string filename)
		{
			SqlCommand cmd = new SqlCommand("update [dbo].[theme2] set  Heading = '" + heading + "' , Title = '" + title + "' , Description = '" + description + "' , Image = '" + filename + "'  where id = '" + id + "'", con);
			con.Open();

			return cmd.ExecuteNonQuery();
		}
	}
}
