using Reservator.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace Reservator.DAL.Repositories.Interfaces
{
	public interface IRepositoryBase
	{
	}

	public interface IRepositoryBase<TEntity> : IRepositoryBase where TEntity : EntityBase
	{
		IEnumerable<TEntity> Get(
			Expression<Func<TEntity, bool>> filter = null,
			Func<IQueryable<TEntity>, IOrderedQueryable<TEntity>> orderBy = null,
			string includeProperties = "");
		Task<IEnumerable<TEntity>> GetAsync(
			Expression<Func<TEntity, bool>> filter = null,
			Func<IQueryable<TEntity>, IOrderedQueryable<TEntity>> orderBy = null,
			string includeProperties = "");
		TEntity GetByID(object id);
		Task<TEntity> GetByIDAsync(object id);
		TEntity Find(Expression<Func<TEntity, bool>> filter = null, string includeProperties = "");
		Task<TEntity> FindAsync(Expression<Func<TEntity, bool>> filter = null, string includeProperties = "");
		void Insert(TEntity entity);
		void Delete(object id);
		void Update(TEntity entityToUpdate);
	}
}
