using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static UMS.Domain.Enums.EduFormEnum;

namespace UMS.DataAccess.Dtos.EduForm
{
    public class EduFormDto
    {
        public EduFormType Name { get; set; }
        public bool IsActive { get; set; }
    }
}
