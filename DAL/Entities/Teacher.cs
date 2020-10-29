using DAL.Entities.Base;
using System;
using System.Collections.Generic;
using System.Text;

namespace DAL.Entities
{
    public class Teacher
    {
        public Teacher()
        {
            Lessons = new HashSet<Lesson>();
            Classes = new HashSet<Class>();
            TeacherToDisciplines = new HashSet<TeacherToDiscipline>();
        }
        public long Id { get; set; }
        public string Degree { get; set; }

        public User User { get; set; }

        public ICollection<Lesson> Lessons { get; set; }
        public ICollection<Class> Classes { get; set; }
        public ICollection<TeacherToDiscipline> TeacherToDisciplines { get; set; }
    }
}
