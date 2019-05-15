using System.Collections.Generic;

namespace Reservator.Model
{
	public class ObjectOwner : EntityBase
	{
		public string Name { get; set; }
		public string Description { get; set; }

		public virtual IEnumerable<ReservationObject> ReservationObjects { get; set; }
	}
}
