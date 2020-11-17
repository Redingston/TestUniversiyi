using System;
using System.Collections.Generic;
using System.Text;

namespace DAL.Entities
{
    public class Student
    {
        public Student()
        {
            GroupeToStudents = new HashSet<GroupeToStudent>();
        }

        public long Id { get; set; }
        public User User { get; set; }

        public ICollection<GroupeToStudent> GroupeToStudents { get; set; }
    }
}
