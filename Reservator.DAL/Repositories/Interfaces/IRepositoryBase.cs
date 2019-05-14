using Reservator.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;

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
		TEntity GetByID(object id);
		void Insert(TEntity entity);
		void Delete(object id);
		void Update(TEntity entityToUpdate);
	}
}
