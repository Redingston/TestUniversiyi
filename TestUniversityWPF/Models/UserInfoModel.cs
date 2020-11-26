using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestUniversityWPF.Models
{
    public class UserInfoModel
    {
        public long id { get; set; }
        public long userId { get; set; }
        public string firstName { get; set; }
        public string surname { get; set; }
        public string phoneNumber { get; set; }
        public string email { get; set; }
        public string degree { get; set; }
        public string imageUrl { get; set; }
        public string dateOfBirth { get; set; }
        public string groupName { get; set; }
        public string universityName { get; set; }
    }
}
