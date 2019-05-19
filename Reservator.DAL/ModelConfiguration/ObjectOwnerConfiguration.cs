using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Reservator.Model;
using System;

namespace Reservator.DAL.ModelConfiguration
{
	public class ObjectOwnerConfiguration : BaseConfiguration<ObjectOwner>
	{
		public override void Configure(EntityTypeBuilder<ObjectOwner> builder)
		{
			base.Configure(builder);
			builder.Property(x => x.Name).IsRequired().HasMaxLength(255);
			builder.HasData(
				new ObjectOwner() {
				Active = true,
				DateCreated = DateTime.Now,
				Description = "Desc1",
				ID = 1,
				Name = "Owner1"
			},
				new ObjectOwner()
				{
					Active = true,
					DateCreated = DateTime.Now,
					Description = "Desc2",
					ID = 2,
					Name = "Owner2"
				});
		}
	}
}
