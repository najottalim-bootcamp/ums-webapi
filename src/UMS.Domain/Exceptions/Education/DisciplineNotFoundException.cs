using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UMS.Domain.Exceptions.Education
{
    public class DisciplineNotFoundException : NotFoundException
    {
        public DisciplineNotFoundException()
        {
            ExceptionMessage = "Discipline not found !";
        }
    }
}
