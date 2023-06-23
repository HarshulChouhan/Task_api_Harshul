using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.SqlClient;
using System.Data;

namespace Task_api_Harshul.Controllers
{
    public class UserDAO
    {
        internal void AddUser(UserVO objUser)
        {
            string connString = "data source=localhost;initial catalog = Product_Test; persist security info = True; Integrated Security = SSPI;";
            SqlConnection conn = new SqlConnection(connString);
            try
            {
                SqlCommand cmd = new SqlCommand("sp_user", conn);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@UserName", objUser.UserName);
                cmd.Parameters.AddWithValue("@Password", objUser.Password);
                conn.Open();
                int i = cmd.ExecuteNonQuery();               

            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
            finally
            {
                conn.Close();
                conn.Dispose();
            }
        }

        public bool LoginUser(UserVO objUser)
        {
            var isSuccess = false;
            string connString = "data source=localhost;initial catalog = Product_Test; persist security info = True; Integrated Security = SSPI;";
            SqlConnection conn = new SqlConnection(connString);
            try
            {
                string query = string.Format("Select * From UserMaster Where UserName = '{0}' and UserPassword = '{1}'", objUser.UserName, objUser.Password);
                SqlCommand cmd = new SqlCommand(query, conn);
                SqlDataReader reader1;
                conn.Open();
                reader1 = cmd.ExecuteReader();
                if(reader1.Read())
                {
                    isSuccess = true;
                }
                return isSuccess;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
            finally
            {
                conn.Close();
                conn.Dispose();
            }
        }

    }
}