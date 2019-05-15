using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Reservator.Model;

namespace Reservator.DAL.ModelConfiguration
{
	public class ReservationObjectConfiguration : BaseConfiguration<ReservationObject>
	{
		public override void Configure(EntityTypeBuilder<ReservationObject> builder)
		{
			base.Configure(builder);
			builder.Property(x => x.MaximumReservationTime).IsRequired();
			builder.Property(x => x.Name).IsRequired().HasMaxLength(255);
			builder.Property(x => x.ObjectOwnerID).IsRequired();
		}
	}
}
