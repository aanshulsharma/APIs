using Banner.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Banner.Models
{
    public class InvenModel
    {
        public int Id { get; set; }
        public string ProductName { get; set; }
        public string ProductCategory { get; set; }
        public int ProductPrice { get; set; }
        public string ImageUrl { get; set; }
        public string ProductDescription_Long { get; set; }
        public string ProductDescription_Short { get; set; }
        public int StockQuantity { get; set; }
        public string StockStatus { get; set; }
        public int ProductWeight { get; set; }
        public string ProductDimension { get; set; }
        public int DisPrice { get; set; }
        public int QTY { get; set; } 
        public string Brand { get; set; }
        public int CategoryId { get; set; }
        public int BrandId { get; set; }
        public string Seller { get; set; }
        public string Message { get; set; }
    }
    
}