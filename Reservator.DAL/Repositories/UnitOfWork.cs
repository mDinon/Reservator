using Reservator.DAL.Repositories.Interfaces;
using Reservator.Model;
using System;
using System.Threading.Tasks;

namespace Reservator.DAL.Repositories
{
	public class UnitOfWork : IUnitOfWork, IDisposable
	{
		private readonly ReservatorDbContext context;
		public IRepositoryBase<ObjectOwner> ObjectOwnerRepository => new RepositoryBase<ObjectOwner>(context);

		public UnitOfWork(ReservatorDbContext context)
		{
			this.context = context;
		}
		public void Commit()
		{
			context.SaveChanges();
		}

		public async Task<int> CommitAsync()
		{
			return await context.SaveChangesAsync();
		}

		private bool disposed = false;

		protected virtual void Dispose(bool disposing)
		{
			if (!disposed)
			{
				if (disposing)
				{
					context.Dispose();
				}

				disposed = true;
			}
		}

		public void Dispose()
		{
			Dispose(true);
			GC.SuppressFinalize(this);
		}
	}
}
