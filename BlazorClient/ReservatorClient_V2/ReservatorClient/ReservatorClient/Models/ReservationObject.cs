using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace ReservatorClient.Models
{
	public class ReservationObject
	{
		public int? ID { get; set; }
		[Required]
		public string Name { get; set; }
		public string Description { get; set; }
		[Required]
		public int? MaximumReservationTime { get; set; }

		public string MaximumReservationTimeString { get { return MaximumReservationTime.ToString(); } set { MaximumReservationTime = Convert.ToInt32(value); } }
	}
}
