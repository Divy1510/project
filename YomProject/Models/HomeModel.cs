using System.Data.SqlClient;
using System.Data;
using Microsoft.Data.SqlClient;

namespace yom_web.Models
{
    public class HomeModel
    {

        public string name { get; set; }

        public string email { get; set; }

        public string password { get; set; }

        SqlConnection con = new SqlConnection("Data Source = .\\SQLEXPRESS; Database =  ADMIN; User Id=sa; password=123;");

        public int insert(string name, string email, string password)
        {
            SqlCommand cmd = new SqlCommand("insert into register(name , email , password )values('" + name + "','" + email + "','" + password + "')", con);
            con.Open();

            return cmd.ExecuteNonQuery();
        }

        public DataSet select(string email, string password)
        {
            SqlCommand cmd = new SqlCommand("select * from [dbo].[register] where email = '" + email + "' and password = '" + password + "'", con);
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            DataSet ds = new DataSet();
            da.Fill(ds);
            return ds;
        }
    }
}
