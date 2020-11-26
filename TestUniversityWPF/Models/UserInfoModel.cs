using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestUniversityWPF.Models
{
    public class UserInfoModel
    {
        public long Id { get; set; }
        public long UserId { get; set; }
        public string FirstName { get; set; }
        public string Surname { get; set; }
        public string PhoneNumber { get; set; }
        public string Email { get; set; }
        public string Degree { get; set; }
        public string ImageUrl { get; set; }
        public string DateOfBirth { get; set; }
        public string GroupName { get; set; }
        public string UniversityName { get; set; }
    }
}
