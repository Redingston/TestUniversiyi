using System;
using System.Collections.Generic;
using System.Text;

namespace DAL.Entities
{
    class Student
    {
        public Student()
        {
            ClassToPupils = new HashSet<ClassToPupil>();
        }

        public long Id { get; set; }
        public User User { get; set; }

        public ICollection<ClassToPupil> ClassToPupils { get; set; }
    }
}
