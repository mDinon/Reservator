using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace ReservatorClient.Models
{
	public class Reservation
	{
		public int? ID { get; set; }
		[Required]
		public DateTime? DateFrom { get; set; }
		[Required]
		public DateTime? DateTo { get; set; }
		[Required(ErrorMessage = "Item field is required")]
		public int? ReservationObjectID { get; set; }
		public int? UserID { get; set; } = 1;
		public string ReservationObjectName { get; set; }
		public string ReservationObjectDescription { get; set; }
		public long? ReservationObjectMaximumReservationTime { get; set; }
		public string ReservationObjectIDString { get { return ReservationObjectID.ToString(); } set { ReservationObjectID = Convert.ToInt32(value); } }
	}
}
