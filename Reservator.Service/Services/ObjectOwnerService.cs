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

		public async Task<IEnumerable<ObjectOwnerDto>> GetObjectOwnersAync()
		{
			//List<ObjectOwnerDto> objectOwnerDtos = new List<ObjectOwnerDto>();
			IEnumerable<ObjectOwner> objectOwners = await UnitOfWork.ObjectOwnerRepository.GetAsync(orderBy: q => q.OrderBy(x => x.ID));

			//objectOwnerDtos.AddRange(objectOwners.Select(x => new ObjectOwnerDto().MapFromEntity(x)));

			//foreach (ObjectOwner owner in objectOwners)
			//{
			//	objectOwnerDtos.Add(new ObjectOwnerDto().MapFromEntity(owner));

			//}

			return objectOwners.Select(x => new ObjectOwnerDto().MapFromEntity(x));
			//return objectOwnerDtos;
		}

		public async Task<ObjectOwnerDto> GetAsync(int id)
		{
			ObjectOwner owner = await UnitOfWork.ObjectOwnerRepository.GetByIDAsync(id);

			return new ObjectOwnerDto().MapFromEntity(owner);
		}

		public async Task<int> Delete(int id)
		{
			UnitOfWork.ObjectOwnerRepository.Delete(id);
			return await UnitOfWork.CommitAsync();
		}

		public async Task<int> Insert(ObjectOwnerDto dto)
		{

			UnitOfWork.ObjectOwnerRepository.Insert(dto.MapToEntity(new ObjectOwner()));
			return await UnitOfWork.CommitAsync();
		}

		public async Task<int> Update(int id, ObjectOwnerDto dto)
		{
			ObjectOwner owner = await UnitOfWork.ObjectOwnerRepository.GetByIDAsync(id);
			UnitOfWork.ObjectOwnerRepository.Update(dto.MapToEntity(owner));
			return await UnitOfWork.CommitAsync();
		}
	}
}
