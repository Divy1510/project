using Microsoft.Data.SqlClient;
using System.Data;

namespace YomProject.Models
{
	public class Offer2Model
	{

		public string icon { get; set; }
		public string title { get; set; }
		public string description { get; set; }


		SqlConnection con = new SqlConnection("Data Source = .\\SQLEXPRESS; Database =  ADMIN; User Id=sa; password=123;TrustServerCertificate=True");

		public int insert(string icon, string title, string description)
		{
			SqlCommand cmd = new SqlCommand("insert into offer2(icon , title , description )values('" + icon + "' , '" + title + "','" + description + "')", con);
			con.Open();


			return cmd.ExecuteNonQuery();
		}

		public DataSet select()
		{
			SqlCommand cmd = new SqlCommand("select * from [dbo].[offer2]", con);
			SqlDataAdapter da = new SqlDataAdapter(cmd);
			DataSet ds2 = new DataSet();
			da.Fill(ds2);
			return ds2;
		}

		public int Delete_off(int id)
		{
			SqlCommand cmd = new SqlCommand("delete from [dbo].[offer2] where id = ' " + id + " '", con);
			con.Open();
			return cmd.ExecuteNonQuery();
		}


		public DataSet update_off(int id)
		{
			SqlCommand cmd = new SqlCommand("select * from [dbo].[offer2] where id = '" + id + "' ", con);
			SqlDataAdapter da = new SqlDataAdapter(cmd);
			DataSet ds = new DataSet();
			da.Fill(ds);
			return ds;
		}

		public int update_off(int id, string icon, string title, string description)
		{
			SqlCommand cmd = new SqlCommand("update [dbo].[offer2] set icon = '" + icon + "' ,title = '" + title + "' , description = '" + description + "' where id = '" + id + "'", con);
			con.Open();

			return cmd.ExecuteNonQuery();
		}
	}
}
