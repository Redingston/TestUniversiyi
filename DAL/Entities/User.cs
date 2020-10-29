using DAL.Entities.Base;
using System;
using System.Collections.Generic;
using System.Text;

namespace DAL.Entities
{
    public class User : EntityBase
    {
        public string FirstName { get; set; }
        public string Surname { get; set; }
        public string PhoneNumber { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
        public string ImageUrl { get; set; }
        public DateTime DateOfBirth { get; set; }

        public long? UniversityId { get; set; }
        public University School { get; set; }

        public long RoleId { get; set; }
        public Role Role { get; set; }

        public Student Pupil { get; set; }
        public Teacher Teacher { get; set; }
    }
}
