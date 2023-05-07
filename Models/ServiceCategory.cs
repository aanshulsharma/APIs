using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Banner.Models
{
    public class ServiceCategory
    {
        public int CategoryId { get; set; }
        public string ServiceCategoryName { get; set; }
        public string Alias { get; set; }
        public string ImageUrl { get; set; }
        public int PId { get; set; }
    }
}