using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Reservator.Model;

namespace Reservator.DAL.ModelConfiguration
{
	public class ObjectOwnerConfiguration : BaseConfiguration<ObjectOwner>
	{
		public override void Configure(EntityTypeBuilder<ObjectOwner> builder)
		{
			base.Configure(builder);
			builder.Property(x => x.Name).IsRequired().HasMaxLength(255);
		}
	}
}
