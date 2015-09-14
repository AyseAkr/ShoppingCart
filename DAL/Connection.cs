using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Configuration;
using UserObject;

namespace DAL
{
    public class Connection
    {



        SqlConnection con = new SqlConnection("server=AYSE-PC;database=ShoppingCart;integrated security=true");



        public void AddEmpDetails(MemberUserObject EmpDetails)
        {
            try
            {
                bool flag = false;
                con.Open();
                SqlCommand command = new SqlCommand("INSERT INTO ShoppingCart.Users (u_name,u_adress,u_id,u_password) VALUES ("+EmpDetails.u_name+","+ EmpDetails.u_adress+", " + EmpDetails.u_id + "," + EmpDetails.u_password +"); ", con);
                flag = Convert.ToBoolean(command.ExecuteScalar());
               
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
        public void IsUserExist(MemberUserObject EmpDetails)
        {
            bool flag = false;

            con.Open();
            SqlCommand command = new SqlCommand("Select u_name From ShoppingCart Where u_name='" + EmpDetails.u_name + "' And u_password='" + EmpDetails.u_password + "'", con);
            flag = Convert.ToBoolean(command.ExecuteScalar());
            con.Close();
            
        }

        internal bool IsValid(string u_name, string u_password)
        {
            throw new NotImplementedException();
        }
    }
}
