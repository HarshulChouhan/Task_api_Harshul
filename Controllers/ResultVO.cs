using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Task_api_Harshul.Controllers
{
    public class ResultVO
    {
        public Dictionary<string, Object> data { get; set; }
        public string errorMessage { get; set; }
        
        public ResultVO ()
        {
            data = new Dictionary<string, object>();
        }
    }
}