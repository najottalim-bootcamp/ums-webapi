namespace UMS.Domain.Entities
{
    public class Subject : Auditable
    {
        public string Name { get; set; }
        public int SpecialityId { get; set; }
    }
}
