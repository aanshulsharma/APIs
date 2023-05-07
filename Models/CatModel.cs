using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Banner.Models
{
    public class CatModel
    {
        public int CategoryId { get; set; }
        public string CategoryName { get; set; }
        public string Alias { get; set; }
        public string Image_Url { get; set; }
        public int PId { get; set; }
    }
}