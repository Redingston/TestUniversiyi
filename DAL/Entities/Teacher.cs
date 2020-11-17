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
            Groupes = new HashSet<Groupe>();
            TeacherToDisciplines = new HashSet<TeacherToDiscipline>();
        }
        public long Id { get; set; }
        public string Degree { get; set; }

        public User User { get; set; }

        public ICollection<Lesson> Lessons { get; set; }
        public ICollection<Groupe> Groupes { get; set; }
        public ICollection<TeacherToDiscipline> TeacherToDisciplines { get; set; }
    }
}
