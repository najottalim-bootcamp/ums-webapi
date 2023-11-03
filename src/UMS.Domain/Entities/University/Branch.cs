namespace UMS.Domain.Entities.University
{
    public class Branch : BaseEntity
    {
        public string Name { get; set; }
        public long UniversityId { get; set; }
        public string Address { get; set; }
        public long CityID { get; set; }
        public string PostCode { get; set; }
    }
}

