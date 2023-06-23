using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Task_api_Harshul.Controllers
{
    public class ProductVO
    {
        public string ProductName { get; set; }
        public string ImageName { get; set; }
        public string ImagePath { get; set; }
        public int Sku { get; set; }
        public string Description  { get; set; }
        public int Quantity  { get; set; }   
        public int ProductId { get; set; }
    }
}