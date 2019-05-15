using System;
using System.ComponentModel.DataAnnotations.Schema;

namespace Reservator.Model
{
	public class Reservation : EntityBase
	{
		public DateTime DateFrom { get; set; }
		public DateTime DateTo { get; set; }
		[ForeignKey("ReservationObject")]
		public int ReservationObjectID { get; set; }
		[ForeignKey("User")]
		public int UserID { get; set; }

		public virtual ReservationObject ReservationObject { get; set; }
		public virtual User User { get; set; }
	}
}
