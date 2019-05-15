using Microsoft.EntityFrameworkCore;
using Reservator.DAL.ModelConfiguration;
using Reservator.Model;

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

			modelBuilder.ApplyConfiguration(new ObjectOwnerConfiguration());
			modelBuilder.ApplyConfiguration(new ReservationConfiguration());
			modelBuilder.ApplyConfiguration(new ReservationObjectConfiguration());
		}
	}
}
