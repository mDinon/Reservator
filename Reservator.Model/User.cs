using System.Collections.Generic;

namespace Reservator.Model
{
	public class User : EntityBase
	{
		public string UserName { get; set; }
		public string FirstName { get; set; }
		public string LastName { get; set; }
		public string Email { get; set; }
		public string Password { get; set; }

		public virtual IEnumerable<Reservation> Reservations { get; set; }
	}
}
