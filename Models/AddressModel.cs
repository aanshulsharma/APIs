using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Banner.Models
{
    public class AddressModel
    {
        public int AddressId  { get; set; }
        public string Name { get; set; }
        public string PhoneNumber { get; set; }
        public string Address1 { get; set; }
        public string LandMark { get; set; }
        public string ZipCode { get; set; }
        public string City { get; set; }
        public string StateName { get; set; }
        public int UserId { get; set; }
        public string Message { get; set; }
    }
}

