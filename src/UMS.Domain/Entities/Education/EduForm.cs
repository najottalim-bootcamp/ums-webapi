using static UMS.Domain.Enums.EduFormEnum;

namespace UMS.Domain.Entities.EduModels
{
    public class EduForm : Auditable
    {
        public EduFormType Name { get; set; }
        public bool IsActive { get; set; }
    }
}
