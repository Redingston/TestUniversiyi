namespace DAL.Entities
{
    public class GroupeToDiscipline
    {
        public long GroupeId { get; set; }
        public Groupe Groupe { get; set; }

        public long DisciplineId { get; set; }
        public Discipline Discipline { get; set; }
    }
}