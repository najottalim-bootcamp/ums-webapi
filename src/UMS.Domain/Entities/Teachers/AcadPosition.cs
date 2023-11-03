using static UMS.Domain.Enums.PositionEnum;

namespace UMS.Domain.Entities.Teacher
{
    public class AcadPosition : Auditable
    {
        public Position Name { get; set; }
    }
}
