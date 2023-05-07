using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Banner.Models
{
    public class ServiceOrders
    {
        public int Id { get; set; }
        public string ServiceName { get; set; }
        public string ServiceOrderId { get; set; }
        public int ServicePrice { get; set; }
        public string ImageUrl { get; set; }
        public string Address { get; set; }
        public int UserId { get; set; }
        public string ServiceProvider { get; set; }
        public string Message { get; set; }
    }

}