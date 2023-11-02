namespace UMS.Domain.Entities
{
    public class SpecialtyEduForm : BaseEntity
    {
        public int Id { get; set; }
        public int EduFormId { get; set; }
        public int SpecialtyId { get; set; }

    }
}
