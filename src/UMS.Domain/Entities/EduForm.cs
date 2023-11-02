namespace UMS.Domain.Entities
{
    public class EduForm : Auditable
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int IsActive { get; set; }
        public DateTime CreatedAt { get; set; }
        public DateTime UpdatedAt { get; set; }
    }
}
