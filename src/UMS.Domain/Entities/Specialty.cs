namespace UMS.Domain.Entities
{
    public class Specialty : BaseEntity
    {
        public string Name { get; set; }
        public int DepartmentId { get; set; }
    }
}
