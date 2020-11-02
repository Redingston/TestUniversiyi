using DAL.Entities.Base;
using System;
using System.Collections.Generic;
using System.Text;

namespace DAL.Entities
{
    public class Discipline : EntityBase
    {
        public Discipline()
        {
            TeacherToDisciplines = new HashSet<TeacherToDiscipline>();
            Lessons = new HashSet<Lesson>();
            GroupeToDisciplines = new HashSet<GroupeToDiscipline>();
        }

        public string Name { get; set; }

        public long UniversityId { get; set; }
        public University University { get; set; }

        public ICollection<TeacherToDiscipline> TeacherToDisciplines { get; set; }
        public ICollection<Lesson> Lessons { get; set; }
        public ICollection<GroupeToDiscipline> GroupeToDisciplines { get; set; }
    }
}
