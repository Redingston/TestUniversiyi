using DAL.Entities.Base;
using System;
using System.Collections.Generic;
using System.Text;

namespace DAL.Entities
{
    public class Groupe: EntityBase
    {
        public Groupe()
        {
            Lessons = new HashSet<Lesson>();
            GroupeToStudents = new HashSet<GroupeToStudent>();
            GroupeToDisciplines = new HashSet<GroupeToDiscipline>();
        }

        public long Number { get; set; }
        public string Character { get; set; }

        public long GroupeTeacherId { get; set; }
        public Teacher TeacherOf { get; set; }

        public ICollection<Lesson> Lessons { get; set; }
        public ICollection<GroupeToStudent> GroupeToStudents { get; set; }
        public ICollection<GroupeToDiscipline> GroupeToDisciplines { get; set; }
    }
}
