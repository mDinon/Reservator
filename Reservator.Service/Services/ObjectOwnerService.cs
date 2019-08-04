using Reservator.DAL.Repositories.Interfaces;
using Reservator.Model;
using Reservator.Service.Dto;
using Reservator.Service.Services.Interfaces;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Reservator.Service.Services
{
	public class ObjectOwnerService : ServiceBase, IObjectOwnerService
	{
		public ObjectOwnerService(IUnitOfWork unitOfWork) : base(unitOfWork)
		{
		}

		public async Task<IEnumerable<ObjectOwnerDto>> GetObjectOwnersAsync()
		{
			IEnumerable<ObjectOwner> objectOwners = await UnitOfWork.Repository<ObjectOwner>().GetAsync(orderBy: q => q.OrderBy(x => x.ID));

			return objectOwners.Select(x => new ObjectOwnerDto().MapFromEntity(x));
		}

		public async Task<ObjectOwnerDto> GetAsync(int id)
		{
			ObjectOwner owner = await UnitOfWork.Repository<ObjectOwner>().GetByIDAsync(id);

			return new ObjectOwnerDto().MapFromEntity(owner);
		}

		public async Task<int> Delete(int id)
		{
			UnitOfWork.Repository<ObjectOwner>().Delete(id);
			return await UnitOfWork.CommitAsync();
		}

		public async Task<int> Insert(ObjectOwnerDto dto)
		{

			UnitOfWork.Repository<ObjectOwner>().Insert(dto.MapToEntity(new ObjectOwner()));
			return await UnitOfWork.CommitAsync();
		}

		public async Task<int> Update(int id, ObjectOwnerDto dto)
		{
			ObjectOwner owner = await UnitOfWork.Repository<ObjectOwner>().GetByIDAsync(id);
			UnitOfWork.Repository<ObjectOwner>().Update(dto.MapToEntity(owner));
			return await UnitOfWork.CommitAsync();
		}
	}
}
