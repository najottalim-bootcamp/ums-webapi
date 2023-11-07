using static UMS.Domain.Enums.EduFormEnum;

namespace UMS.Service.Dtos.EduForm
{
    public class EduFormDto
    {
        public EduFormType Name { get; set; }
        public bool IsActive { get; set; }
    }
}
