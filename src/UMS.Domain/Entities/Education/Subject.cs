namespace UMS.Domain.Entities.EduModels
{
    public class Subject : Auditable
    {
        public string Name { get; set; }
        public int SpecialityId { get; set; }
    }
}
