namespace UMS.Domain.Entities
{
    public class Contract : Auditable 
    {
        public int FacultId { get; set; }
        public int StudentId { get; set; }
        public float Price { get; set;}
    }
}
