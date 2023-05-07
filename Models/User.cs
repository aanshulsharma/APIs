using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Threading.Tasks;
using System.Data;

namespace Banner.Models
{
    
    public class User
    {
        public int UserCode { get; set; }
        public string UserType { get; set; }
        public string username { get; set; }
        public string Password { get; set; }
        public string ConfirmPassword { get; set; }
        public string Email { get; set; }
        public string PhoneNumber { get; set; }
        public string Message { get; set; }
        
    }
    
}
