﻿using System;
namespace UMS.Domain.Entities
{
	public class University:BaseEntity
	{
		public string Name { get; set; }
		public string Description { get; set; }
		public string ImagePath { get; set; }
	}
}

