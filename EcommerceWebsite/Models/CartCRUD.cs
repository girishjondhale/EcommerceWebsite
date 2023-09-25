using System.Data.SqlClient;

namespace EcommerceWebsite.Models
{
    public class CartCRUD
    {
        SqlConnection con;
        SqlCommand cmd;
        SqlDataReader dr;
        IConfiguration configuration;
        public CartCRUD(IConfiguration configuration)
        {
            this.configuration = configuration;
            con = new SqlConnection(this.configuration.GetConnectionString("defaultConnection"));
        }
        public int AddTOCart(Cart cart)
        {
            int result = 0;

            string qry = "insert into Cart values (@id,@userid,@qunatity)";
            cmd = new SqlCommand(qry, con);
            cmd.Parameters.AddWithValue("@id", cart.Id);
            cmd.Parameters.AddWithValue("@userid", cart.Uid);
            cmd.Parameters.AddWithValue("@qunatity", cart.Quantity);

            con.Open();
            result = cmd.ExecuteNonQuery();
            con.Close();

            return result;

        }
        public List<Product> ViewCart(int uid)
        {
            List<Product> products = new List<Product>();
            string qry = "select p.*, c.quantity,c.cartid from product p join Cart c on c.id=p.id where c.userid=@userid";
            cmd = new SqlCommand(qry, con);
            cmd.Parameters.AddWithValue("@userid", uid);
            con.Open();
            dr = cmd.ExecuteReader();
            if (dr.HasRows)
            {
                while (dr.Read())
                {
                    Product p = new Product();
                    p.Id = Convert.ToInt32(dr["id"]);
                    p.Name = dr["name"].ToString();
                    p.Price = Convert.ToInt32(dr["price"]);
                    p.Imageurl = dr["imageUrl"].ToString();
                    p.Id = Convert.ToInt32(dr["id"]);
                    p.Quantity = Convert.ToInt32(dr["quantity"]);
                    p.CartId = Convert.ToInt32(dr["cartid"]);
                    products.Add(p);
                }
            }
            return products;
        }
        public int DeleteCart(int CartId)
        {
            int result = 0;

            string qry = " delete from Cart where cartid=@cartid";
            cmd = new SqlCommand(qry, con);
            cmd.Parameters.AddWithValue("@cartid", CartId);

            con.Open();
            result = cmd.ExecuteNonQuery();
            con.Close();

            return result;

        }

    }
}
    

