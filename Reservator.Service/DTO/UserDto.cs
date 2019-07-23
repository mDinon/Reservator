using Reservator.Model;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Reservator.Service.DTO
{
	public class UserDto
	{
		[Required]
		public int? ID { get; set; }

		[Required]
		public string Email { get; set; }
		public string EmailConfirmed { get; set; }

		public string Username { get; set; }
		public string FirstName { get; set; }
		public string LastName { get; set; }
		public string Password { get; set; }
		public string Token { get; set; }
		public bool? Active { get; set; }

		public List<RoleDto> Roles { get; set; }

		public UserDto MapFromEntity(User user)
		{
			if (user != null)
			{
				ID = user.ID;
				Username = user.Username;
				Email = user.Email;
				FirstName = user.FirstName;
				LastName = user.LastName;
				//Password = user.Password;
				Active = user.Active;
				Token = user.Token;
			}

			return this;
		}

		public User MapToEntity(User user)
		{
			if (user == null)
			{
				user = new User();
			}

			User userEntity = user;
			userEntity.ID = ID;
			userEntity.Email = Email;
			userEntity.EmailConfirmed = EmailConfirmed;
			userEntity.FirstName = FirstName;
			userEntity.LastName = LastName;
			userEntity.Password = Password;
			userEntity.Token = Token;
			userEntity.Username = Username;

			return userEntity;
		}
	}
}
