using Microsoft.Data.SqlClient;
using System.Data;

namespace YomProject.Models
{
	public class ClientModel
	{

        public IFormFile image { get; set; }



        SqlConnection con = new SqlConnection("Data Source = .\\SQLEXPRESS; Database =  ADMIN; User Id=sa; password=123;TrustServerCertificate=True");

        public int insert(string filename)
        {
            SqlCommand cmd = new SqlCommand("insert into client(image)values('" + filename + "')", con);
            con.Open();

            return cmd.ExecuteNonQuery();
        }


        public DataSet select()
        {
            SqlCommand cmd = new SqlCommand("select * from [dbo].[client]", con);
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            DataSet ds = new DataSet();
            da.Fill(ds);
            return ds;
        }

        public int Delete_cli(int id)
        {
            SqlCommand cmd = new SqlCommand("delete from [dbo].[client] where id = ' " + id + " '", con);
            con.Open();
            return cmd.ExecuteNonQuery();
        }

        public DataSet update_cli(int id)
        {
            SqlCommand cmd = new SqlCommand("select * from [dbo].[client] where id = '" + id + "' ", con);
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            DataSet ds = new DataSet();
            da.Fill(ds);
            return ds;
        }

        public int update_data(int id, string filename)
        {
            SqlCommand cmd = new SqlCommand("update [dbo].[client] set image = '" + filename + "' where id = '" + id + "'", con);
            con.Open();

            return cmd.ExecuteNonQuery();
        }
    }
}
