using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UMS.DataAccess.Dtos.EduForm;
using UMS.Domain.Entities.EduModels;

namespace UMS.DataAccess.Repositories.EduFormPositions
{
    public interface IEduFormPositionRepository:IBaseRepository<EduForm,EduFormDto>
    {
    }
}
