namespace UMS.Domain.Entities.Teacher
{
    public class Teacher : Auditable
    {
        public long DepartmentId { get; set; }
        public long PersonalDataId { get; set; }
        public long AcadPositionId { get; set; }
        public long ScienDegreeId { get; set; }
    }
}
