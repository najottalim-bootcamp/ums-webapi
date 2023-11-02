namespace UMS.Domain.Entities
{
    public class Teacher : Auditable
    {
        public int DepartmentId { get; set; }
        public int PersonalDataId { get; set; }
        public int AcadPositionId { get; set; }
        public int ScienDegreeId { get; set; }
    }
}
