using Entity = UMS.Domain.Entities.Teacher;
namespace UMS.DataAccess.Repositories.AcadPositions;

public interface IAcadPositionRepository : IBaseRepository<Entity.AcadPosition, AcadPositionDto>
{
}
