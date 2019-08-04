using Reservator.Service.DTO;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Reservator.Service.Services.Interfaces
{
	public interface IReservationObjectService
	{
		Task<IEnumerable<ReservationObjectDto>> GetAsync();
		Task<ReservationObjectDto> GetAsync(int id);
		Task<int> Delete(int id);
		Task<int> Insert(ReservationObjectDto dto);
		Task<int> Update(int id, ReservationObjectDto dto);
	}
}
