namespace UMS.Domain.Entities
{
    public class Specialty : BaseEntity
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int DepartmentId { get; set; }
    }
}
