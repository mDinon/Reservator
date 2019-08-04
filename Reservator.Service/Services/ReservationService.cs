using Reservator.DAL.Repositories.Interfaces;
using Reservator.Model;
using Reservator.Service.Dto;
using Reservator.Service.Services.Interfaces;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Reservator.Service.Services
{
	public class ReservationService : ServiceBase, IReservationService
	{
		public ReservationService(IUnitOfWork unitOfWork) : base(unitOfWork)
		{
		}

		public async Task<IEnumerable<ReservationDto>> GetAsync()
		{
			IEnumerable<Reservation> reservations = await UnitOfWork.Repository<Reservation>().GetAsync(orderBy: q => q.OrderBy(x => x.ID), includeProperties: "ReservationObject,ReservationObject.ObjectOwner");

			return reservations.Select(x => new ReservationDto().MapFromEntity(x));
		}

		public async Task<ReservationDto> GetAsync(int id)
		{
			Reservation reservation = await UnitOfWork.Repository<Reservation>().GetByIDAsync(id);

			return new ReservationDto().MapFromEntity(reservation);
		}

		public async Task<int> Delete(int id)
		{
			UnitOfWork.Repository<Reservation>().Delete(id);
			return await UnitOfWork.CommitAsync();
		}

		public async Task<int> Insert(ReservationDto dto)
		{

			UnitOfWork.Repository<Reservation>().Insert(dto.MapToEntity(new Reservation()));
			return await UnitOfWork.CommitAsync();
		}

		public async Task<int> Update(int id, ReservationDto dto)
		{
			Reservation reservation = await UnitOfWork.Repository<Reservation>().GetByIDAsync(id);
			UnitOfWork.Repository<Reservation>().Update(dto.MapToEntity(reservation));
			return await UnitOfWork.CommitAsync();
		}
	}
}
