using Microsoft.Data.SqlClient;
using System.Data;

namespace YomProject.Models
{
    public class ThemeModel
    {
        public string heading { get; set; }

        public string title { get; set; }
        public string description { get; set; }

        public IFormFile image {  get; set; }

        SqlConnection con = new SqlConnection("Data Source = .\\SQLEXPRESS; Database =  ADMIN; User Id=sa; password=123;TrustServerCertificate=True");

        public int insert(string heading , string title, string description , string filname)
        {
            SqlCommand cmd = new SqlCommand("insert into theme(Heading , title , description , image)values('" + heading + "' , '" + title + "','" + description + "','"+filname+"')", con);
            con.Open();


            return cmd.ExecuteNonQuery();
        }

        public DataSet select()
        {
            SqlCommand cmd = new SqlCommand("select * from [dbo].[theme]", con);
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            DataSet ds = new DataSet();
            da.Fill(ds);
            return ds;
        }

        public int Delete_t(int id)
        {
            SqlCommand cmd = new SqlCommand("delete from [dbo].[theme] where id =  + id ", con);
            con.Open();
            return cmd.ExecuteNonQuery();
        }

        public DataSet update_t(int id)
        {
            SqlCommand cmd = new SqlCommand("select * from [dbo].[theme] where id = '" + id + "' ", con);
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            DataSet ds = new DataSet();
            da.Fill(ds);
            return ds;
        }

        public int update_data(int id , string heading, string title, string description , string filename)
        {
            SqlCommand cmd = new SqlCommand("update [dbo].[theme] set  Heading = '" + heading + "' , Title = '" + title + "' , Description = '" + description + "' , Image = '"+ filename +"'  where id = '" + id + "'", con);
            con.Open();

            return cmd.ExecuteNonQuery();
        }
    }
}
