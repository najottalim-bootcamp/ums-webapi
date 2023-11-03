namespace UMS.Domain.Entities.EduModels
{
    public class Specialty : BaseEntity
    {
        public string Name { get; set; }
        public long DepartmentId { get; set; }
    }
}
