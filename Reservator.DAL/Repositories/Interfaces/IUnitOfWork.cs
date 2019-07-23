using Reservator.Model;
using System.Threading.Tasks;

namespace Reservator.DAL.Repositories.Interfaces
{
	public interface IUnitOfWork
	{
		void Commit();
		Task<int> CommitAsync();
		IRepositoryBase<ObjectOwner> ObjectOwnerRepository { get; }
		IRepositoryBase<User> UserRepository { get; }
	}
}
