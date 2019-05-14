using Reservator.Model;

namespace Reservator.DAL.Repositories.Interfaces
{
	public interface IUnitOfWork
	{
		void Commit();
		IRepositoryBase<EntityBase> RepositoryBase { get; }
	}
}
