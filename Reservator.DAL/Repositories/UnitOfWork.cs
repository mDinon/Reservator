using Reservator.DAL.Repositories.Interfaces;
using Reservator.Model;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Reservator.DAL.Repositories
{
	public class UnitOfWork : IUnitOfWork, IDisposable
	{
		private readonly ReservatorDbContext context;
		private Dictionary<string, object> repositories;

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

		public IRepositoryBase<TEntity> Repository<TEntity>() where TEntity : EntityBase
		{
			if (repositories == null)
			{
				repositories = new Dictionary<string, object>();
			}

			string type = typeof(TEntity).Name;

			if (!repositories.ContainsKey(type))
			{
				Type repositoryType = typeof(RepositoryBase<>);
				object repositoryInstance = Activator.CreateInstance(repositoryType.MakeGenericType(typeof(TEntity)), context);
				repositories.Add(type, repositoryInstance);
			}
			return (IRepositoryBase<TEntity>)repositories[type];
		}
	}
}
