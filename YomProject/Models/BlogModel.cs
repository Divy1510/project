using Microsoft.Data.SqlClient;
using System.Data;

namespace YomProject.Models
{
    public class BlogModel
    {
        public string title { get; set; }
        public string name { get; set; }
        public string date { get; set; }
        public string country { get; set; }
        public string description { get; set; }
        public IFormFile image { get; set; }



        SqlConnection con = new SqlConnection("Data Source = .\\SQLEXPRESS; Database =  ADMIN; User Id=sa; password=123;TrustServerCertificate=True");

        public int insert(string filename, string title, string name, string date, string country, string description)
        {
            SqlCommand cmd = new SqlCommand("insert into bclassic(image , title, name , date , country , description )values('" + filename + "','" + title + "','" + name + "','" + date + "','" + country + "', ' " + description + " ' )", con);
            con.Open();

            return cmd.ExecuteNonQuery();
        }


        public DataSet select()
        {
            SqlCommand cmd = new SqlCommand("select * from [dbo].[bclassic]", con);
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            DataSet ds = new DataSet();
            da.Fill(ds);
            return ds;
        }

        public int delete_clas(int id)
        {
            SqlCommand cmd = new SqlCommand("delete from [dbo].[bclassic] where id = ' " + id + " '", con);
            con.Open();
            return cmd.ExecuteNonQuery();
        }

        public DataSet update_clas(int id)
        {
            SqlCommand cmd = new SqlCommand("select * from [dbo].[bclassic] where id = '" + id + "' ", con);
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            DataSet ds = new DataSet();
            da.Fill(ds);
            return ds;
        }

        public int update_clas(int id, string filename, string title, string name, string date, string country, string description)
        {
            SqlCommand cmd = new SqlCommand("update [dbo].[bclassic] set image = '" + filename + "' , title = '" + title + "' , name = '" + name + "' , daet = '" + date + "'  , country = '" + country + "' ,, description = '" + description + "' ,  where id = '" + id + "'", con);
            con.Open();

            return cmd.ExecuteNonQuery();
        }
    }
}
