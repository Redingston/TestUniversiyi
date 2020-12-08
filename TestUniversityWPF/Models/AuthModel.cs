using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestUniversityWPF.Models
{
    public class AuthModel
    {
        public string email { get; set; }
        public string password { get; set; }
        public string apiKey { get; set; }
        public AuthModel()
        {
            email = "string";
            password = "string";
            apiKey = "string";
        }
    }
}
