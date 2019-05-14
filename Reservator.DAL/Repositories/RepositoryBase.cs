using Microsoft.EntityFrameworkCore;
using Reservator.DAL.Repositories.Interfaces;
using Reservator.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;

namespace Reservator.DAL.Repositories
{
	public class RepositoryBase<TEntity> : IRepositoryBase<TEntity> where TEntity : EntityBase
	{
		internal ReservatorDbContext context;
		internal DbSet<TEntity> dbSet;
		public RepositoryBase(ReservatorDbContext context)
		{
			this.context = context;
			dbSet = this.context.Set<TEntity>();
		}

		public virtual IEnumerable<TEntity> Get(
			Expression<Func<TEntity, bool>> filter = null,
			Func<IQueryable<TEntity>, IOrderedQueryable<TEntity>> orderBy = null,
			string includeProperties = "")
		{
			IQueryable<TEntity> query = dbSet;

			if (filter != null)
			{
				query = query.Where(filter);
			}

			foreach (string includeProperty in includeProperties.Split
				(new char[] { ',' }, StringSplitOptions.RemoveEmptyEntries))
			{
				query = query.Include(includeProperty);
			}

			if (orderBy != null)
				query = orderBy(query);

			return query.ToList();
		}

		public virtual TEntity GetByID(object id)
		{
			return dbSet.Find(id);
		}

		public virtual void Insert(TEntity entity)
		{
			dbSet.Add(entity);
		}

		public virtual void Delete(object id)
		{
			TEntity entityToDelete = dbSet.Find(id);
			entityToDelete.Active = false;
			Update(entityToDelete);
		}

		//public virtual void Delete(TEntity entityToDelete)
		//{
		//	if (context.Entry(entityToDelete).State == EntityState.Detached)
		//	{
		//		dbSet.Attach(entityToDelete);
		//	}
		//	dbSet.Remove(entityToDelete);
		//}

		public virtual void Update(TEntity entityToUpdate)
		{
			dbSet.Attach(entityToUpdate);
			context.Entry(entityToUpdate).State = EntityState.Modified;
		}
	}
}
