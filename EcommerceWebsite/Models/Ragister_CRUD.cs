using Microsoft.Win32;
using System.Data;
using System.Data.SqlClient;

namespace EcommerceWebsite.Models
{
    public class Ragister_CRUD
    {
        SqlConnection con;
        SqlCommand cmd;
        SqlDataReader dr;
        DataTable dt;
        IConfiguration configuration;
        public Ragister_CRUD(IConfiguration configuration)
        {
            this.configuration = configuration;
            con = new SqlConnection(this.configuration.GetConnectionString("defaultConnection"));
        }

        public int AddRagister(Ragister rag)
        {
            int result = 0;
            string qry = "insert into ragister(first_name,last_name,gender,email,mobile_no,user_name,password,confirm_password)values(@first_name,@last_name,@gender,@email,@mobile_no,@user_name,@password,@confirm_password)";
            cmd = new SqlCommand(qry, con);
            cmd.Parameters.AddWithValue("@first_name", rag.FirstName);
            cmd.Parameters.AddWithValue("@last_name", rag.LastName);
            cmd.Parameters.AddWithValue("@gender", rag.Gender);
            cmd.Parameters.AddWithValue("@email", rag.Email);
            cmd.Parameters.AddWithValue("@mobile_no", rag.MobileNo);
            cmd.Parameters.AddWithValue("@user_name", rag.UserName);
            cmd.Parameters.AddWithValue("@password", rag.Password);
            cmd.Parameters.AddWithValue("@confirm_password", rag.ConfirmPassword);
            cmd.Parameters.AddWithValue(@"role_id", rag.RoleId);
            con.Open();
            result = cmd.ExecuteNonQuery();
            con.Close();
            return result;
        }

        public DataTable GetAllUser()
        {
            con.Open();
            cmd = new SqlCommand("select * from ragister", con);
            dr = cmd.ExecuteReader();

            if (dr.HasRows)
            {
                dt.Load(dr);
            }
            con.Close();
            return dt;
        }

    }
}
