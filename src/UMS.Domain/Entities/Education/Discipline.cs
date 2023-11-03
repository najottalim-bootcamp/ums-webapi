namespace UMS.Domain.Entities.EduModels
{
    public class Discipline : Auditable
    {
        public string Name { get; set; }
        public long DepartmentId { get; set; }
        public long TeacherId { get; set; }
        public int LectureHours { get; set; }
        public int PracticeHours { get; set; }
    }
}

