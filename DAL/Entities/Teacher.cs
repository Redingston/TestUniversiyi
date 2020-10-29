using DAL.Entities.Base;
using System;
using System.Collections.Generic;
using System.Text;

namespace DAL.Entities
{
    public class Teacher : EntityBase
    {
        public Teacher()
        {
            Lessons = new HashSet<Lesson>();
            Materials = new HashSet<Material>();
            Classes = new HashSet<Class>();
            TeacherToDisciplines = new HashSet<TeacherToDiscipline>();
            UpcomingEvents = new HashSet<UpcomingEvent>();
            UpcomingTests = new HashSet<UpcomingTest>();
        }
        public long Id { get; set; }
        public string Degree { get; set; }

        public User User { get; set; }

        public ICollection<Lesson> Lessons { get; set; }
        public ICollection<UpcomingEvent> UpcomingEvents { get; set; }
        public ICollection<Class> Classes { get; set; }
        public ICollection<Material> Materials { get; set; }
        public ICollection<TeacherToDiscipline> TeacherToDisciplines { get; set; }
        public ICollection<UpcomingTest> UpcomingTests { get; set; }
    }
}
