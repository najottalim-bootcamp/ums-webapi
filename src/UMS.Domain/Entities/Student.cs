namespace UMS.Domain.Entities
{
    public class Student : Auditable
    {
        public int Id { get; set; }
        public int PersonalDataId { get; set; }
        public int Course { get; set; }
        public int SpecialtyEduFormId { get; set; }
        public int IsActive { get; set; }
        public string EduType { get; set; }
        public string GroupNumber { get; set; }
        public int SubjectId { get; set; }
        public DateTime CreatedAt { get; set; }
        public DateTime UpdatedAt { get; set; }
    }
}
