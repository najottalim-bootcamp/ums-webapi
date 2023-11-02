using System;
namespace UMS.Domain.Entities
{
	public class Branch:BaseEntity
	{
		public string Name { get; set; }
		public int UniversityId { get; set; }
		public string Address { get; set;}
		public int CityID { get; set; }
		public string PostCode { get; set; }
	}
}

