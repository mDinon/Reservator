using FluentValidation;
using Reservator.Model;
using Reservator.Service.DTO;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Reservator.Service.Dto
{
	public class ObjectOwnerDto
	{
		public int? ID { get; set; }
		public bool? Active { get; set; }
		[Required]
		public string Name { get; set; }
		public string Description { get; set; }
		public IEnumerable<ReservationObjectDto> ReservationObjects { get; set; }

		public ObjectOwner MapToEntity(ObjectOwner owner)
		{
			if (owner == null)
			{
				owner = new ObjectOwner();
			}

			ObjectOwner objectOwner = owner;
			objectOwner.ID = ID;
			//objectOwner.Active = Active;
			objectOwner.Description = Description;
			objectOwner.Name = Name;

			return objectOwner;
		}

		public ObjectOwnerDto MapFromEntity(ObjectOwner owner)
		{
			if (owner != null)
			{
				ID = owner.ID;
				Active = owner.Active;
				Description = owner.Description;
				Name = owner.Name;
			}

			return this;
		}
	}

	public class ObjectOwnerDtoValidator : AbstractValidator<ObjectOwnerDto>
	{
		public ObjectOwnerDtoValidator()
		{
			RuleFor(x => x.Name).MaximumLength(255).NotEmpty().NotNull();
		}
	}
}
