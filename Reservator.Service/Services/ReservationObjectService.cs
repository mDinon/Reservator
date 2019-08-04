using Reservator.DAL.Repositories.Interfaces;
using Reservator.Model;
using Reservator.Service.DTO;
using Reservator.Service.Services.Interfaces;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Reservator.Service.Services
{
	public class ReservationObjectService : ServiceBase, IReservationObjectService
	{
		public ReservationObjectService(IUnitOfWork unitOfWork) : base(unitOfWork)
		{
		}

		public async Task<IEnumerable<ReservationObjectDto>> GetAsync()
		{
			IEnumerable<ReservationObject> reservations = await UnitOfWork.Repository<ReservationObject>().GetAsync(orderBy: q => q.OrderBy(x => x.ID), includeProperties: "ObjectOwner");

			return reservations.Select(x => new ReservationObjectDto().MapFromEntity(x));
		}

		public async Task<ReservationObjectDto> GetAsync(int id)
		{
			ReservationObject reservation = await UnitOfWork.Repository<ReservationObject>().GetByIDAsync(id);

			return new ReservationObjectDto().MapFromEntity(reservation);
		}

		public async Task<int> Delete(int id)
		{
			UnitOfWork.Repository<ReservationObject>().Delete(id);
			return await UnitOfWork.CommitAsync();
		}

		public async Task<int> Insert(ReservationObjectDto dto)
		{

			UnitOfWork.Repository<ReservationObject>().Insert(dto.MapToEntity(new ReservationObject()));
			return await UnitOfWork.CommitAsync();
		}

		public async Task<int> Update(int id, ReservationObjectDto dto)
		{
			ReservationObject reservation = await UnitOfWork.Repository<ReservationObject>().GetByIDAsync(id);
			UnitOfWork.Repository<ReservationObject>().Update(dto.MapToEntity(reservation));
			return await UnitOfWork.CommitAsync();
		}
	}
}
