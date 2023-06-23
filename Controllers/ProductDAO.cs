using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace Task_api_Harshul.Controllers
{
    public class ProductDAO
    {
        public void AddProduct(ProductVO objProduct)
        {
            string connString = "data source=localhost;initial catalog = Product_Test; persist security info = True; Integrated Security = SSPI;";
            SqlConnection conn = new SqlConnection(connString);
            try
            {
                SqlCommand cmd = new SqlCommand("sp_product", conn);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@ProductName", objProduct.ProductName);
                cmd.Parameters.AddWithValue("@ImageName", objProduct.ImageName);
                cmd.Parameters.AddWithValue("@ImagePath", objProduct.ImagePath);
                cmd.Parameters.AddWithValue("@Sku", objProduct.Sku);
                cmd.Parameters.AddWithValue("@Description", objProduct.Description);
                cmd.Parameters.AddWithValue("@Quantity", objProduct.Quantity);
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

        internal void DeleteProduct(int productId)
        {
            string connString = "data source=localhost;initial catalog = Product_Test; persist security info = True; Integrated Security = SSPI;";
            SqlConnection conn = new SqlConnection(connString);
            try
            {
                string query = string.Format("Delete From ProductMaster Where ProductId = {0}", productId);
                SqlCommand cmd = new SqlCommand(query, conn);
                cmd.CommandType = CommandType.Text;
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

        internal void EditProduct(ProductVO objProd)
        {
            string connString = "data source=localhost;initial catalog = Product_Test; persist security info = True; Integrated Security = SSPI;";
            SqlConnection conn = new SqlConnection(connString);
            try
            {
                string query = string.Format(@"Update ProductMaster Set ProductName = '{1}', ImageName = '{2}', ImagePath = '{3}', Sku = {4} ,
			ProductDescription = '{5}' , Quantity = {6}   Where ProductId = {0}", objProd.ProductId, objProd.ProductName, objProd.ImageName, objProd.ImagePath
            , objProd.Sku, objProd.Description, objProd.Quantity);
                SqlCommand cmd = new SqlCommand(query, conn);
                cmd.CommandType = CommandType.Text;
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

        public List<ProductVO> ProductList()
        {
            string connString = "data source=localhost;initial catalog = Product_Test; persist security info = True; Integrated Security = SSPI;";
            SqlConnection conn = new SqlConnection(connString);
            List<ProductVO> productList = new List<ProductVO>();
            try
            {
                string query = string.Format("Select ProductId, ProductName ,  ImageName , ImagePath , Sku ,ProductDescription, Quantity From ProductMaster");                    
                SqlCommand cmd = new SqlCommand(query, conn);
                SqlDataReader reader1;
                conn.Open();
                reader1 = cmd.ExecuteReader();
                if (reader1.Read())
                {
                    ProductVO prodVO = new ProductVO();
                    prodVO.ProductId = reader1.IsDBNull(0) ? 0 : Convert.ToInt32(reader1.GetValue(0));
                    prodVO.ProductName = reader1.GetValue(1).ToString();
                    prodVO.ImageName = reader1.GetValue(2).ToString();
                    prodVO.ImagePath = reader1.GetValue(3).ToString();
                    prodVO.Sku  = reader1.IsDBNull(4) ? 0 : Convert.ToInt32(reader1.GetValue(4));
                    prodVO.Description = reader1.GetValue(5).ToString();
                    prodVO.Quantity = Convert.ToInt32(reader1.GetValue(6));
                    productList.Add(prodVO);
                }
                return productList;
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