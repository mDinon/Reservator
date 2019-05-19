using FluentValidation;
using Reservator.Model;
using Reservator.Service.Dto;
using System;
using System.Collections.Generic;
using System.Text;

namespace Reservator.Service.DTO
{
	public class ReservationObjectDto
	{
		public int? ID { get; set; }
		public bool? Active { get; set; }
		public string Name { get; set; }
		public string Description { get; set; }
		public Int64? MaximumReservationTime { get; set; }
		public int? ObjectOwnerID { get; set; }
		public string ObjectOwnerName { get; set; }
		public string ObjectOwnerDescription { get; set; }
		public IEnumerable<Reservation> Reservations { get; set; }
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
