using System.Collections.Generic;

namespace Reservator.Model
{
	public class Role : EntityBase
	{
		public string Name { get; set; }
		public string Description { get; set; }

		public virtual IEnumerable<UserRole> Users { get; set; }
	}
}
