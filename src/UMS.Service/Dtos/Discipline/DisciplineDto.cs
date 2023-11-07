namespace UMS.Service.Dtos.Discipline
{
    public class DisciplineDto
    {
        public string Name { get; set; }
        public long DepartmentId { get; set; }
        public long TeacherId { get; set; }
        public int LectureHours { get; set; }
        public int PracticeHours { get; set; }
    }
}
