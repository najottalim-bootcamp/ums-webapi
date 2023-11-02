namespace UMS.Domain.Entities.EduModels
{
    public class Discipline : Auditable
    {
        public string Name { get; set; }
        public int DepartmentId { get; set; }
        public int TeacherId { get; set; }
        public int LectureHours { get; set; }
        public int PracticeHours { get; set; }
    }
}

