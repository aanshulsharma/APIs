using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Banner.Models
{
    public class Orders
    {
        public int Id { get; set; }
        public string ProductName { get; set; }
        public string OrderId { get; set; }
        public int Price { get; set; }
        public string ImageUrl { get; set; }
        public string Address { get; set; }
        public int UserId { get; set; }
        public string Seller { get; set; }
        public string Message { get; set; }
    }
}