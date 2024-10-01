using Microsoft.Data.SqlClient;
using System.Data;

namespace YomProject.Models
{
    public class SliderModel
    {
        public string title {  get; set; }
        public string description { get; set; }
        public IFormFile image { get; set; }



        SqlConnection con = new SqlConnection("Data Source = .\\SQLEXPRESS; Database =  ADMIN; User Id=sa; password=123;TrustServerCertificate=True");

        public int insert(string title, string description, string filename)
        {
            SqlCommand cmd = new SqlCommand("insert into slider(title , description , image)values('" + title + "','" + description + "','" + filename  + "')", con);
            con.Open();
            
            return cmd.ExecuteNonQuery();
        }

        public DataSet select()
        {
            SqlCommand cmd = new SqlCommand("select * from [dbo].[slider]", con);
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            DataSet ds = new DataSet();
            da.Fill(ds);
            return ds;
        }

        public int Delete(int id)
        {
            SqlCommand cmd = new SqlCommand("delete from [dbo].[slider] where id = ' " + id + " '", con);
            con.Open();
            return cmd.ExecuteNonQuery();
        }

        public DataSet update(int id)
        {
            SqlCommand cmd = new SqlCommand("select * from [dbo].[slider] where id = '"+ id +"' ",con);
            SqlDataAdapter da = new SqlDataAdapter( cmd);
            DataSet ds = new DataSet();
            da.Fill(ds);
            return ds;
        }

        public int update_data(int id , string title , string description , string filename)
        {
            SqlCommand cmd = new SqlCommand("update [dbo].[slider] set title = '"+ title +"' , description = '"+ description + "' , image = '" + filename +"' where id = '"+ id +"'", con);
            con.Open();

            return cmd.ExecuteNonQuery();
        }

        
    }
}
