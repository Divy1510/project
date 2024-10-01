using Microsoft.Data.SqlClient;
using System.Data;

namespace YomProject.Models
{
	public class BlogSlider
	{
		public IFormFile image { get; set; }

		public string tempdata { get; set; }

		SqlConnection con = new SqlConnection("Data Source = .\\SQLEXPRESS; Database =  ADMIN; User Id=sa; password=123;TrustServerCertificate=True");

		public int insert(string filename)
		{
			SqlCommand cmd = new SqlCommand("insert into blog_slider(image)values('" + filename + "')", con);
			con.Open();

			return cmd.ExecuteNonQuery();
		}
		public DataSet select()
		{
			SqlCommand cmd = new SqlCommand("select * from [dbo].[blog_slider]", con);
			SqlDataAdapter da = new SqlDataAdapter(cmd);
			DataSet ds = new DataSet();
			da.Fill(ds);
			return ds;
		}

		public int Delete(int id)
		{
			SqlCommand cmd = new SqlCommand("delete from [dbo].[blog_slider] where id = '" + id + "' ", con);
			con.Open();
			return cmd.ExecuteNonQuery();
		}


		public DataSet update(int id)
		{
			SqlCommand cmd = new SqlCommand("select * from [dbo].[blog_slider] where id = '" + id + "' ", con);
			SqlDataAdapter da = new SqlDataAdapter(cmd);
			DataSet ds = new DataSet();
			da.Fill(ds);
			return ds;
		}

		public int update_data(int id, string filename)
		{
			SqlCommand cmd = new SqlCommand("update [dbo].[blog_slider] set image = '" + filename + "' where id = '" + id + "'", con);
			con.Open();

			return cmd.ExecuteNonQuery();
		}
	}
}
