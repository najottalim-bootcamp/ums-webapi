using static UMS.Domain.Enums.PositionEnum;

namespace UMS.Domain.Entities
{
    public class AcadPosition : Auditable
    {
        public Position Name { get; set; }
    }
}
