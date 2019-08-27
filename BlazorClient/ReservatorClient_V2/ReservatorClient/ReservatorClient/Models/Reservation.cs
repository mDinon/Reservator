using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ReservatorClient.Models
{
	public class Reservation
	{
		public int? ID { get; set; }
		public DateTime? DateFrom { get; set; }
		public DateTime? DateTo { get; set; }
		public int? ReservationObjectID { get; set; }
		public int? UserID { get; set; }
		public string ReservationObjectName { get; set; }
		public string ReservationObjectDescription { get; set; }
		public long? ReservationObjectMaximumReservationTime { get; set; }
	}
}
