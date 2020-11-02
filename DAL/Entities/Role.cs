using DAL.Entities.Base;
using System.Collections.Generic;

namespace DAL.Entities
{
    public class Role : EntityBase
    {
        public Role()
        {
            Users = new HashSet<User>();
        }

        public string Name { get; set; }
        public string Description { get; set; }
        public ICollection<User> Users { get; set; }
    }
}