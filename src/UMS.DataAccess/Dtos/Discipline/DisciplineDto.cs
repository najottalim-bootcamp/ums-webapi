using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UMS.DataAccess.Dtos.Discipline
{
    public class DisciplineDto
    {
        public string Name { get; set; }
        public long DepartmentId { get; set; }
        public long TeacherId { get; set; }
        public int LectureHours { get; set; }
        public int PracticeHours { get; set; }
    }
}
