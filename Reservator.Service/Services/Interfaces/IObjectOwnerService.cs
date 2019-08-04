using Reservator.Service.Dto;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Reservator.Service.Services.Interfaces
{
	public interface IObjectOwnerService
	{
		Task<IEnumerable<ObjectOwnerDto>> GetObjectOwnersAsync();
		Task<ObjectOwnerDto> GetAsync(int id);
		Task<int> Delete(int id);
		Task<int> Insert(ObjectOwnerDto dto);
		Task<int> Update(int id, ObjectOwnerDto dto);
	}
}
