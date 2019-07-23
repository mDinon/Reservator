using System.Collections.Generic;

namespace Reservator.Model
{
	public class User : EntityBase
	{
		public string Username { get; set; }
		public string FirstName { get; set; }
		public string LastName { get; set; }
		public string Email { get; set; }
		public string EmailConfirmed { get; set; }
		public string Password { get; set; }
		public string Salt { get; set; }
		public string Token { get; set; }

		public virtual IEnumerable<Reservation> Reservations { get; set; }
		public virtual IEnumerable<UserRole> Roles { get; set; }
	}
}
