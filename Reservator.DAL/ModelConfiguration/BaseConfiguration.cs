using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Reservator.Model;

namespace Reservator.DAL.ModelConfiguration
{
	public class BaseConfiguration<TEntiy> : IEntityTypeConfiguration<TEntiy> where TEntiy : EntityBase
	{
		public virtual void Configure(EntityTypeBuilder<TEntiy> builder)
		{
			builder.HasQueryFilter(x => x.Active.GetValueOrDefault());
			builder.Property(x => x.Active).HasDefaultValueSql("1").ValueGeneratedOnAdd();
			builder.Property(x => x.DateCreated).HasDefaultValueSql("GETDATE()").ValueGeneratedOnAdd();
			builder.Property(x => x.DateModified).HasDefaultValueSql("GETDATE()").ValueGeneratedOnUpdate();
		}
	}
}
