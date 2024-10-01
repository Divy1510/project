using Microsoft.Data.SqlClient;
using System.Data;

namespace YomProject.Models
{
    public class RecentModel
    {
        public string title { get; set; }
        public string description { get; set; }
        public IFormFile image { get; set; }



        SqlConnection con = new SqlConnection("Data Source = .\\SQLEXPRESS; Database =  ADMIN; User Id=sa; password=123;TrustServerCertificate=True");

        public int insert(string title, string description , string filename)
        {
            SqlCommand cmd = new SqlCommand("insert into recent(title , description , image)values('" + title + "','" + description + "','" + filename  + "')", con);
            con.Open();

            return cmd.ExecuteNonQuery();
        }


        public DataSet select()
        {
            SqlCommand cmd = new SqlCommand("select * from [dbo].[recent]", con);
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            DataSet ds = new DataSet();
            da.Fill(ds);
            return ds;
        }

        public int Delete_re(int id)
        {
            SqlCommand cmd = new SqlCommand("delete from [dbo].[recent] where id = ' " + id + " '", con);
            con.Open();
            return cmd.ExecuteNonQuery();
        }

        public DataSet update_re(int id)
        {
            SqlCommand cmd = new SqlCommand("select * from [dbo].[recent] where id = '" + id + "' ", con);
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            DataSet ds = new DataSet();
            da.Fill(ds);
            return ds;
        }

        public int update_data(int id, string title, string description, string filename)
        {
            SqlCommand cmd = new SqlCommand("update [dbo].[recent] set title = '" + title + "' , description = '" + description + "' , image = '" + filename + "' where id = '" + id + "'", con);
            con.Open();

            return cmd.ExecuteNonQuery();
        }

    }
}
