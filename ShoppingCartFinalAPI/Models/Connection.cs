using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Configuration;


namespace ShoppingCartFinalAPI.Models
{
    public class Connection
    {


        // Order order = new Order();
        SqlConnection con = new SqlConnection("server=AYSE-PC;database=ShoppingCart;integrated security=true");



        bool flag = false;


        MemberUserObject muser = new MemberUserObject();


        public void AddEmpDetails(MemberUserObject EmpDetails)
        {
            try
            {

                con.Open();
                SqlCommand command = new SqlCommand("INSERT INTO ShoppingCart.Users (u_name,u_adress,u_id,u_password,u_email) VALUES (" + EmpDetails.u_name + "," + EmpDetails.u_adress + ", " + EmpDetails.u_id + "," + EmpDetails.u_password + "," + EmpDetails.u_email + "); ", con);
                flag = Convert.ToBoolean(command.ExecuteScalar());

                if (flag)
                {
                    Console.WriteLine("welcome");
                }

            }
            catch
            {
                throw;
            }
            finally
            {
                con.Dispose();
                con.Close();
            }


        }

        public int IsUserExist(MemberUserObject user)
        {
            bool flag = false;

            con.Open();
            SqlCommand command = new SqlCommand("Select u_id From Users Where u_name='" + user.u_name + "' And u_password='" + user.u_password + "'", con);

            return Convert.ToInt32(command.ExecuteScalar());
        }

        internal bool IsValid(string u_name, string u_password)
        {
            throw new NotImplementedException();
        }


        public List<ProductModel> Product()
        {

            con.Open();

            SqlCommand cmd = new SqlCommand("SELECT * FROM Product", con);
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            DataTable dt = new DataTable();
            da.Fill(dt);
            List<ProductModel> products = new List<ProductModel>();
            SqlDataReader reader = cmd.ExecuteReader();
            foreach (DataRow row in dt.Rows)
            {

                while (reader.Read())
                {
        
                    int id = 0;
                    double price = 0;

                    
                    id = Convert.ToInt32(reader.GetInt32(0));
                    string name = reader.GetString(1);
                    string detail = reader.GetString(2);
                 
                    price = Convert.ToDouble(reader.GetString(3));
                    string currency = reader.GetString(4);
                    products.Add(new ProductModel() { Id = id, ProductName = name, detail = detail, price = price, currency = currency });
                }

            }
            return products;
             }

        public List<Order> OrderPage()
        {

            con.Open();

            SqlCommand cmd = new SqlCommand("select OrderData.Order_id as orderId , OrderData.Total ,OrderItem.itemId as itemId, p.product_name, p.product_detail, p.product_price, p.currency from OrderItem"
                +" INNER JOIN OrderData  ON OrderItem.OrderId = OrderData.Order_id"
                +" INNER JOIN PRODUCT p ON OrderItem.itemId = p.Id; ", con);

            SqlDataAdapter da = new SqlDataAdapter(cmd);
            DataTable dt = new DataTable();
            da.Fill(dt);
            List<Order> order = new List<Order>();
            SqlDataReader reader = cmd.ExecuteReader();
            while (reader.Read())
                 {
                double price = 0;
                double total=0;
                total = Convert.ToDouble(reader.GetString(1));
                string name = reader.GetString(3);
                string detail = reader.GetString(4);
                price = Convert.ToDouble(reader.GetString(5));
                string currency = reader.GetString(6);

                order.Add(new Order() { total = total, name = name, detail = detail, price = price, currency = currency });
            }

            return order;
  
        }
        public int OrderData(int[] ItemId,string total)
        {
            con.Open();
            Order order = new Order();
            double newtotal = Convert.ToDouble(total);
            SqlCommand command = new SqlCommand("INSERT INTO OrderData(Total) VALUES (" + newtotal + "); SELECT @@IDENTITY; ", con);
            int ID = Convert.ToInt32(command.ExecuteScalar());
           
            for (int i = 0; i < ItemId.Length; i++)
            {
                int y = ItemId[i];
                SqlCommand command2 = new SqlCommand("INSERT INTO OrderItem(OrderId,itemId) VALUES (" + ID + "," + ItemId[i] + "); ", con);
                flag = Convert.ToBoolean(command2.ExecuteScalar());

            }

            con.Close();

     
         return ID;
        }
       
      
    }
}  