using DAL.Entities.Base;
using System;
using System.Collections.Generic;
using System.Text;

namespace DAL.Entities
{
    public class Lesson : EntityBase
    {
        public ushort LessonNumber { get; set; }
        public DateTime LessonDate { get; set; }
        public string LessonTimeGap { get; set; }

        public long AuditoriumId { get; set; }
        public Auditorium Auditorium { get; set; }

        public long DisciplineId { get; set; }
        public Discipline Discipline { get; set; }

        public long TeacherId { get; set; }
        public Teacher Teacher { get; set; }

        public long GroupeId { get; set; }
        public Groupe Groupe { get; set; }
    }
}
