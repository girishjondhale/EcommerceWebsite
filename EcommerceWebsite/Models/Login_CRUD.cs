using Microsoft.Win32;
using System.Data.SqlClient;

namespace EcommerceWebsite.Models
{
    public class Login_CRUD
    {

        SqlConnection con;
        SqlCommand cmd;
        SqlDataReader dr;
        //DataTable dt;
        IConfiguration configuration;

        public Login_CRUD(IConfiguration configuration)
        {
            this.configuration = configuration;
            con = new SqlConnection(this.configuration.GetConnectionString("defaultConnection"));
        }

        public Ragister GetLogin(string user_name, string password)
        {

            Ragister rag = new Ragister();
            string qry = "select * from ragister where user_name=@user_name and password=@password";
            cmd = new SqlCommand(qry, con);
            //cmd.Parameters.AddWithValue("@userid",reg.UserId);
            cmd.Parameters.AddWithValue("@user_name", user_name);
            cmd.Parameters.AddWithValue("@password", password);
            con.Open();
            dr = cmd.ExecuteReader();
            if (dr.HasRows)
            {
                while (dr.Read())
                {
                    rag.UId = Convert.ToInt32(dr["uid"]);

                    rag.UserName = dr["user_name"].ToString();
                    rag.RoleId = Convert.ToInt32(dr["role_id"]);
                }
            }
            con.Close();
            return rag;
        }
    }
}
