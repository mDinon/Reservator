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
		public int? UserID { get; set; }
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
