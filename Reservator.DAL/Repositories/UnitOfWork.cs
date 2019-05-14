using Reservator.DAL.Repositories.Interfaces;
using Reservator.Model;
using System;

namespace Reservator.DAL.Repositories
{
	public class UnitOfWork : IUnitOfWork, IDisposable
	{
		private readonly ReservatorDbContext context;
		public IRepositoryBase<EntityBase> RepositoryBase { get; }

		public UnitOfWork(ReservatorDbContext context, IRepositoryBase<EntityBase> repositoryBase)
		{
			this.context = context;
			RepositoryBase = repositoryBase;
		}
		public void Commit()
		{
			context.SaveChanges();
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
