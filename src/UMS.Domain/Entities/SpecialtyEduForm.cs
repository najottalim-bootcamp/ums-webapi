using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UMS.Domain.Entities
{
    public class SpecialtyEduForm:BaseEntity
    {
        public int Id { get; set; }
        public int EduFormId { get; set; }
        public int SpecialtyId { get; set; }

    }
}
