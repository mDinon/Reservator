using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

namespace Reservator.Model
{
	public class ReservationObject : EntityBase
	{
		public string Name { get; set; }
		public Int64? MaximumReservationTime { get; set; }
		[ForeignKey("ObjectOwner")]
		public int? ObjectOwnerID { get; set; }
		public string Description { get; set; }

		public virtual ObjectOwner ObjectOwner { get; set; }
		public virtual IEnumerable<Reservation> Reservations { get; set; }
	}
}
