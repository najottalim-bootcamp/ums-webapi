﻿using static UMS.Domain.Enums.EduFormEnum;

namespace UMS.DataAccess.Dtos.EduForm
{
    public class EduFormDto
    {
        public EduFormType Name { get; set; }
        public bool IsActive { get; set; }
    }
}
