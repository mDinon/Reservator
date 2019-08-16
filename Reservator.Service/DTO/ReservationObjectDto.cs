using FluentValidation;
using Reservator.Model;
using System;

namespace Reservator.Service.DTO
{
	public class ReservationObjectDto
	{
		public int? ID { get; set; }
		public bool? Active { get; set; }
		public string Name { get; set; }
		public string Description { get; set; }
		public long? MaximumReservationTime { get; set; }
		public int? ObjectOwnerID { get; set; } = 1;
		public string ObjectOwnerName { get; set; }
		public string ObjectOwnerDescription { get; set; }

		public ReservationObject MapToEntity(ReservationObject reservationObject)
		{
			if (reservationObject == null)
			{
				reservationObject = new ReservationObject();
			}

			ReservationObject reservationObjectEntity = reservationObject;
			reservationObjectEntity.Name = Name;
			reservationObjectEntity.Description = Description;
			reservationObjectEntity.MaximumReservationTime = ConvertFromDaysToMinutes(MaximumReservationTime.GetValueOrDefault());
			reservationObjectEntity.ObjectOwnerID = ObjectOwnerID;

			return reservationObjectEntity;
		}

		public ReservationObjectDto MapFromEntity(ReservationObject reservationObject)
		{
			if (reservationObject != null)
			{
				ID = reservationObject.ID;
				//Active = reservationObject.Active;
				Name = reservationObject.Name;
				Description = reservationObject.Description;
				MaximumReservationTime = ConvertFromMinutesToDays(reservationObject.MaximumReservationTime.GetValueOrDefault());
				ObjectOwnerID = reservationObject.ObjectOwnerID;
				ObjectOwnerName = reservationObject.ObjectOwner?.Name;
				ObjectOwnerDescription = reservationObject.ObjectOwner?.Description;
			}

			return this;
		}

		private long ConvertFromMinutesToDays(long minutes)
		{
			long hours = minutes / 60;
			long days = hours / 24;

			return days;
		}

		private long ConvertFromDaysToMinutes(long days)
		{
			long hours = days * 24;
			long minutes = hours * 60;

			return minutes;
		}
	}

	public class ReservationObjectDtoValidator : AbstractValidator<ReservationObjectDto>
	{
		public ReservationObjectDtoValidator()
		{
			RuleFor(x => x.Name).MaximumLength(255).NotEmpty().NotNull();
			RuleFor(x => x.ObjectOwnerName).MaximumLength(255).NotEmpty().NotNull();
			RuleFor(x => x.MaximumReservationTime).NotEmpty().NotNull();
			RuleFor(x => x.ObjectOwnerID).NotEmpty().NotNull();
		}
	}
}
