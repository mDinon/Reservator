using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Reservator.Model;
using System;

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

			builder.HasData(
				new ReservationObject() {
					Active = true,
					DateCreated = DateTime.Now,
					Description = "Reservation object A",
					ID = 1,
					MaximumReservationTime = TimeSpan.TicksPerDay,
					Name = "Reservation object A",
					ObjectOwnerID = 1
				});
		}
	}
}
