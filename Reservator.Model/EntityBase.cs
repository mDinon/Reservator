﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Reservator.Model
{
	public abstract class EntityBase
	{
		[Key]
		public int ID { get; set; }
		public bool Active { get; set; }
		public DateTime DateCreated { get; set; }
		public DateTime? DateModified { get; set; }
	}
}
