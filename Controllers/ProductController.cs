using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace Task_api_Harshul.Controllers
{
    [RoutePrefix("api/product")]
    public class ProductController : ApiController
    {
        [HttpPost]
        [Route("add")]
        // POST api/<controller>
        public ResultVO AddProduct(ProductVO objProduct)
        {
            ResultVO resultVO = new ResultVO();

            try
            {
                ProductDAO objDAO = new ProductDAO();
                objDAO.AddProduct(objProduct);
                resultVO.data.Add("message", "Product added successfully");
                return resultVO;
            }
            catch (Exception ex)
            {
                resultVO.errorMessage = ex.Message;
                return resultVO;

            }

        }

        [HttpGet]
        [Route("delete/{productId}")]
        // POST api/<controller>
        public ResultVO DeleteProduct(int productId)
        {
            ResultVO resultVO = new ResultVO();

            try
            {
                ProductDAO objDAO = new ProductDAO();
                objDAO.DeleteProduct(productId);
                resultVO.data.Add("message", "Product deleted successfully");
                return resultVO;
            }
            catch (Exception ex)
            {
                resultVO.errorMessage = ex.Message;
                return resultVO;

            }

        }

        [HttpPost]
        [Route("edit")]
        // POST api/<controller>
        public ResultVO EditProduct(ProductVO objProduct)
        {
            ResultVO resultVO = new ResultVO();

            try
            {
                ProductDAO objDAO = new ProductDAO();
                objDAO.EditProduct(objProduct);
                resultVO.data.Add("message", "Product edited successfully");
                return resultVO;
            }
            catch (Exception ex)
            {
                resultVO.errorMessage = ex.Message;
                return resultVO;

            }

        }


        [HttpGet]
        [Route("")]
        // POST api/<controller>
        public ResultVO GetProductList()
        {
            ResultVO resultVO = new ResultVO();

            try
            {
                ProductDAO objDAO = new ProductDAO();
                List<ProductVO> productList  = objDAO.ProductList();
                resultVO.data.Add("productList", productList);
                return resultVO;
            }
            catch (Exception ex)
            {

                resultVO.errorMessage = ex.Message;
                return resultVO;

            }

        }
    }
}
