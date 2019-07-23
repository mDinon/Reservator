using Microsoft.EntityFrameworkCore;
using Reservator.DAL.ModelConfiguration;
using Reservator.Model;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Reservator.DAL
{
	public class ReservatorDbContext : DbContext
	{
		public DbSet<User> Users { get; set; }
		public DbSet<Reservation> Reservations { get; set; }
		public DbSet<Role> Roles { get; set; }
		public DbSet<ReservationObject> ReservationObjects { get; set; }
		public DbSet<ObjectOwner> ObjectOwners { get; set; }

		public ReservatorDbContext(DbContextOptions<ReservatorDbContext> options) : base(options)
		{
		}

		protected override void OnModelCreating(ModelBuilder modelBuilder)
		{
			modelBuilder.HasDefaultSchema("Reservator");

			modelBuilder.ApplyConfiguration(new UserConfiguration());
			modelBuilder.ApplyConfiguration(new RoleConfiguration());
			modelBuilder.ApplyConfiguration(new ObjectOwnerConfiguration());
			modelBuilder.ApplyConfiguration(new ReservationObjectConfiguration());
			modelBuilder.ApplyConfiguration(new ReservationConfiguration());

			modelBuilder.Entity<UserRole>().HasKey(o => new { o.UserID, o.RoleID });
			modelBuilder.Entity<UserRole>().HasData(
				new UserRole() {
				UserID = 1,
				RoleID = 1,
			}, new UserRole()
			{
				UserID = 2,
				RoleID = 2,
			});
		}
	}
}
