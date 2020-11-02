namespace DAL.Entities
{
    public class GroupeToStudent
    {
        public long GroupeId { get; set; }
        public Groupe Groupe { get; set; }

        public long StudentId { get; set; }
        public Student Student { get; set; }
    }
}