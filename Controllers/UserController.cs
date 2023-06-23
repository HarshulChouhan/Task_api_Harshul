using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;


namespace Task_api_Harshul.Controllers
{
    [RoutePrefix("api/user")]
    public class UserController : ApiController
    {

        [HttpPost]
        [Route("signUp")]
        // POST api/<controller>
        public ResultVO AddUser(UserVO objUser)
        {
            ResultVO resultVO = new ResultVO();

            try
            {
                UserDAO objDAO = new UserDAO();
                objDAO.AddUser(objUser);
                resultVO.data.Add("message", "Sign up successfully");
                return resultVO;
            }
            catch (Exception ex)
            {
                resultVO.errorMessage = ex.Message;
                return resultVO;

            }

        }

        [HttpPost]
        [Route("login")]
        // POST api/<controller>
        public ResultVO LoginUser(UserVO objUser)
        {
            ResultVO resultVO = new ResultVO();

            try
            {
                UserDAO objDAO = new UserDAO();
                bool isLogin = objDAO.LoginUser(objUser);
                resultVO.data.Add("isLogin", isLogin);
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