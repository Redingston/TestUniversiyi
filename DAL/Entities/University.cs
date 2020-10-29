using DAL.Entities.Base;
using System;
using System.Collections.Generic;
using System.Text;

namespace DAL.Entities
{
    public class University : EntityBase
    {
        public University()
        {
            Users = new HashSet<User>();
            UpcomingEvents = new HashSet<UpcomingEvent>();
            Auditoriums = new HashSet<Auditorium>();
            Disciplines = new HashSet<Discipline>();
        }

        public string Name { get; set; }
        public string ShortName { get; set; }
        public string Locality { get; set; }
        public string Address { get; set; }
        public string Email { get; set; }

        public ICollection<User> Users { get; set; }
        public ICollection<Auditorium> Auditoriums { get; set; }
        public ICollection<Discipline> Disciplines { get; set; }
    }
}
