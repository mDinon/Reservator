using Reservator.Service.Dto;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Reservator.Service.Services.Interfaces
{
	public interface IReservationService
	{
		Task<IEnumerable<ReservationDto>> GetAsync();
		Task<ReservationDto> GetAsync(int id);
		Task<int> Delete(int id);
		Task<int> Insert(ReservationDto dto);
		Task<int> Update(int id, ReservationDto dto);
	}
}
