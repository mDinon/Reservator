using Microsoft.Extensions.Options;
using Reservator.DAL.Repositories.Interfaces;
using Reservator.Model;
using Reservator.Service.DTO;
using Reservator.Service.Security;
using Reservator.Service.Services.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Reservator.Service.Services
{
	public class UserService : ServiceBase, IUserService
	{
		private readonly IOptions<JwtSettings> options;
		public UserService(IUnitOfWork unitOfWork, IOptions<JwtSettings> options) : base(unitOfWork)
		{
			this.options = options;
		}

		public async Task<UserDto> Authenticate(string username, string password)
		{
			if (string.IsNullOrWhiteSpace(username) || string.IsNullOrWhiteSpace(password))
			{
				throw new ArgumentException("Username or password not provided!");
			}

			IEnumerable<User> users = await UnitOfWork.Repository<User>().GetAsync(x => x.Username == username || x.Email == username, includeProperties:"Roles,Roles.Role");

			User user = users.FirstOrDefault(x => Hash.Validate(password, x.Salt, x.Password));

			if (user == null)
			{
				throw new UnauthorizedAccessException("Invalid username or password!");
			}

			Jwt.GenerateToken(user, options);

			return new UserDto().MapFromEntity(user);
		}

		public async Task<UserDto> Register(UserDto userDto)
		{
			HashSalt password = Hash.Create(userDto.Password, Salt.Create());

			User user = userDto.MapToEntity(new User());
			user.Password = password.Hash;
			user.Salt = password.Salt;

			UnitOfWork.Repository<User>().Insert(user);
			UnitOfWork.Commit();

			return await Authenticate(userDto.Username, userDto.Password);
		}
	}
}
