using System;
namespace UMS.Domain.Entities
{
	public class Faculty:Auditable
	{
		public string Name { get; set; }
		public string Description { get;set }
		public int BranchID { get; set; }
	}
}

