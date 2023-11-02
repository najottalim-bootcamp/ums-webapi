namespace UMS.Domain.Entities.EduModels
{
    public class Specialty : BaseEntity
    {
        public string Name { get; set; }
        public int DepartmentId { get; set; }
    }
}
