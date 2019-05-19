using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Reservator.Model;
using System;

namespace Reservator.DAL.ModelConfiguration
{
	public class UserConfiguration : BaseConfiguration<User>
	{
		public override void Configure(EntityTypeBuilder<User> builder)
		{
			base.Configure(builder);
			builder.Property(x => x.UserName).IsRequired().HasMaxLength(255);
			builder.Property(x => x.Email).IsRequired().HasMaxLength(255);
			builder.Property(x => x.Password).IsRequired();
			builder.Property(x => x.FirstName).IsRequired().HasMaxLength(255);
			builder.Property(x => x.LastName).IsRequired().HasMaxLength(255);

			builder.HasData(new User() {
				Active = true,
				DateCreated = DateTime.Now,
				ID = 1,
				Email = "test.test@test.test",
				FirstName = "Test",
				LastName = "User",
				Password = "testuser",
				UserName = "tUser"
			});
		}
	}
}
