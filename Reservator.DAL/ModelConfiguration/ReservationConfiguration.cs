using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Reservator.Model;
using System;

namespace Reservator.DAL.ModelConfiguration
{
	public class ReservationConfiguration : BaseConfiguration<Reservation>
	{
		public override void Configure(EntityTypeBuilder<Reservation> builder)
		{
			base.Configure(builder);
			builder.Property(x => x.DateFrom).IsRequired();
			builder.Property(x => x.DateTo).IsRequired();
			builder.Property(x => x.ReservationObjectID).IsRequired();
			builder.Property(x => x.UserID).IsRequired();

			builder.HasData(
				new Reservation() {
					ID = 1,
					Active = true,
					DateCreated = DateTime.Now,
					DateFrom = DateTime.Now,
					DateTo = DateTime.Now,
					ReservationObjectID = 1,
					UserID = 1
				});
		}
	}
}
