using Microsoft.Data.SqlClient;
using System.Data;

namespace YomProject.Models
{
    public class AdminModel
    {
        public string email { get; set; }
        public string password { get; set; }

        SqlConnection con = new SqlConnection("Data Source = .\\SQLEXPRESS; Database =  ADMIN; User Id=sa; password=123;TrustServerCertificate=True");

        public DataSet select(string email, string password)
        {
            SqlCommand cmd = new SqlCommand("select * from [dbo].[AdminLogin] where email = '" + email + "' and password = '" + password + "'", con);
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            DataSet ds = new DataSet();
            da.Fill(ds);
            return ds;
        }
    }
}
