using DAL.Entities.Base;
using System;
using System.Collections.Generic;
using System.Text;

namespace DAL.Entities
{
    public class Auditorium : EntityBase
    {
        public long Number { get; set; }
        public string Name { get; set; }

        public long UniversityId { get; set; }
        public University University { get; set; }

        public ICollection<Lesson> Lessons { get; set; }
    }
}
