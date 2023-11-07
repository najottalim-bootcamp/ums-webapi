namespace UMS.Service.ViewModels.Contracts
{
	public class ContractViewModel
	{
		public long FacultId { get; set; }
        public long StudentId { get; set; }
		public float ContractPrice { get; set; }
        public int StudentCourse { get; set; }
        public bool IsActive { get; set; }
        public string StudentEduType { get; set; }
        public string StudentGroupNumber { get; set; }
        public string FacultyName { get; set; }
        public string FacultyDescription { get; set; }
    }
}

