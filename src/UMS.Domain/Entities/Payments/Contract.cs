namespace UMS.Domain.Entities.Payments
{
    public class Contract : Auditable
    {
        public long FacultId { get; set; }
        public long StudentId { get; set; }
        public float Price { get; set; }
    }
}
