﻿using System;
using System.ComponentModel.DataAnnotations;

namespace Reservator.Model
{
	public abstract class EntityBase
	{
		[Key]
		public int? ID { get; set; }
		public bool? Active { get; set; }
		public DateTime? DateCreated { get; set; }
		public DateTime? DateModified { get; set; }
	}
}
