using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Reservator.Model;

namespace Reservator.DAL.ModelConfiguration
{
	public class BaseConfiguration<TEntity> : IEntityTypeConfiguration<TEntity> where TEntity : EntityBase
	{
		public virtual void Configure(EntityTypeBuilder<TEntity> builder)
		{
			builder.HasQueryFilter(x => x.Active == true);
			builder.Property(x => x.Active).HasDefaultValueSql("1").ValueGeneratedOnAdd();
			builder.Property(x => x.DateCreated).HasDefaultValueSql("GETDATE()").ValueGeneratedOnAdd();
			builder.Property(x => x.DateModified).HasDefaultValueSql("GETDATE()").ValueGeneratedOnUpdate();
		}
	}
}
