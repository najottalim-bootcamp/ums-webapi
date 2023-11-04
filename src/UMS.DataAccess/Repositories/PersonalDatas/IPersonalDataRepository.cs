using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UMS.DataAccess.Dtos.PersonalDatas;
using UMS.Domain.Entities.People;

namespace UMS.DataAccess.Repositories.PersonalDatas
{
    public interface IPersonalDataRepository: IBaseRepository<PersonalData,PersonalDataDto>
    {
    }
}
