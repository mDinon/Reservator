using FluentValidation;
using Reservator.Model;
using System;

namespace Reservator.Service.Dto
{
	public class ReservationDto
	{
		public int? ID { get; set; }
		public bool? Active { get; set; }
		public DateTime? DateFrom { get; set; }
		public DateTime? DateTo { get; set; }
		public int? ReservationObjectID { get; set; }
		public int? UserID { get; set; } = 1;
		public string ReservationObjectName { get; set; }
		public string ReservationObjectDescription { get; set; }
		public long? ReservationObjectMaximumReservationTime { get; set; }
		public string ReservationObjectObjectOwnerName { get; set; }

		public Reservation MapToEntity(Reservation reservation)
		{
			if (reservation == null)
			{
				reservation = new Reservation();
			}

			Reservation reservationEntity = reservation;
			reservationEntity.DateFrom = DateFrom;
			reservationEntity.DateTo = DateTo;
			reservationEntity.ReservationObjectID = ReservationObjectID;
			reservationEntity.UserID = UserID;

			return reservationEntity;
		}

		public ReservationDto MapFromEntity(Reservation reservation)
		{
			if (reservation != null)
			{
				ID = reservation.ID;
				Active = reservation.Active;
				DateFrom = reservation.DateFrom;
				DateTo = reservation.DateTo;
				ReservationObjectID = reservation.ReservationObjectID;
				UserID = reservation.UserID;
				ReservationObjectName = reservation.ReservationObject?.Name;
				ReservationObjectDescription = reservation.ReservationObject?.Description;
				ReservationObjectMaximumReservationTime = reservation.ReservationObject?.MaximumReservationTime;
				ReservationObjectObjectOwnerName = reservation.ReservationObject?.ObjectOwner?.Name;
			}

			return this;
		}
	}

	public class ReservationDtoValidator : AbstractValidator<Reservation>
	{
		public ReservationDtoValidator()
		{
			RuleFor(x => x.DateFrom).NotEmpty().NotNull();
			RuleFor(x => x.DateTo).NotEmpty().NotNull();
			RuleFor(x => x.ReservationObjectID).NotEmpty().NotNull();
			RuleFor(x => x.UserID).NotEmpty().NotNull();
		}
	}
}
