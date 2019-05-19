using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Reservator.Model;
using System;

namespace Reservator.DAL.ModelConfiguration
{
	public class RoleConfiguration : BaseConfiguration<Role>
	{
		public override void Configure(EntityTypeBuilder<Role> builder)
		{
			base.Configure(builder);
			builder.Property(x => x.Name).IsRequired().HasMaxLength(255);

			builder.HasData(new Role() {
				Name = "User",
				ID = 1,
				Description = "User role",
				DateCreated = DateTime.Now,
				Active = true
			});
		}
	}
}
