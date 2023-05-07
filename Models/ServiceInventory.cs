using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Banner.Models
{
    public class ServiceInventory
    {

        public int Id { get; set; }
        public string ProductName { get; set; }
        public string ServiceName { get; set; }
        public string ServiceCategory { get; set; }
        public int ServicePrice { get; set; }
        public string ImageUrl { get; set; }
        public string ServiceDescriptionLong { get; set; }
        public string ServiceDescriptionShort { get; set; }
        public string ServiceStatus { get; set; }
        public int DiscountPrice { get; set; }
        public string BrandName { get; set; }
        public int CategoryId { get; set; }
        public int BrandId { get; set; }
        public int AddOnId { get; set; }
        public string ServiceProvider { get; set; }
        public string Message { get; set; }

    }
}